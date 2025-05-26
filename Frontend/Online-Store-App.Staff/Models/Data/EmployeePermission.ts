import { ConnectEntity } from "./Base/ConnectEntity";

export interface EmployeePermission extends ConnectEntity {
    EmployeeID: number;
    PermissionID: number;
}