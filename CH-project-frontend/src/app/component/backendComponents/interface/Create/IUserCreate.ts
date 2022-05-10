export interface CreateUser{
    Username: string,
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
    ProfilePicture: string,
    Admin: boolean,
    Cart?: number[],
    Blogs?: number[],
    Recipes?: number[],
}