from datetime import datetime
from typing import Any

from fastapi import HTTPException, status
from controllers.models.requests.create_jwt_request import CreateClaimsRequest
from controllers.models.responses.claims_response import ClaimsResponse
from controllers.models.responses.jwt_response import JWTResponse
from repositories.ijwt import IJWTRepository
from repositories.inmemory_jwt import InMemoryJwtRepository
from services.helpers.jwt import append_require_claims, create_jwt, is_valid

repo: IJWTRepository = InMemoryJwtRepository()


class JWTService:
    def __init__(self) -> None:
        pass

    def get_claims(self, token: str) -> ClaimsResponse:
        claims: dict[str, Any] = repo.get_claims(token=token)
        if is_valid(jwt=token):
            return ClaimsResponse(claims=claims)
        # either add a scheduler to do this or have some sort of TTL
        repo.delete_jwt(token=token)
        return ClaimsResponse(claims={})

    def create_jwt(self, request: CreateClaimsRequest) -> JWTResponse:
        self.__throw_if_invalid(request.expireAt)
        claims: dict[str, Any] = append_require_claims(request=request)
        jwt: str = create_jwt(claims=claims)
        repo.add_jwt(token=jwt, claims=claims)
        return JWTResponse(jwt=jwt)

    def delete_jwt(self, token: str) -> None:
        repo.delete_jwt(token=token)

    def __throw_if_invalid(self, expireAt: datetime) -> None:
        if expireAt.replace(tzinfo=None) < datetime.now():
            raise HTTPException(
                status_code=status.HTTP_412_PRECONDITION_FAILED, detail="Time is set in the past")
        return
