import { useForm } from "react-hook-form";
import { postUser } from "commonlib/src/Services/DataOperations/UsersService";
import { loginUser } from "commonlib/src/Services/AuthService";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup } from "react-bootstrap";

type FormData = {
    firstName: string;
    lastName: string | undefined;
    phoneNum: string;
    email: string | undefined;
    gender: number | undefined;
    birthDate: Date | undefined;
    login: string;
    password: string;
    confirmPassword: string;
}

export const RegisterForm = () => {
    const {register, handleSubmit} = useForm<FormData>({mode: "onSubmit"});

    const navigate = useNavigate();

    const submitForm = async (data: FormData) => {
        const result = await postUser({
            firstName: data.firstName,
            lastName: data.lastName,
            phoneNum: data.phoneNum,
            email: data.email,
            gender: getGenderBool(data.gender),
            birthDate: data.birthDate,
            login: data.login,
            password: data.password,
            confirmPassword: data.confirmPassword
        });
        if (result) {
            loginUser(data.password, undefined, data.phoneNum);
            navigate('/');
        }
    }

    const getGenderBool = (value: number | undefined): boolean | undefined => {
        if (value == 1) return true;
        else if (value == 0) return false;
        else return undefined;
    }

    return (
        <form onSubmit={handleSubmit(submitForm)}>
            <fieldset>
                <FormGroup>
                    <label className="control-label">Имя</label>
                    <Form.Control 
                        id="firstName"
                        {...register('firstName', {required: true})}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Фамилия</label>
                    <Form.Control 
                        id="lastName"
                        {...register('lastName')}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Номер телефона</label>
                    <Form.Control 
                        id="phone"
                        {...register('phoneNum', {required: true})}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Электронная почта</label>
                    <Form.Control 
                        id="email"
                        {...register('email')}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Пол</label>
                    <Form.Select 
                        id="gender" 
                        {...register('gender', {required: true})}>   
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
                    {...register('birthDate', {required: true})} />
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Логин</label>
                    <Form.Control 
                        id="login"
                        {...register('login', {required: true})}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Пароль</label>
                    <Form.Control 
                        id="password"
                        type="password"
                        {...register('password', {required: true})}>                            
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Подтвердите пароль</label>
                    <Form.Control 
                        id="confirmPassword"
                        type="password"
                        {...register('confirmPassword', {required: true})}>                            
                    </Form.Control>
                </FormGroup>
                <Button type="submit">Зарегистрироваться</Button>
            </fieldset>
        </form>
    )
}