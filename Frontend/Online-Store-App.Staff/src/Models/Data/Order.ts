import { OrderStatus } from "../../Enums/OrderStatus";
import { type BaseEntity } from "./Base/BaseEntity";

export interface Order extends BaseEntity {
    TotalPrice: number;
    UserID: number;
    Status: OrderStatus;
}