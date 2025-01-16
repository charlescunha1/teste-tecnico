package com.Transactions.Transactions.Service;

import java.math.BigDecimal;
import java.net.http.HttpResponse;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import org.springframework.stereotype.Service;
import com.Transactions.Transactions.Dto.AmountRequestDTO;
import com.Transactions.Transactions.Dto.TransactionDto;
import com.Transactions.Transactions.Dto.TransactionsCreationDto;
import com.Transactions.Transactions.Entity.Transactions;
import com.Transactions.Transactions.Enum.Type;
import com.Transactions.Transactions.Repository.TransactionsRepository;
import com.Transactions.Transactions.Service.Exception.TransactionNotFoundException;
import com.Transactions.Transactions.Util.ApiEndpoints;

@Service
public class TransactionsService {
    private final TransactionsRepository transactionsRepository;
    private final HttpService httpService;

    public TransactionsService(TransactionsRepository transactionsRepository) {
        this.transactionsRepository = transactionsRepository;
        this.httpService = new HttpService();
    }

    public TransactionDto saveTransaction(TransactionsCreationDto transactionsCreationDto) throws Exception {
        boolean result = isAccountRequestValid(transactionsCreationDto);
        if (result == false) {
            throw new Exception("Saldo insuficiente");
        }
        return TransactionDto.fromEntity(transactionsRepository.save(transactionsCreationDto.toEntity()));
    }

    public TransactionDto getTransactionById(int id) throws TransactionNotFoundException {
        return TransactionDto
                .fromEntity(transactionsRepository.findById(id).orElseThrow(TransactionNotFoundException::new));
    }

    public List<TransactionDto> listTransactionsByBankAccountEndBanckCode(String counterpartyAccountNumber,
            String counterpartyBankCode) {
        return transactionsRepository.findByCounterpartyAccountNumberAndCounterpartyBankCode(counterpartyAccountNumber,
                counterpartyBankCode)
                .stream()
                .map(TransactionDto::fromEntity)
                .collect(Collectors
                        .toList());
    }

    public List<TransactionDto> listAllTransactions(Optional<Type> type, Optional<LocalDateTime> createdAt) {
        return getTransactionsSortedByDate(type, createdAt)
                .stream()
                .map(TransactionDto::fromEntity)
                .collect(Collectors
                        .toList());
    }

    private List<Transactions> getTransactionsSortedByDate(Optional<Type> type, Optional<LocalDateTime> createdAt) {
        if (type.isPresent() && createdAt.isPresent()) {
            return transactionsRepository.findAllByTypeAndCreatedAtAfterOrderByCreatedAtDesc(type.get(),
                    createdAt.get());
        } else if (type.isPresent()) {
            return transactionsRepository.findAllByTypeOrderByCreatedAtDesc(type.get());
        } else if (createdAt.isPresent()) {
            return transactionsRepository.findAllByCreatedAtAfterOrderByCreatedAtDesc(createdAt.get());
        } else {
            return transactionsRepository.findAllByOrderByCreatedAtDesc();
        }
    }

    public boolean debitById(BigDecimal amount, int id) throws Exception {

        String apiUrl = ApiEndpoints.DEBIT_ACCOUNT_BY_ID.replace("{id}", String.valueOf(id));
        AmountRequestDTO data = new AmountRequestDTO(amount);

        try {
            httpService.post(apiUrl, data);
            return true;
        } catch (Exception e) {
            // Handle exception or rethrow
            return false;
        }
    }

    public boolean isAccountRequestValid(TransactionsCreationDto transactionsCreationDto) throws Exception {

        if (debitById(transactionsCreationDto.amount(), transactionsCreationDto.bankAccountId())) {
            return creditAccountByNumber(transactionsCreationDto);
        }
        return false;
    }

    public boolean creditAccountByNumber(TransactionsCreationDto transactionsCreationDto) {

        String apiUrl = ApiEndpoints.CREDIT_ACCOUNT_BY_NUMBER.replace("{number}",
                String.valueOf(transactionsCreationDto.counterpartyAccountNumber()));
        AmountRequestDTO data = new AmountRequestDTO(transactionsCreationDto.amount());

        HttpResponse<String> resposta = httpService.post(apiUrl, data);
        if (resposta.statusCode() == 200 || resposta.statusCode() == 201) {
            return true;
        }
        return false;
    }
}