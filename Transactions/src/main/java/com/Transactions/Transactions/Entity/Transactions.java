package com.Transactions.Transactions.Entity;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import com.Transactions.Transactions.Enum.CounterpartyAccountType;
import com.Transactions.Transactions.Enum.CounterpartyHolderType;
import com.Transactions.Transactions.Enum.Type;
import jakarta.persistence.*;

@Entity
@Table(name = "Transactions")
public class Transactions {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private Type type;
    private Double amount;
    private int bankAccountId;
    private String counterpartyBankCode;
    private String counterpartyBankName;
    private String counterpartyBranch;
    private String counterpartyAccountNumber;
    private CounterpartyAccountType counterpartyAccountType;
    private String counterpartyHolderName;
    private CounterpartyHolderType counterpartyHolderType;
    private String counterpartyHolderDocument;
    private LocalDateTime createdAt;
    private LocalDateTime updatedAt;

    public Transactions() {
    }

    public Transactions(Type type, Double amount, int bankAccountId, String counterpartyBankCode,
            String counterpartyBankName, String counterpartyBranch, String counterpartyAccountNumber,
            CounterpartyAccountType counterpartyAccountType, String counterpartyHolderName,
            CounterpartyHolderType counterpartyHolderType, String counterpartyHolderDocument, LocalDateTime createdAt,
            LocalDateTime updatedAt) {

        this.type = type;
        this.amount = amount;
        this.bankAccountId = bankAccountId;
        this.counterpartyBankCode = counterpartyBankCode;
        this.counterpartyBankName = counterpartyBankName;
        this.counterpartyBranch = counterpartyBranch;
        this.counterpartyAccountNumber = counterpartyAccountNumber;
        this.counterpartyAccountType = counterpartyAccountType;
        this.counterpartyHolderName = counterpartyHolderName;
        this.counterpartyHolderType = counterpartyHolderType;
        this.counterpartyHolderDocument = counterpartyHolderDocument;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
    }

    public int getId() {
        return id;
    }

    public Type getType() {
        return type;
    }

    public Double getAmount() {
        return amount;
    }

    public int getBankAccountId() {
        return bankAccountId;
    }

    public String getCounterpartyBankCode() {
        return counterpartyBankCode;
    }

    public String getCounterpartyBankName() {
        return counterpartyBankName;
    }

    public String getCounterpartyBranch() {
        return counterpartyBranch;
    }

    public String getCounterpartyAccountNumber() {
        return counterpartyAccountNumber;
    }

    public CounterpartyAccountType getCounterpartyAccountType() {
        return counterpartyAccountType;
    }

    public String getCounterpartyHolderName() {
        return counterpartyHolderName;
    }

    public CounterpartyHolderType getCounterpartyHolderType() {
        return counterpartyHolderType;
    }

    public String getCounterpartyHolderDocument() {
        return counterpartyHolderDocument;
    }

    public LocalDateTime getCreatedAt() {
        return createdAt;
    }

    public LocalDateTime getUpdatedAt() {
        return updatedAt;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setType(Type type) {
        this.type = type;
    }

    public void setAmount(Double amount) {
        this.amount = amount;
    }

    public void setBankAccountId(int bankAccountId) {
        this.bankAccountId = bankAccountId;
    }

    public void setCounterpartyBankCode(String counterpartyBankCode) {
        this.counterpartyBankCode = counterpartyBankCode;
    }

    public void setCounterpartyBankName(String counterpartyBankName) {
        this.counterpartyBankName = counterpartyBankName;
    }

    public void setCounterpartyBranch(String counterpartyBranch) {
        this.counterpartyBranch = counterpartyBranch;
    }

    public void setCounterpartyAccountNumber(String counterpartyAccountNumber) {
        this.counterpartyAccountNumber = counterpartyAccountNumber;
    }

    public void setCounterpartyAccountType(CounterpartyAccountType counterpartyAccountType) {
        this.counterpartyAccountType = counterpartyAccountType;
    }

    public void setCounterpartyHolderName(String counterpartyHolderName) {
        this.counterpartyHolderName = counterpartyHolderName;
    }

    public void setCounterpartyHolderType(CounterpartyHolderType counterpartyHolderType) {
        this.counterpartyHolderType = counterpartyHolderType;
    }

    public void setCounterpartyHolderDocument(String counterpartyHolderDocument) {
        this.counterpartyHolderDocument = counterpartyHolderDocument;
    }

    public void setCreatedAt(LocalDateTime createdAt) {
        this.createdAt = createdAt;
    }

    public void setUpdatedAt(LocalDateTime updatedAt) {
        this.updatedAt = updatedAt;
    }
}
