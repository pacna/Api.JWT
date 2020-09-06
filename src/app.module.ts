// nestjs
import { Module } from '@nestjs/common';

// modules
import { JwtModule } from './jwt/jwt.module';

@Module({
  imports: [JwtModule],
  controllers: [],
  providers: []
})

export class AppModule {}