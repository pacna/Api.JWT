// third party libs
import { IsDateString, IsNotEmptyObject } from 'class-validator';

export class CreateClaimsRequest {
  @IsNotEmptyObject()
  claims: object;

  @IsDateString()
  expirationDate: string;
}
