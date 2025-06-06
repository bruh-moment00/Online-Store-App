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