import { type BaseEntity } from "./Base/BaseEntity";

export interface OrderedProduct extends BaseEntity {
    imageAddress: string;
    productID: number;
}