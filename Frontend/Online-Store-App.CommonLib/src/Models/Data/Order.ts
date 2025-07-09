import type { ListDataWithPaging } from "../ListDataWithPaging";
import { type BaseEntity } from "./Base/BaseEntity";

export interface Order extends BaseEntity {
    totalPrice: number;
    userId: number;
    status: number;
}

export interface OrderDataWithPaging extends ListDataWithPaging {
    items: Order[];
}

export interface OrderForPost {
    totalPrice: number;
    userId: number;
    status: number;
}

export interface OrderForPut {
    totalPrice: number;
    userId: number;
    status: number;
}