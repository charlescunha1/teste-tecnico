package com.Transactions.Transactions.Util.ExceptionHttp;

public class BadRequestException extends HttpRequestException {
    public BadRequestException(String message) {
        super(message, 400);
    }
}