import type { PropValueType } from "../../Enums/PropValueType";

export interface PropertyView {
    id: number;
    name: string;
    valueId: number;
    valueType: PropValueType;
    value: string;
}