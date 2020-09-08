// nestjs
import { 
  Injectable,
  BadRequestException,
  PreconditionFailedException 
} from '@nestjs/common';

// types
import { CreateClaimsRequest } from './types/create-claims-request';
import { ClaimsResponse } from './types/claims-response';

// third party libs
import * as jwt from 'jsonwebtoken';
import * as uid from 'uniqid';
import * as hash from 'object-hash';
import * as dotenv from 'dotenv';
import * as moment from 'moment';

dotenv.config();

@Injectable()
export class JwtService {
  issuer: string = process.env.ISSUER || 'api.jwt';
  key: string = hash(this.issuer);

  async getClaims(token: string): Promise<ClaimsResponse> {
    return new Promise((resolve: Function, reject: Function) => {
      jwt.verify(token, this.key, (error: any, decoded: ClaimsResponse) => {
          if (error) {
            // throw a 400 to handle any error messages
            throw new BadRequestException(error.message);          
          }
          return resolve(decoded);
      })
    })
  }

  async createJwt(request: CreateClaimsRequest): Promise<string> {
    const {
      expirationDate,
      claims
    } = request;

    if (this.isValidTime(expirationDate)) {
      return new Promise((resolve: Function, reject: Function) => {
          jwt.sign(claims, this.key, { 
            jwtid: uid(), 
            issuer: this.issuer,
            expiresIn: this.setTimeToExpire(expirationDate)
           }, (error: any, token: string) => {
              if(error) {
                throw new BadRequestException(error.message)
              }
              return resolve(token);
          })
      })
    } else {
      throw new PreconditionFailedException('Time is set in the past');
    }

  }

  setTimeToExpire(expirationDate: string): number {
    const expireTime: number = moment(expirationDate).unix();
    const currentTime: number = moment().unix();
  
    return expireTime - currentTime;
  }

  isValidTime(expirationDate: string): boolean {
    const expireTime: number = moment(expirationDate).unix();
    const currentTime: number = moment().unix();

    return expireTime > currentTime;
  }
}