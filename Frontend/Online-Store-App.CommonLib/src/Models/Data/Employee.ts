import { type BaseEntity } from "./Base/BaseEntity";

export interface Employee extends BaseEntity {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean;
    birthDate: Date;
    login: Date;
}

export interface EmployeeForPost {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: boolean;
    birthDate: Date;
    login: Date;
    password: string;
} 