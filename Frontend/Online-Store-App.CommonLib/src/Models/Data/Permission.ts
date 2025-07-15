import { type BaseEntity } from "./Base/BaseEntity";

export interface Permission extends BaseEntity {
    name: string;
    description: string;
}