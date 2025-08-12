import type { BaseEntity } from "./Base/BaseEntity";

export interface User extends BaseEntity {
    firstName: string;
    lastName: string | undefined;
    phoneNum: string;
    email: string | undefined;
    gender: boolean | undefined;
    birthDate: Date | undefined;
    login: string | undefined;
}

export interface UserForPost {
    firstName: string;
    lastName: string | undefined;
    phoneNum: string;
    email: string | undefined;
    gender: boolean | undefined;
    birthDate: Date | undefined;
    login: string | undefined;
    password: string;
    confirmPassword: string;
}

export interface UserForPut {
    id: number;
    firstName: string;
    lastName: string | undefined;
    phoneNum: string;
    email: string | undefined;
    gender: boolean | undefined;
    birthDate: Date | undefined;
    login: string | undefined;
}