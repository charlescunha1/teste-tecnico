package com.Transactions.Transactions.Service;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import com.Transactions.Transactions.Dto.TransactionDto;
import com.Transactions.Transactions.Dto.TransactionsCreationDto;
import com.Transactions.Transactions.Entity.Transactions;
import com.Transactions.Transactions.Enum.Type;
import com.Transactions.Transactions.Repository.TransactionsRepository;
import com.Transactions.Transactions.Service.Exception.TransactionNotFoundException;

@Service
public class TransactionsService {
    private final TransactionsRepository transactionsRepository;

    public TransactionsService(TransactionsRepository transactionsRepository) {
        this.transactionsRepository = transactionsRepository;
    }

    public TransactionDto saveTransaction(TransactionsCreationDto transactionsCreationDto) {
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
}
