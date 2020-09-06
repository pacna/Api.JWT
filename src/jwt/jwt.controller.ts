// nestjs
import { Controller, Get, Post, Body, Param } from '@nestjs/common';
import { ApiTags, ApiBody, ApiParam, ApiResponse } from '@nestjs/swagger';

// swagger model
import { CreateClaimsRequestModel } from './swagger-models/create-claims-request.model';
import { ClaimsResponseModel } from './swagger-models/claims-response.model';

// types
import { ClaimsResponse } from './types/claims-response';
import { CreateClaimsRequest } from './types/create-claims-request';

// services
import { JwtService } from './jwt.service';

@ApiTags("jwt")
@Controller("jwt")
export class JwtController {
  constructor(private readonly jwtService: JwtService) {}
  
  @Get("/:jwt/claims")
  @ApiParam({name: 'jwt'})
  @ApiResponse({ status: 200, type: ClaimsResponseModel})
  async getClaims(@Param('jwt') token: string): Promise<ClaimsResponse> {
    return this.jwtService.getClaims(token);
  }

  @Post()
  @ApiResponse({ status: 201, type: String})
  @ApiBody({type: CreateClaimsRequestModel})
  async createJwt(@Body() request: CreateClaimsRequest ): Promise<string> {
    return await this.jwtService.createJwt(request);
  }
}