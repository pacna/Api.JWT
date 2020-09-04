import { Injectable } from '@nestjs/common';

@Injectable()
export class JwtService {

  getClaims(): string {
    return 'Hello World!';
  }

  createJwt(): void {
    console.log('hi');
  }
}