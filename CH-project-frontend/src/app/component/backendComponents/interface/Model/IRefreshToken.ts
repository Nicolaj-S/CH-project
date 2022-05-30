export interface IRefreshToken{
  Token: string,
  Expires : Date,
  Created : Date,
  CreatedByIp: string,
  Revoked : Date,
  RevokedByIp : string,
  ReplaceByToken : string,
  ReasonRevoked : string,
}
