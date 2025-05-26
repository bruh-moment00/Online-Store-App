import { BaseEntity } from "./Base/BaseEntity";

export interface OrderedProduct extends BaseEntity {
    ImageAddress: string;
    ProductID: number;
}