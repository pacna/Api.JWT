import { Test, TestingModule } from '@nestjs/testing';
import { JwtController } from './jwt.controller';
import { JwtService } from './jwt.service';

describe('JwtController', () => {
  let jwtController: JwtController;

  beforeEach(async () => {
    const app: TestingModule = await Test.createTestingModule({
      controllers: [JwtController],
      providers: [JwtService],
    }).compile();

    jwtController = app.get<JwtController>(JwtController);
  });

  describe('jwt endpoint', () => {
    it('should return "Hello World!"', () => {
      expect(jwtController.getClaims()).toBe('Hello World!');
    });
  });
});