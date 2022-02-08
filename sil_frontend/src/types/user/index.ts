interface User {
    id: string,
    name: string,
    email: string,
    twitterHandle: string,
    token: string
}
interface PasswordChangeData {
    userId: string,
    password: string,
}

interface PasswordResetData {
    userEmail: string,
    password: string
}

interface PasswordVerifyData {
    userEmail: string,
    token: string
}

export {
    User,
    PasswordChangeData,
    PasswordResetData,
    PasswordVerifyData
}