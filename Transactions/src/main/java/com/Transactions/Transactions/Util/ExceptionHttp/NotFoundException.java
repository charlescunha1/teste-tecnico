package com.Transactions.Transactions.Util.ExceptionHttp;

public class NotFoundException extends HttpRequestException {
    public NotFoundException(String message) {
        super(message, 404);
    }
}
