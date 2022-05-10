import { IUser } from "./IUser";

export interface IBlog{
    Id: number,
    Header: string,
    Date: Date,
    Description: string,
    IUser?: IUser[]
}