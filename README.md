# Api JWT

<img alt="Test CI" src="https://github.com/pacna/Api.JWT/workflows/Test%20CI/badge.svg" />

Api JWT is a Python-based service that provides a simple way to create and maintain JSON Web Tokens (JWTs).

## Example

To create a JWT, send a POST request to the API with the keys and values as the payload:

```bash
$ curl --header "Content-Type: application/json" --request POST --data '{"claims": {"foo":"bar"}, "expireAt":"2024-01-03T05:53:25.537Z"}' http://localhost:8000/jwt
```

You should receive a response that contains the JWT:

```
{"jwt":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmb28iOiJiYXIiLCJpc3MiOiJIRUxPIiwiZXhwIjoxNzA0MjYxMjA1LCJqdGkiOiI1YmUyNDQxNS04NGE3LTQ4MmMtOWQzNy04ZmNiMjk4ZWVkMzUifQ.soVA01RmQam2909vK9nIOi5s3p2l-39z8-WmTxZolQo"}
```

## Ubuntu Prerequisites

Before running API JWT, make sure you have the following dependencies installed on your system:

1. [Python](https://www.python.org/downloads/) (python 3.10)
2. [Make](https://www.gnu.org/software/make/)

## Configuration

API JWT uses the following environment variable:

- `ISS`: The issuer of the JWT.

Create a `.env` file in the root directory and add the `ISS` variable:

```python
# .env
ISS = IAMTHEGREATISSUER
```

**Note:** The `ISS` variable is optional. If not provided, a default value will be used.

## Installation

To install the required dependencies, run:

```bash
$ make install
```

## Usage

To run the service locally, use:

```bash
$ make local
```

To run the service in production mode, use:

```bash
$ make run
```

## Running Tests

To run the test, use:

```bash
$ make test
```

**note:** The API currently uses an in-memory data store and does not require a database.
