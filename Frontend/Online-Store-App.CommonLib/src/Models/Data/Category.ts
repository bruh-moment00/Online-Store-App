import { type BaseEntity } from "./Base/BaseEntity";

export interface Category extends BaseEntity {
    name: string;
}

export interface CategoryForPost {
    name: string;
}