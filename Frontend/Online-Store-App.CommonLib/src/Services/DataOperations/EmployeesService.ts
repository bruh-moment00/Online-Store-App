import { http } from "../../http";
import type { Employee, EmployeeForPost, EmployeeForPut } from "../../Models/Data/Employee";
import { Password } from "../../Models/Data/Password";

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

export const getEmployees = async (): Promise<Employee[] | undefined> => {
    const result = await http<Employee[]>({
        path: "employees"
    });
    if (result.ok || result.body)
        return result.body;
    else
        return undefined;
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

export const putEmployee = async (
    employee: EmployeeForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, EmployeeForPut>({
        path: `employees/${employee.id}`,
        method: "put",
        body: employee
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const changePassword = async (
    password: Password
): Promise<boolean | undefined> => {
    const result = await http<boolean, Password>({
        path: `employees/${password.id}/password`,
        method: "put",
        body: password
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deleteEmployee = async (
    employeeId: number
): Promise<number | null> => {
    const result = await http<number>({
        path: `employees/${employeeId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}
