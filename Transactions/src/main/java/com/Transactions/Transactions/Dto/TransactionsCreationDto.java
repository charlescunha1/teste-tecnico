package com.Transactions.Transactions.Dto;

import java.time.LocalDateTime;
import com.Transactions.Transactions.Entity.Transactions;
import com.Transactions.Transactions.Enum.CounterpartyAccountType;
import com.Transactions.Transactions.Enum.CounterpartyHolderType;
import com.Transactions.Transactions.Enum.Type;

public record TransactionsCreationDto(
        Type type,
        Double amount,
        int bankAccountId,
        String counterpartyBankCode,
        String counterpartyBankName,
        String counterpartyBranch,
        String counterpartyAccountNumber,
        CounterpartyAccountType counterpartyAccountType,
        String counterpartyHolderName,
        CounterpartyHolderType counterpartyHolderType,
        String counterpartyHolderDocument) {

    public Transactions toEntity() {
        return new Transactions(
                type, amount, bankAccountId,
                counterpartyBankCode, counterpartyBankName,
                counterpartyBranch, counterpartyAccountNumber,
                counterpartyAccountType, counterpartyHolderName,
                counterpartyHolderType, counterpartyHolderDocument,
                LocalDateTime.now(), LocalDateTime.now());
    }
}
