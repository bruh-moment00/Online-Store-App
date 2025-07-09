import { http } from "../../http";
import type { Employee, EmployeeForPost } from "../../Models/Data/Employee";

export const getEmployeeById = async (
    employeeId: number
): Promise<Employee | null> => {
    const result = await http<Employee>({
        path: `employees/${employeeId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const postEmployee = async (
    employee: EmployeeForPost
): Promise<number | undefined> => {
    const result = await http<number, EmployeeForPost>({
        path: "employees",
        method: "post",
        body: employee
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}