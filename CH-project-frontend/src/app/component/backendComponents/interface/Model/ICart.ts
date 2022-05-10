import { IUser } from "./IUser";
import { IShop } from "./IShop";

export interface ICart{
    Id: number,
    IUser?: IUser[],
    IShop?: IShop[],
}