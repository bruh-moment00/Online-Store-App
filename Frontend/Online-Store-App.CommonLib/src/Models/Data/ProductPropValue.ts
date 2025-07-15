import { type ConnectEntity } from "./Base/ConnectEntity";

export interface ProductPropValue extends ConnectEntity {
    productID: number;
    propID: number;
    value: string;
}

export interface PropertyValueForPost {
    productID: number;
    propID: number;
    value: string;
}

export interface PropertyValueForPut {
    id: number;
    productID: number;
    propID: number;
    value: string;
}