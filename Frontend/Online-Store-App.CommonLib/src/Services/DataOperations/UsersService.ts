import { http } from "../../http";
import { Password } from "../../Models/Data/Password";
import { User, UserForPost, UserForPut } from "../../Models/Data/User";

export const getUserById = async (
    userId: number
): Promise<User | null> => {
    const result = await http<User>({
        path: `users/${userId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const postUser = async (
    user: UserForPost
): Promise<number | undefined> => {
    const result = await http<number, UserForPost>({
        path: "users",
        method: "post",
        body: user
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const putUser = async (
    user: UserForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, UserForPut>({
        path: `users/${user.id}`,
        method: "put",
        body: user
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const changePassword = async (
    password: Password
): Promise<boolean | undefined> => {
    const result = await http<boolean, Password>({
        path: `users/${password.id}/password`,
        method: "put",
        body: password
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deleteUser = async (
    userId: number
): Promise<number | null> => {
    const result = await http<number>({
        path: `users/${userId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}
