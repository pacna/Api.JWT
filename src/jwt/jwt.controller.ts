import { Controller, Get, Post, Body } from '@nestjs/common';
import { JwtService } from './jwt.service';
import { ApiTags, ApiBody } from '@nestjs/swagger';
import { CreateClaimsRequest } from './types/create-claims-request';
import { CreateClaimsRequestModel } from './swagger-models/create-claims-request.model';

@ApiTags("jwt")
@Controller("jwt")
export class JwtController {
  constructor(private readonly jwtService: JwtService) {}
  
  @Get()
  getClaims(): string {
    return this.jwtService.getClaims();
  }

  @Post()
  @ApiBody({type: CreateClaimsRequestModel})
  async createJwt(@Body() request: CreateClaimsRequest ): Promise<string> {
    return await this.jwtService.createJwt(request);
  }
}