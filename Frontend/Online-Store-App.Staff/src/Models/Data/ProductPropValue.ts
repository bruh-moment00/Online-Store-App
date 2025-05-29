import { type ConnectEntity } from "./Base/ConnectEntity";

export interface ProductPropValue extends ConnectEntity {
    ProductID: number;
    PropID: number;
    Value: string;
}