import { PropValueType } from "@/Enums/PropValueType";
import { BaseEntity } from "./Base/BaseEntity";

export interface OrderedProduct extends BaseEntity {
    CategoryID: number;
    PropName: String;
    ValueType: PropValueType;
}