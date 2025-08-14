import type { ListDataWithPaging } from "../ListDataWithPaging";
import { type BaseEntity } from "./Base/BaseEntity";

export interface Order extends BaseEntity {
    totalPrice: number;
    userID: number;
    status: number;
}

export interface OrderDataWithPaging extends ListDataWithPaging {
    items: Order[];
}

export interface OrderForPut {
    id: number;
    userID: number;
    status: number;
}