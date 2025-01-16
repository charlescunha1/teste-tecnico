package com.Transactions.Transactions.Util.ExceptionHttp;

public class HttpRequestException extends RuntimeException {
    private final int statusCode;

    public HttpRequestException(String message, int statusCode) {
        super(message);
        this.statusCode = statusCode;
    }

    public int getStatusCode() {
        return statusCode;
    }
}
