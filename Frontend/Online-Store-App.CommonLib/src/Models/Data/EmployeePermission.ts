import { type ConnectEntity } from "./Base/ConnectEntity";

export interface EmployeePermission extends ConnectEntity {
    employeeID: number;
    permissionID: number;
}