package com.Transactions.Transactions.Service;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import com.fasterxml.jackson.databind.ObjectMapper;

public class HttpService {
    private final HttpClient client;
    private final ObjectMapper objectMapper;

    public HttpService() {
        this.client = HttpClient.newHttpClient();
        this.objectMapper = new ObjectMapper();
    }

    public HttpResponse<String> post(String url, Object requestBody) throws Exception {
        String requestBodyStr = objectMapper.writeValueAsString(requestBody);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(url))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(requestBodyStr))
                .build();

        return client.send(request, HttpResponse.BodyHandlers.ofString());
    }
}