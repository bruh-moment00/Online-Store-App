import { type BaseEntity } from "./Base/BaseEntity";

export interface Property extends BaseEntity {
    CategoryID: number;
    PropName: String;
    ValueType: number;
}

export interface PropertyForPost {
    CategoryID: number;
    PropName: String;
    ValueType: number;
}

export interface PropertyForPut {
    ID: number
    CategoryID: number;
    PropName: String;
    ValueType: number;
}
