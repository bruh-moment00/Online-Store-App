import { Double } from "react-native/Libraries/Types/CodegenTypes";
import { BaseEntity } from "./Base/BaseEntity";

export interface Product extends BaseEntity {
    Name: string;
    Description: string;
    CategoryID: number;
    Price: Double;
}