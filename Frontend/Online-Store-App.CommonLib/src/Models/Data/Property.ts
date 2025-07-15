import { type BaseEntity } from "./Base/BaseEntity";

export interface Property extends BaseEntity {
    categoryID: number;
    propName: string;
    valueType: number;
}

export interface PropertyForPost {
    categoryID: number;
    propName: string;
    valueType: number;
}

export interface PropertyForPut {
    id: number
    categoryID: number;
    propName: string;
    valueType: number;
}
