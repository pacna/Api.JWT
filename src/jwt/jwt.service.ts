import { Injectable } from '@nestjs/common';
import { CreateClaimsRequest } from './types/create-claims-request';
import { ClaimsResponse } from './types/claims-response';
import * as jwt from 'jsonwebtoken';
import * as uid from 'uniqid';
import * as hash from 'object-hash';
import * as dotenv from 'dotenv';

dotenv.config();

@Injectable()
export class JwtService {
  issuer: string = process.env.ISSUER || 'api.jwt';
  key: string = hash(this.issuer);

  async getClaims(token: string): Promise<ClaimsResponse> {
    return new Promise((resolve: Function, reject: Function) => {
      jwt.verify(token, this.key, (error: any, decoded: ClaimsResponse) => {
          if (error) {
            return reject('oops')
          }
          return resolve(decoded);
      })
    })
  }

  async createJwt(request: CreateClaimsRequest): Promise<string> {
    const {
      expirationDate,
      ...claims
    } = request;
    return new Promise((resolve: Function, reject: Function) => {
        jwt.sign(claims, this.key, { jwtid: uid(), issuer: this.issuer }, (error: any, token: string) => {
            if(error) {
                return reject('oops')
            }
            return resolve(token);
        })
    })
  }
}