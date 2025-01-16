package com.Transactions.Transactions.Service;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import com.Transactions.Transactions.Service.Exception.NotFoundException;
import com.Transactions.Transactions.Util.ExceptionHttp.BadRequestException;
import com.Transactions.Transactions.Util.ExceptionHttp.HttpRequestException;
import com.fasterxml.jackson.databind.ObjectMapper;

public class HttpService {
    private final HttpClient client;
    private final ObjectMapper objectMapper;

    public HttpService() {
        this.client = HttpClient.newHttpClient();
        this.objectMapper = new ObjectMapper();
    }

    // public HttpResponse<String> post(String url, Object requestBody) throws
    // Exception {

    // try {
    // String requestBodyStr = objectMapper.writeValueAsString(requestBody);
    // HttpRequest request = HttpRequest.newBuilder()
    // .uri(URI.create(url))
    // .header("Content-Type", "application/json")
    // .POST(HttpRequest.BodyPublishers.ofString(requestBodyStr))
    // .build();
    // return client.send(request, HttpResponse.BodyHandlers.ofString());
    // } catch (Exception e) {
    // throw new HttpRequestException("Failed to execute POST request", 500);
    // }
    // }

    public HttpResponse<String> post(String url, Object requestBody) {
        try {
            String requestBodyStr = objectMapper.writeValueAsString(requestBody);
            HttpRequest request = HttpRequest.newBuilder().uri(URI.create(url))
                    .header("Content-Type", "application/json")
                    .POST(HttpRequest.BodyPublishers.ofString(requestBodyStr))
                    .build();
            HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

            checkForErrors(response);
            return response;
        } catch (Exception e) {
            throw new HttpRequestException("Failed to execute POST request", 500);
        }
    }

    public HttpResponse<String> get(String url) {
        try {
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create(url)).header("Content-Type", "application/json")
                    .GET()
                    .build();
            HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

            checkForErrors(response);
            return response;
        } catch (Exception e) {
            throw new HttpRequestException("Failed to execute GET request", 500);
        }
    }

    public HttpResponse<String> put(String url, Object requestBody) {
        try {
            String requestBodyStr = objectMapper.writeValueAsString(requestBody);
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create(url))
                    .header("Content-Type", "application/json")
                    .PUT(HttpRequest.BodyPublishers.ofString(requestBodyStr))
                    .build();
            HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

            checkForErrors(response);
            return response;
        } catch (Exception e) {
            throw new HttpRequestException("Failed to execute PUT request", 500);
        }
    }

    public HttpResponse<String> delete(String url) {
        try {
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create(url))
                    .header("Content-Type", "application/json")
                    .DELETE()
                    .build();
            HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

            checkForErrors(response);
            return response;
        } catch (Exception e) {
            throw new HttpRequestException("Failed to execute DELETE request", 500);
        }
    }

    private void checkForErrors(HttpResponse<String> response)
            throws NotFoundException, BadRequestException, HttpRequestException {
        if (response.statusCode() == 404) {
            throw new NotFoundException("Resource not found");
        } else if (response.statusCode() == 400) {
            throw new BadRequestException("Bad request");
        } else if (response.statusCode() >= 500) {
            throw new HttpRequestException("Server error", response.statusCode());
        }
    }
}