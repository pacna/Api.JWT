// nestjs
import { ApiProperty } from "@nestjs/swagger";

export class ClaimsResponseModel {
    @ApiProperty({
        description: 'a placeholder for a claim'
    })
    claim1: string;

    @ApiProperty()
    jti: string;

    @ApiProperty()
    iat: number;

    @ApiProperty()
    iss: string;

    @ApiProperty()
    exp: number;
}