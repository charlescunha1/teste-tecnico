package com.Transactions.Transactions.Dto;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import com.Transactions.Transactions.Entity.Transactions;
import com.Transactions.Transactions.Enum.CounterpartyAccountType;
import com.Transactions.Transactions.Enum.CounterpartyHolderType;
import com.Transactions.Transactions.Enum.Type;

public record TransactionDto(
        int id,
        Type type,
        BigDecimal amount,
        int bankAccountId,
        String counterpartyBankCode,
        String counterpartyBankName,
        String counterpartyBranch,
        String counterpartyAccountNumber,
        CounterpartyAccountType counterpartyAccountType,
        String counterpartyHolderName,
        CounterpartyHolderType counterpartyHolderType,
        String counterpartyHolderDocument,
        LocalDateTime createdAt,
        LocalDateTime updatedAt) {

    public static TransactionDto fromEntity(Transactions transactions) {
        return new TransactionDto(
                transactions.getId(),
                transactions.getType(),
                transactions.getAmount(),
                transactions.getBankAccountId(),
                transactions.getCounterpartyBankCode(),
                transactions.getCounterpartyBankName(),
                transactions.getCounterpartyBranch(),
                transactions.getCounterpartyAccountNumber(),
                transactions.getCounterpartyAccountType(),
                transactions.getCounterpartyHolderName(),
                transactions.getCounterpartyHolderType(),
                transactions.getCounterpartyHolderDocument(),
                transactions.getCreatedAt(),
                transactions.getUpdatedAt());
    }
}
