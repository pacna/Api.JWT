from typing import Any, Protocol


class IJWTRepository(Protocol):
    def get_claims(self, token: str) -> dict[str, Any]:
        ...

    def add_jwt(self, token: str, claims: dict[str, Any]) -> None:
        ...

    def delete_jwt(self, token: str) -> None:
        ...
