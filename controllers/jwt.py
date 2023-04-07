from fastapi import APIRouter, Response, status
from controllers.models.requests.create_jwt_request import CreateClaimsRequest

from controllers.models.responses.claims_response import ClaimsResponse
from controllers.models.responses.jwt_response import JWTResponse
from services.ijwt import IJWTService
from services.jwt import JWTService


service: IJWTService = JWTService()

router: APIRouter = APIRouter(tags=["jwt"], prefix="/jwt")


@router.post("", summary="Create a jwt", response_model=JWTResponse, status_code=status.HTTP_200_OK)
async def create_jwt(request: CreateClaimsRequest) -> JWTResponse:
    return service.create_jwt(request=request)


@router.get("/{token}/claims", summary="Get the claims for a given token", response_model=ClaimsResponse, status_code=status.HTTP_200_OK)
async def get_claims(token: str) -> ClaimsResponse:
    return service.get_claims(token=token)


@router.delete("/{token}", summary="Delete a jwt", status_code=status.HTTP_204_NO_CONTENT)
async def delete_jwt(token: str) -> Response:
    service.delete_jwt(token=token)
    return Response(status_code=status.HTTP_204_NO_CONTENT)
