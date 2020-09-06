// nestjs
import { ApiProperty, ApiPropertyOptional } from "@nestjs/swagger";

export class CreateClaimsRequestModel {
    @ApiProperty()
    claims: object;

    @ApiProperty({
        type: 'string',
        format: 'date-time'
    })
    expirationDate: string;
}