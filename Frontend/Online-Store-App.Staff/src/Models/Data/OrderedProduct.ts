import { type ConnectEntity } from "./Base/ConnectEntity";

export interface OrderedProduct extends ConnectEntity {
    OrderID: number;
    ProductID: number;
}