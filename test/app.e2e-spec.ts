// nestjs
import { Test, TestingModule } from '@nestjs/testing';
import { INestApplication } from '@nestjs/common';

// third party libs
import * as request from 'supertest';

// module
import { AppModule } from './../src/app.module';

describe('JwtController (e2e)', () => {
  let app: INestApplication;

  beforeEach(async () => {
    const moduleFixture: TestingModule = await Test.createTestingModule({
      imports: [AppModule],
    }).compile();

    app = moduleFixture.createNestApplication();
    await app.init();
  });

  it('/ (GET)', () => {
    const token: string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmb28iOiJmb28iLCJpYXQiOjE1OTkzNDYzMzMsImlzcyI6ImFwaS5qd3QiLCJqdGkiOiI3YnVlMHM1dzVrZXE5aWd2ZCJ9.yaXJqTWhLGtL0KYfCnTJDp1z2zEHzQL53JlGXiNpFdY';
    return request(app.getHttpServer())
      .get(`/jwt/${token}/claims`)
      .expect(200)
  });
});
