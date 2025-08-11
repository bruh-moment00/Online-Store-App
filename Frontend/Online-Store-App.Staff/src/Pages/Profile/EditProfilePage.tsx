import { type Employee } from "commonlib/src/Models/Data/Employee"
import { getCurrentEmployeeId } from "commonlib/src/Services/AuthService";
import { getEmployeeById } from "commonlib/src/Services/DataOperations/EmployeesService";
import React from "react";
import { Page } from "../../LayoutComponents/Page";
import { EditProfileForm } from "../../Components/Profile/EditProfileForm";
import { ChangePasswordForm } from "../../Components/Profile/ChangePasswordForm";

export const EditProfilePage = () => {
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
        }, []);

    return (
        <Page title="Редактирование профиля сотрудника" tabTitle="Редактирование профиля">
            <div>
                {employee ? <EditProfileForm employee={employee}/> : <></>}
                <hr/>
                {employee ? <ChangePasswordForm id={employee.id}/> : <></>} 
            </div>
        </Page>
    )
}