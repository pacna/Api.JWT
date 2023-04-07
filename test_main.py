from datetime import datetime
from json import loads
from typing import Any
from fastapi.testclient import TestClient
from fastapi import status
from httpx import Response
from controllers.models.requests.create_jwt_request import CreateClaimsRequest
from main import app
from controllers import jwt
from mocks.jwt import TestJWTService

test_client: TestClient = TestClient(app)
jwt.service = TestJWTService()

fake_jwt: str = "myprecioustoken"


def test_get_root() -> None:
    # ACT
    response: Response = test_client.get(url="/")

    # ASSERT
    assert (response.status_code == status.HTTP_200_OK)


def test_get_claims_by_jwt() -> None:
    # ARRANGE
    expected_response: dict[str, dict[str, Any]] = {'claims': {'foo': 'bar'}}

    # ACT
    response: Response = test_client.get(url=f"/jwt/{fake_jwt}/claims")

    # ASSERT
    assert (response.status_code == status.HTTP_200_OK)
    assert (response.json() == expected_response)


def test_create_jwt() -> None:
    # ARRANGE
    expected_response: dict[str, str] = {'jwt': fake_jwt}
    request: CreateClaimsRequest = CreateClaimsRequest(
        claims={'foo': 'bar'}, expireAt=datetime.utcnow())

    # ACT
    response: Response = test_client.post(
        url="/jwt", json=loads(request.json()))

    # ASSERT
    assert (response.status_code == status.HTTP_200_OK)
    assert (response.json() == expected_response)


def test_delete_jwt() -> None:
    # ACT
    response: Response = test_client.delete(url=f'jwt/{fake_jwt}')

    # ASSERT
    assert (response.status_code == status.HTTP_204_NO_CONTENT)
