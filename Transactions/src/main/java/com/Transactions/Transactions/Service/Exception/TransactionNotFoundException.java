package com.Transactions.Transactions.Service.Exception;

public class TransactionNotFoundException extends NotFoundException {

    public TransactionNotFoundException() {
        super("Transacao nao encontrada");
    }
}