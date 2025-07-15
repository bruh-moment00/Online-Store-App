import type { BaseEntity } from "./Base/BaseEntity";

export interface User extends BaseEntity {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean;
    birthDate: Date;
    login: string;
}