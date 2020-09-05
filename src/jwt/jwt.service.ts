import { Injectable } from '@nestjs/common';
import { CreateClaimsRequest } from './types/create-claims-request';
import * as jwt from 'jsonwebtoken';
import * as uid from 'uniqid';
import * as hash from 'object-hash';
import * as dotenv from 'dotenv';

dotenv.config();

@Injectable()
export class JwtService {

  getClaims(): string {
    return 'Hello World!';
  }

  async createJwt(request: CreateClaimsRequest): Promise<string> {
    const issuer: string = process.env.ISSUER || 'api.jwt';
    const key: string = hash(issuer);
    return new Promise((resolve: Function, reject: Function) => {
        jwt.sign(request, key, { jwtid: uid(), issuer }, (error: any, token: string) => {
            if(error) {
                return reject('oops')
            }
            return resolve(token);
        })
    })
  }
}