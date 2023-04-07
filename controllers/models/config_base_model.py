from pydantic import BaseModel


class ConfigBaseModel(BaseModel):
    class Config:
        allow_population_by_field_name = True
