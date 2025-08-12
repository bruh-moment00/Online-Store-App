import { type Employee } from "commonlib/src/Models/Data/Employee"
import { getEmployees } from "commonlib/src/Services/DataOperations/EmployeesService";
import React from "react"
import { Link } from "react-router";
import { Page } from "../../LayoutComponents/Page";
import { EmployeesList } from "../../Components/Employees/EmployeesList";
import { Button } from "react-bootstrap";

export const EmployeesListPage = () => {
    const [employees, setEmployees] = React.useState<Employee[] | undefined>(undefined);

    React.useEffect(() => {
        let cancelled = false;
        const doGetEmployees = async () => {
            const employeesList = await getEmployees();
            if (!cancelled) {
                setEmployees(employeesList);
            }
        };
        doGetEmployees();
        return () => {
            cancelled = true;
        };
    }, []);

    return (
        <Page title="Список сотрудников" tabTitle="Список сотрудников">
            <Link to="./create">
                <Button variant="outline-primary">Создать сотрудника</Button>
            </Link>
            {employees ? (
                <EmployeesList data={employees} />
            ) : (
                <></>
            )}
        </Page>
    )
}