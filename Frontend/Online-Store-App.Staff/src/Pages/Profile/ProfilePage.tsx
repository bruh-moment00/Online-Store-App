import React from "react"

import { Page } from "../../LayoutComponents/Page"
import type { Employee } from "commonlib/src/Models/Data/Employee"
import { getCurrentEmployeeId } from "commonlib/src/Services/AuthService";
import { getEmployeeById } from "commonlib/src/Services/DataOperations/EmployeesService";
import { Link } from "react-router";
import { Button } from "react-bootstrap";

export const ProfilePage = () => {
    const [employee, setEmployee] = React.useState<Employee | undefined>(undefined);

    React.useEffect(() => {
        let cancelled = false;

        const doGetEmployee = async () => {
            const id = await getCurrentEmployeeId();
            if (id) {
                const foundEmployee = await getEmployeeById(id);
                if (foundEmployee){
                    setEmployee(foundEmployee);
                }
            }
            
        } 
        doGetEmployee();

        return () => {
            cancelled = true;
        };
    }, [])

    const dateParse = (date: Date) => {
        const dateString = new Date(date).toLocaleDateString();
        return (
            dateString
        );
    }

    const dateTimeParse = (date: Date) => {
        const dateString = new Date(date).toLocaleString();
        return (
            dateString
        );
    }

    const getGenderString = (gender: boolean | undefined) => {
        if (gender === true)
            return "Мужской"
        else if (gender === false)
            return "Женский"
        else
            return "Не указан"
    }

    return(
        <Page title="Профиль" tabTitle="Профиль">
            <div>
                <dl className="row">
                    <dt className="col-sm-2">Имя</dt>
                    <dd className="col-sm-10">{employee?.firstName}</dd>
                    <dt className="col-sm-2">Фамилия</dt>
                    <dd className="col-sm-10">{employee?.lastName}</dd>
                    <dt className="col-sm-2">Пол</dt>
                    <dd className="col-sm-10">{getGenderString(employee?.gender)}</dd>
                    <dt className="col-sm-2">Электронная почта</dt>
                    <dd className="col-sm-10">{employee?.email}</dd>
                    <dt className="col-sm-2">Номер телефона</dt>
                    <dd className="col-sm-10">{employee?.phoneNum}</dd>
                    {employee?.birthDate ? 
                    <div>
                        <dt className="col-sm-2">Дата рождения</dt>
                        <dd className="col-sm-10">{dateParse(employee.birthDate)}</dd>
                    </div> : <></>
                    }
                    {employee?.createdDateTime ?
                    <div>
                        <dt className="col-sm-2">Дата создания аккаунта</dt>
                        <dd className="col-sm-10">{dateTimeParse(employee?.createdDateTime)}</dd>
                    </div> : <></>
                    }                
                </dl>
            </div>
            <div className="col-sm-6">
                <Link to="edit">
                    <Button>Редактировать</Button>
                </Link>
            </div>
        </Page>
    )
}