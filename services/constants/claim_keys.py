from strenum import StrEnum


class ClaimKeys(StrEnum):
    ISSUER = 'iss'
    JWTID = 'jti'
    EXPIRATION_TIME = 'exp'
