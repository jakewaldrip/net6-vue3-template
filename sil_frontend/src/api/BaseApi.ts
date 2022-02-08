import { AxiosResponse } from "axios";
import router from "@/router";

const BuildUrl = (route: string) => {
    return `${process.env.VUE_APP_BASE_URL}/${route}`
}

function HandleResponse<T>(response: AxiosResponse<any, any>) {
    const data = response.data;
    if(response.status === 401) {
        localStorage.removeItem('user');
        router.push({ path: '/login' });
    }

    return data as T;
}

export {
    BuildUrl,
    HandleResponse
}