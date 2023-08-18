from typing import Any, Dict
from fastapi import FastAPI
from fastapi.responses import RedirectResponse
from fastapi.openapi.utils import get_openapi
from uvicorn import Config, Server

from controllers.jwt import router

app = FastAPI()
app.include_router(router)


@app.get("/", include_in_schema=False)
def root() -> RedirectResponse:
    return RedirectResponse(url="/docs")


def custom_openapi() -> Dict[str, Any]:
    if app.openapi_schema:
        return app.openapi_schema
    openapi_schema = get_openapi(
        title="Api.JWT",
        version="0.0.1",
        description="A simple JWT (JSON Web Token) service",
        routes=app.routes
    )
    app.openapi_schema = openapi_schema
    return app.openapi_schema


app.openapi = custom_openapi


if __name__ == "__main__":
    print('Starting Api.JWT')
    server = Server(Config("main:app", port=8000, log_level="info"))
    server.run()
