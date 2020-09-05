import { ApiProperty, ApiPropertyOptional } from "@nestjs/swagger";

export class CreateClaimsRequestModel {
    @ApiProperty()
    claim1: string;

    @ApiProperty({
        type: 'string',
        format: 'date-time'
    })
    expirationDate: string;
}