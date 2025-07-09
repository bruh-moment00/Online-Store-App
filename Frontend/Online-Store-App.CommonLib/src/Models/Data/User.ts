import type { BaseEntity } from "./Base/BaseEntity";

export interface User extends BaseEntity {
    FirstName: string;
    LastName: string;
    PhoneNum: string;
    Email: string;
    Gender: boolean;
    BirthDate: Date;
    Login: string;
}