import { PropValueType } from "../../Enums/PropValueType";
import { type BaseEntity } from "./Base/BaseEntity";

export interface OrderedProduct extends BaseEntity {
    CategoryID: number;
    PropName: String;
    ValueType: PropValueType;
}