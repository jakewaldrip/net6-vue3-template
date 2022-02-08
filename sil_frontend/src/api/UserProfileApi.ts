import { BuildUrl, HandleResponse } from "@/api/BaseApi";
import { PasswordChangeData, PasswordResetData, PasswordVerifyData, User } from "@/types/user";

import { GetAuthHeader } from "@/auth/authentication";
import axios from "axios";

const SaveUserProfile = async (user: User) => {
    const url = BuildUrl("user/profile");
    return await axios.post(url, user, {
        headers: GetAuthHeader()
    });

    
}

const SaveChangedPassword = async (passwordData: PasswordChangeData) => {
    const url = BuildUrl("user/password");
    return await axios.post(url, passwordData, {
        headers: GetAuthHeader(),
    });

}

const TriggerPasswordReset = async (userEmail: string) => {
    const url = BuildUrl("ResetPassword/create");
    return await axios.post(url, { userEmail }, {
        headers: GetAuthHeader(),
    });

}

const VerifyResetPassword = async (passwordData: PasswordVerifyData) => {
    const url = BuildUrl("ResetPassword/verify");
    return await axios.post(url, passwordData, {
        headers: GetAuthHeader(),
    });

}

const SaveResetPassword = async (passwordData: PasswordResetData) => {
    const url = BuildUrl("ResetPassword/change");
    return await axios.post(url, passwordData, {
        headers: GetAuthHeader(),
    });

}

export {
    SaveUserProfile,
    SaveChangedPassword,
    TriggerPasswordReset,
    VerifyResetPassword,
    SaveResetPassword
}