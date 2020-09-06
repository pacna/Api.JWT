// nestjs
import { Module } from '@nestjs/common';

// controller
import { JwtController } from './jwt.controller';

// services
import { JwtService } from './jwt.service';

@Module({
  imports: [],
  controllers: [JwtController],
  providers: [JwtService],
})

export class JwtModule {}