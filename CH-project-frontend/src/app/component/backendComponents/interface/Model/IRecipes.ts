import { IUser } from "./IUser";

export interface IRecipes{
    Id: number,
    Title: string,
    Image?: string,
    Description: string,
    IUser?: IUser[],
}