import { IBlog } from "./IBlog";
import { IRecipes } from "./IRecipes";
import { IRefreshToken } from "./IRefreshToken";

export interface IUser{
    Username: string,
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
    ProfilePicture: string,
    Admin: boolean,
    IBlog?: IBlog[],
    IRecipes?: IRecipes[],
    IRefreshToken? : IRefreshToken,
}
