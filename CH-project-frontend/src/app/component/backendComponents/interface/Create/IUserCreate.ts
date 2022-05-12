export interface CreateUser{
    Username: string,
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
    ProfilePicture: string,
    Admin: boolean,
    Blogs?: number[],
    Recipes?: number[],
}