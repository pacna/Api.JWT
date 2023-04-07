from datetime import datetime

from controllers.models.config_base_model import ConfigBaseModel


class CreateClaimsRequest(ConfigBaseModel):
    claims: dict[str, str]
    expireAt: datetime
