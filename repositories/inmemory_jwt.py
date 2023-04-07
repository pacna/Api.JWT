from typing import Any


inmemory_jwt: dict[str, dict[str, Any]] = {}


class InMemoryJwtRepository:
    def __init__(self) -> None:
        pass

    def get_claims(self, token: str) -> dict[str, Any]:
        try:
            return inmemory_jwt[token]
        except Exception:
            return {}

    def add_jwt(self, token: str, claims: dict[str, Any]) -> None:
        inmemory_jwt[token] = claims

    def delete_jwt(self, token: str) -> None:
        try:
            inmemory_jwt.pop(token)
        finally:
            return
