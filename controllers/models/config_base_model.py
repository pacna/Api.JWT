from pydantic.main import BaseModel


class ConfigBaseModel(BaseModel):
    class Config:
        populate_by_name = True
