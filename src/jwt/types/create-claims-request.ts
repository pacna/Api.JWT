// third party libs
import { IsDateString, IsNotEmptyObject, IsNotEmpty } from 'class-validator';

export class CreateClaimsRequest {
    @IsNotEmptyObject()
    claims: object;

    @IsDateString()
    expirationDate: string;
}