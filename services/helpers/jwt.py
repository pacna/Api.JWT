from typing import Any
from uuid import uuid4
from dotenv import dotenv_values
from jwt import encode, decode

from controllers.models.requests.create_jwt_request import CreateClaimsRequest
from services.constants.claim_keys import ClaimKeys

config: dict[str, str | None] = dotenv_values('.env')


def append_require_claims(request: CreateClaimsRequest) -> dict[str, Any]:
    claims: dict[str, Any] = request.claims
    claims[ClaimKeys.ISSUER] = _get_iss()
    claims[ClaimKeys.EXPIRATION_TIME] = int(request.expireAt.timestamp())
    claims[ClaimKeys.JWTID] = str(uuid4())
    return claims


def create_jwt(claims: dict[str, Any]) -> str:
    return encode(payload=claims, key=_get_iss())


def is_valid(jwt: str) -> bool:
    try:
        claims = decode(jwt=jwt, key=_get_iss(), algorithms=['HS256'])
        return bool(claims)
    except:
        return False


def _get_iss() -> str:
    try:
        return config.get('ISS') or 'Api.JWT'
    except:
        return 'Api.JWT'
