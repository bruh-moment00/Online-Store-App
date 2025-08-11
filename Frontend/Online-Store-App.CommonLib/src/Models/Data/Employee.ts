import { type BaseEntity } from "./Base/BaseEntity";

export interface Employee extends BaseEntity {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean | undefined;
    birthDate: Date;
    login: string;
}

export interface EmployeeForPost {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean | undefined;
    birthDate: Date;
    login: string;
    password: string;
    passwordConfirm: string;
} 

export interface EmployeeForPut {
    id: number;
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean | undefined;
    birthDate: Date;
    login: string;
} 