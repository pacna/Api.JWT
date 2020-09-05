import { IsDateString } from 'class-validator';

export class CreateClaimsRequest {
    @IsDateString()
    expirationDate: string;
}