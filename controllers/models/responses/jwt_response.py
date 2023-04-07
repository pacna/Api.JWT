from controllers.models.config_base_model import ConfigBaseModel


class JWTResponse(ConfigBaseModel):
    jwt: str
