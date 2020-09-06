// nestjs
import { Test, TestingModule } from '@nestjs/testing';

// controller
import { JwtController } from './jwt.controller';

// services
import { JwtService } from './jwt.service';

// types
import { CreateClaimsRequest } from './types/create-claims-request';
import { ClaimsResponse } from './types/claims-response';

describe('JwtController', () => {
  let jwtController: JwtController;
  let jwtService: JwtService;

  beforeEach(async () => {
    const app: TestingModule = await Test.createTestingModule({
      controllers: [JwtController],
      providers: [JwtService],
    }).compile();

    jwtController = app.get<JwtController>(JwtController);
  });

  beforeEach(async () => {
    jwtService = new JwtService();
    jwtController = new JwtController(jwtService);
  })

  describe('jwt endpoint', () => {
    it('should create a jwt', async() => {
      // ARRANGE
      const token = "myprecioustoken";
      const request = new CreateClaimsRequest();
      request.claims = {
        foo: 'foo'
      };
      request.expirationDate = new Date().toISOString();
      jest.spyOn(jwtService, 'createJwt').mockImplementation(async () =>  token);

      // ACT
      const response: string = await jwtController.createJwt(request);

      // ASSERT
      expect(response).toBe(token);
    });

    it('should retrieve claims from jwt', async() => {
      // ARRANGE
      const claims = new ClaimsResponse()
      claims.iat = 1000
      claims.jti = '1',
      claims.iss = 'the-chosen-one'

      const token: string = 'myprecioustoken';

      jest.spyOn(jwtService, 'getClaims').mockImplementation(async () => claims);

      // ACT
      const response: ClaimsResponse = await jwtController.getClaims(token);

      // ASSERT
      expect(response).toBe(claims);
    })
  });
});