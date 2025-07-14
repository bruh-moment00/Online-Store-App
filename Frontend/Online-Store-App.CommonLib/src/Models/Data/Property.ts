import { type BaseEntity } from "./Base/BaseEntity";

export interface Property extends BaseEntity {
    categoryId: number;
    propName: string;
    valueType: number;
}

export interface PropertyForPost {
    categoryID: number;
    propName: String;
    valueType: number;
}

export interface PropertyForPut {
    id: number
    categoryID: number;
    propName: String;
    valueType: number;
}
