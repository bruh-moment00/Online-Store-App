import { Page } from "../../LayoutComponents/Page";
import { AddEmployeeForm } from "../../Components/Profile/AddEmployeeForm";

export const AddEmployeePage = () => {
    return (
        <Page title="Регистрация сотрудника" tabTitle="Регистрация сотрудника">
            <AddEmployeeForm />
        </Page>
    )
}