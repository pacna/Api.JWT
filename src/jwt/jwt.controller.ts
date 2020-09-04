import { Controller, Get, Post } from '@nestjs/common';
import { JwtService } from './jwt.service';
import { ApiTags } from '@nestjs/swagger';

@ApiTags("jwt")
@Controller("jwt")
export class JwtController {
  constructor(private readonly jwtService: JwtService) {}
  
  @Get()
  getClaims(): string {
    return this.jwtService.getClaims();
  }

  @Post()
  createJwt(): void {
    return this.jwtService.createJwt();
  }
}