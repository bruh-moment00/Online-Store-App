import type { Employee } from "commonlib/src/Models/Data/Employee";
import { putEmployee } from "commonlib/src/Services/DataOperations/EmployeesService";
import { Button, Form, FormGroup } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router";

type FormData = {
    firstName: string;
    lastName: string;
    phoneNum: string;
    email: string;
    gender: number | undefined;
    birthDate: Date;
    login: string;
}

interface Props {
    employee: Employee;
}

export const EditProfileForm = ({ employee }: Props) => {
    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});
    const navigate = useNavigate();

    const submitForm = async (data: FormData) => {
        const result = await putEmployee({
            id: employee.id,
            firstName: data.firstName,
            lastName: data.lastName,
            phoneNum: data.phoneNum,
            email: data.email,
            gender: getGenderBool(data.gender),
            birthDate: data.birthDate,
            login: data.login,
        });
        if (result) {
            navigate("../", {relative: "path"})
        }
    }

    const getGenderNum = (value: boolean | undefined): number | undefined => {
        if (value === true) return 1;
        else if (value === false) return 0;
        else return undefined;
    }

    const getGenderBool = (value: number | undefined): boolean | undefined => {
        if (value == 1) return true;
        else if (value == 0) return false;
        else return undefined;
    }

    const defaultBDate = new Date(employee.birthDate).toLocaleDateString('en-CA');

    return (
        <form onSubmit={handleSubmit(submitForm)}>
            <FormGroup>
                <label className="control-label">Имя</label>
                <Form.Control 
                    id="firstName" 
                    {...register('firstName', {required: true})} 
                    defaultValue={employee.firstName}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Фамилия</label>
                <Form.Control 
                    id="lastName" 
                    {...register('lastName', {required: true})} 
                    defaultValue={employee.lastName}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Номер телефона</label>
                <Form.Control 
                    id="phoneNum" 
                    {...register('phoneNum', {required: true})} 
                    defaultValue={employee.phoneNum}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Электронная почта</label>
                <Form.Control 
                    id="email" 
                    {...register('email', {required: true})} 
                    defaultValue={employee.email}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Пол</label>
                <Form.Select 
                    id="gender" 
                    {...register('gender', {required: true})} 
                    defaultValue={getGenderNum(employee.gender)}>   
                    <option value={undefined}>Не указан</option>     
                    <option value={1}>Мужской</option> 
                    <option value={0}>Женский</option> 
                </Form.Select>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Дата рождения</label>
                <input
                    type="date"
                    id="birthDate" 
                    defaultValue={defaultBDate}
                    {...register('birthDate', {required: true})} 
                    />
            </FormGroup>
            <FormGroup>
                <label className="control-label">Логин</label>
                <Form.Control 
                    id="login" 
                    {...register('login', {required: true})} 
                    defaultValue={employee.login}>        
                </Form.Control>
            </FormGroup>
            <Button type="submit">Сохранить</Button>
        </form>
    )
}