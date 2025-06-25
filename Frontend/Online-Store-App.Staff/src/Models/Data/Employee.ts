import { type BaseEntity } from "./Base/BaseEntity";

export interface Employee extends BaseEntity {
    FirstName: string;
    LastName: string;
    PhoneNum: string;
    Email: string;
    Gender: boolean;
    BirthDate: Date;
    Login: Date;
}

export interface EmployeeForPost {
    FirstName: string;
    LastName: string;
    PhoneNum: string;
    Email: string;
    Gender: boolean;
    BirthDate: Date;
    Login: Date;
    Password: string;
} 