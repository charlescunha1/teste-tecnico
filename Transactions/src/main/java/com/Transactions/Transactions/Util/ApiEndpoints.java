package com.Transactions.Transactions.Util;

public class ApiEndpoints {

    public static final String BASE_URL = "http://localhost:5000/api";
    // URLs específicas
    public static final String DEBIT_ACCOUNT_BY_ID = BASE_URL + "/BankAccounts/DebitAccountById/{id}";
    public static final String CREDIT_ACCOUNT_BY_NUMBER = BASE_URL + "/BankAccounts/DepositToAccount/{number}";
}