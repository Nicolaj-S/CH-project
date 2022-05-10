import { ICart } from "./ICart";
import { IBlog } from "./IBlog";
import { IRecipes } from "./IRecipes";

export interface IUser{
    Username: string,
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
    ProfilePicture: string,
    Admin: boolean,
    ICart?: ICart[],
    IBlog?: IBlog[],
    IRecipes?: IRecipes[],
}