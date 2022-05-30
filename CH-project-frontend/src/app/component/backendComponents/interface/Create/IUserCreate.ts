export interface CreateUser{
    Username: string,
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
    Admin: boolean,
    Blogs?: number[],
    Recipes?: number[],
    IRefreshToken? : number,
}
