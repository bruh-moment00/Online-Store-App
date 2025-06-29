import type { PropValueType } from "../../Enums/PropValueType";

export interface PropertyView {
    PropertyId: number;
    Name: string;
    ValueId: number;
    ValueType: PropValueType;
    Value: string;
}