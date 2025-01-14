package com.Transactions.Transactions.Controller;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;
import com.Transactions.Transactions.Dto.TransactionDto;
import com.Transactions.Transactions.Dto.TransactionsCreationDto;
import com.Transactions.Transactions.Enum.Type;
import com.Transactions.Transactions.Service.TransactionsService;
import com.Transactions.Transactions.Service.Exception.TransactionNotFoundException;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@RestController
@RequestMapping(value = "/api/v1/transactions")
public class TransactionsController {
    private final TransactionsService transactionsService;

    public TransactionsController(TransactionsService transactionsService) {
        this.transactionsService = transactionsService;
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public TransactionDto saveTransaction(@RequestBody TransactionsCreationDto transactionsCreationDto)
            throws Exception {
        return transactionsService.saveTransaction(transactionsCreationDto);
    }

    @GetMapping("/id/{id}")
    @ResponseStatus(HttpStatus.OK)
    public TransactionDto getTransactionById(@PathVariable int id) throws TransactionNotFoundException {
        return transactionsService.getTransactionById(id);
    }

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public List<TransactionDto> listAllTransactions(
            @RequestParam(required = false) Type type,
            @RequestParam(required = false) @DateTimeFormat(pattern = "yyyy-MM-dd'T'HH:mm:ss") LocalDateTime createdAt) {
        return transactionsService.listAllTransactions(Optional.ofNullable(type), Optional.ofNullable(createdAt));
    }

    @GetMapping("/counterpartyAccountNumber/{counterpartyAccountNumber}/counterpartyBankCode/{counterpartyBankCode}")
    @ResponseStatus(HttpStatus.OK)
    public List<TransactionDto> listTransactionsByBankAccountEndBanckCode(
            @PathVariable String counterpartyAccountNumber,
            @PathVariable String counterpartyBankCode) {
        return transactionsService.listTransactionsByBankAccountEndBanckCode(counterpartyAccountNumber,
                counterpartyBankCode);
    }
}
