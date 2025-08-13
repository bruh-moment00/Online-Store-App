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
    lastName: string | undefined;
    phoneNum: string | undefined;
    email: string | undefined;
    gender: boolean | undefined;
    birthDate: Date | undefined;
    login: string;
    password: string;
    confirmPassword: string;
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