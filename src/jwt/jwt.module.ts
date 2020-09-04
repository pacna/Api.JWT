import { Module } from '@nestjs/common';

import { JwtController } from './jwt.controller';
import { JwtService } from './jwt.service';

@Module({
  imports: [],
  controllers: [JwtController],
  providers: [JwtService],
})

export class JwtModule {}