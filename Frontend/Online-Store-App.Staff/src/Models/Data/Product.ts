import type { ListDataWithPaging } from "../ListDataWithPaging";
import { type BaseEntity } from "./Base/BaseEntity";

export interface Product extends BaseEntity {
    name: string;
    description: string;
    categoryID: number;
    price: number;
}

export interface ProductDataWithPaging extends ListDataWithPaging {
    items: Product[];
}

export interface ProductForPost {
    name: string;
    description: string;
    categoryId: number;
    price: number;
}