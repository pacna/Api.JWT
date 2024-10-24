# Api JWT

<img alt="Test CI" src="https://github.com/pacna/Api.JWT/workflows/Test%20CI/badge.svg" />

Api JWT is a RESTful service that simplifies the generation and management of JSON Web Tokens (JWTs).

## Example

To create a JWT, send a POST request to the API with the keys and values as the payload:

```bash
$ curl --header "Content-Type: application/json" --request POST --data '{"claims": {"foo":"bar"}, "expireAt":"2024-01-03T05:53:25.537Z"}' http://localhost:5000/api/v1/jwt
```

You should receive a response that contains the JWT:

```json
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJmb28iOiJiYXIiLCJqdGkiOiJkMjAwY2E4NS05MDk1LTQyYWItOTE2OS1mYTZlY2Q2NTVhMDgiLCJleHAiOjE3MzU4ODM2MDUsImlzcyI6IkFwaS5KV1QifQ.CeZqhdjJFB8As0jn09UezuM8zpD0Z0d7Ye6S3RESUkg
```

## Prerequisites

Before running API JWT, make sure you have the following dependencies installed on your system:

-   [.NET Core](https://dotnet.microsoft.com/en-us/download) (v8)

## How to Run Locally

Follow the commands below to start the service:

1. To run the service:

```bash
$ dotnet run --project=./src/Api.JWT
```

2. To run the service in watch mode:

```bash
$ dotnet watch run --project=./src/Api.JWT
```

## Running Tests

To run the test, use:

```bash
$ dotnet test
```

**note:** The API currently uses an in-memory data store and does not require a database.
