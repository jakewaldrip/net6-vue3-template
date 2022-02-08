import axios, { AxiosRequestHeaders } from "axios"

import { BuildUrl } from "@/api/BaseApi"
import { User } from "@/types/user"
import router from "@/router"

const IsAuthenticated = (): boolean => {
    const user = localStorage.getItem('user');
    return !!(user && user.length > 0);
}

const Login = async (email: string, password: string) => {
    const requestParams = { email, password };
    const result = await axios.post(BuildUrl('user/authenticate'), requestParams);

    if(result.status === 401) {
        return result.status;
    }
    
    const user: User = result.data as User;
    if(user.token) {
        localStorage.setItem('user', JSON.stringify(user));
    }

    return result.status;
}

const RefreshUserCache = async (userId: string | null): Promise<User> => {
    if(userId === null) {
        return {} as User;
    }
    const requestParams = { "id": userId };
    const result = await axios.post(BuildUrl('user'), requestParams, { headers: GetAuthHeader() });
    if(result.status === 401) {
        Logout();
        return {} as User;
    }

    const user: User = result.data as User;
    const currentUser = localStorage.getItem('user');
    if(currentUser) {
        const parsedUser = JSON.parse(currentUser) as User;
        user.token = parsedUser.token;
        localStorage.setItem('user', JSON.stringify(user));
    }
    return user;
}

const Logout = () => {
    localStorage.removeItem('user');
    router.push({ path: '/login' });
}

const Register = async (email: string, twitterHandle: string, name: string, password: string) => {
    const requestParams = { email, twitterHandle, name, password };
    const result = await axios.post(BuildUrl('user/register'), requestParams);
    return result.status;
}

const GetAuthHeader = (): AxiosRequestHeaders => {
    const user = GetUser();
    
    if(user && user.token) {
        return { 
            'Authorization': `Bearer ${user.token}`,
            'Content-Type': 'application/json'
        };
    }

    return {};
}

const GetUser = (): User | null => {
    const userJson = localStorage.getItem('user');
    if(!userJson) {
        return null;
    }

    const user: User = JSON.parse(userJson) as User;
    return user ? user : null;
}

const publicPages: string[] = ['/login', '/Register', '/logout', '/', '/ForgotPassword', '/ResetPassword'];

export { 
    Login, 
    Logout,
    Register,
    GetAuthHeader,
    IsAuthenticated,
    publicPages,
    GetUser,
    RefreshUserCache
}