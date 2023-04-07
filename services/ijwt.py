from typing import Protocol
from controllers.models.requests.create_jwt_request import CreateClaimsRequest

from controllers.models.responses.claims_response import ClaimsResponse
from controllers.models.responses.jwt_response import JWTResponse


class IJWTService(Protocol):
    def get_claims(self, token: str) -> ClaimsResponse:
        ...

    def create_jwt(self, request: CreateClaimsRequest) -> JWTResponse:
        ...

    def delete_jwt(self, token: str) -> None:
        ...
