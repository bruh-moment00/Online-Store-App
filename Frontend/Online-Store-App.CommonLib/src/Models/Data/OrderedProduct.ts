import { type ConnectEntity } from "./Base/ConnectEntity";

export interface OrderedProduct extends ConnectEntity {
    orderID: number;
    productID: number;
    priceWhenAdded: number;
}

export interface OrderedProductForPost {
    orderID: number;
    productID: number;
}