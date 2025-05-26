import { BaseEntity } from "./Base/BaseEntity";

export interface Permission extends BaseEntity {
    Name: string;
    Description: string;
}