from controllers.models.requests.create_jwt_request import CreateClaimsRequest
from controllers.models.responses.claims_response import ClaimsResponse
from controllers.models.responses.jwt_response import JWTResponse


class TestJWTService:
    def get_claims(self, token: str) -> ClaimsResponse:
        return ClaimsResponse(claims={"foo": "bar"})

    def create_jwt(self, request: CreateClaimsRequest) -> JWTResponse:
        return JWTResponse(jwt="myprecioustoken")

    def delete_jwt(self, token: str) -> None:
        return
