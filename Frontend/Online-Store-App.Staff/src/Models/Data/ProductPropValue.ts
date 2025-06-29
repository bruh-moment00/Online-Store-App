import { type ConnectEntity } from "./Base/ConnectEntity";

export interface ProductPropValue extends ConnectEntity {
    ProductID: number;
    PropID: number;
    Value: string;
}

export interface PropertyValueForPost {
    ProductID: number;
    PropID: number;
    Value: string;
}

export interface PropertyValueForPut {
    Id: number;
    ProductID: number;
    PropID: number;
    Value: string;
}