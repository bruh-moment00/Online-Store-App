import type { User } from "commonlib/src/Models/Data/User";
import { putUser } from "commonlib/src/Services/DataOperations/UsersService";
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
    user: User;
}

export const EditProfileForm = ({ user }: Props) => {
    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});
    const navigate = useNavigate();

    const submitForm = async (data: FormData) => {
        const result = await putUser({
            id: user.id,
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

    const defaultBDate = user.birthDate ? new Date(user.birthDate).toLocaleDateString('en-CA') : undefined;

    return (
        <form onSubmit={handleSubmit(submitForm)}>
            <FormGroup>
                <label className="control-label">Имя</label>
                <Form.Control 
                    id="firstName" 
                    {...register('firstName', {required: true})} 
                    defaultValue={user.firstName}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Фамилия</label>
                <Form.Control 
                    id="lastName" 
                    {...register('lastName', {required: true})} 
                    defaultValue={user.lastName}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Номер телефона</label>
                <Form.Control 
                    id="phoneNum" 
                    {...register('phoneNum', {required: true})} 
                    defaultValue={user.phoneNum}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Электронная почта</label>
                <Form.Control 
                    id="email" 
                    {...register('email', {required: true})} 
                    defaultValue={user.email}>        
                </Form.Control>
            </FormGroup>
            <FormGroup>
                <label className="control-label">Пол</label>
                <Form.Select 
                    id="gender" 
                    {...register('gender', {required: true})} 
                    defaultValue={getGenderNum(user.gender)}>   
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
                    {...register('birthDate')} 
                    />
            </FormGroup>
            <FormGroup>
                <label className="control-label">Логин</label>
                <Form.Control 
                    id="login" 
                    {...register('login', {required: true})} 
                    defaultValue={user.login}>        
                </Form.Control>
            </FormGroup>
            <Button type="submit">Сохранить</Button>
        </form>
    )
}