import { ICart } from "./ICart";

export interface IShop{
    Id: number,
    ItemName: string,
    Image: string
    Description: string,
    ICart?: ICart[]
}