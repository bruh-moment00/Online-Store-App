import type { Employee } from "commonlib/src/Models/Data/Employee";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
    data: Employee[] | undefined;
}

export const EmployeesList = ({ data }: Props) => (
    <div className="">
        <Table>
            <thead>
                <tr>
                    <th>Имя</th>
                    <th>Номер телефона</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {data!.map((employee) => (
                    <tr key={employee.id}>
                        <td>
                            <Link to={`/employees/${employee.id}`}>
                                {employee.firstName} {employee.lastName}
                            </Link>
                        </td>
                        <td>{employee.phoneNum}</td>
                    </tr>
                ))}
            </tbody>
        </Table>
    </div>
)