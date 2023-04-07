from typing import Any
from controllers.models.config_base_model import ConfigBaseModel


class ClaimsResponse(ConfigBaseModel):
    claims: dict[str, Any]
