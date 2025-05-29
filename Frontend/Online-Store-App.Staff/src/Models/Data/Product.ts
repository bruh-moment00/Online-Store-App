import { type BaseEntity } from "./Base/BaseEntity";

export interface Product extends BaseEntity {
    Name: string;
    Description: string;
    CategoryID: number;
    Price: number;
}