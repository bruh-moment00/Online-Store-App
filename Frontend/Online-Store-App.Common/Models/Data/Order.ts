import { OrderStatus } from "@/Enums/OrderStatus";
import { Double } from "react-native/Libraries/Types/CodegenTypes";
import { BaseEntity } from "./Base/BaseEntity";

export interface Order extends BaseEntity {
    TotalPrice: Double;
    UserID: number;
    Status: OrderStatus;
}