import { ApiProperty, ApiPropertyOptional } from "@nestjs/swagger";

export class CreateClaimsRequestModel {
    @ApiProperty({
        description: 'a placeholder for a claim'
    })
    claim1: string;

    @ApiProperty({
        type: 'string',
        format: 'date-time'
    })
    expirationDate: string;
}