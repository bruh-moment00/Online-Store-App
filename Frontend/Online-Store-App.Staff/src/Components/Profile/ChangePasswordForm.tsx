import { changePassword } from "commonlib/src/Services/DataOperations/EmployeesService";
import { Button, Form, FormGroup } from "react-bootstrap";
import { useForm } from "react-hook-form";

type FormData = {
    oldPassword: string;
    newPassword: string;
    newPasswordConfirm: string;
}

interface Props {
    id: number;
}

export const ChangePasswordForm = ({ id }: Props) => {
    const {register, handleSubmit, reset} = useForm<FormData>({mode: "onBlur"});

    const submitForm = async (data: FormData) => {
        const result = await changePassword({
            id: id,
            oldPassword: data.oldPassword,
            newPassword: data.newPassword,
            newPasswordConfirm: data.newPasswordConfirm
        });
        if (result) {
            alert("Пароль успешно изменен");
            reset();
        }
    }
    return (
        <div>
            <h4>Сменить пароль</h4>
            <form onSubmit={handleSubmit(submitForm)}>
                <FormGroup>
                    <label className="control-label">Старый пароль</label>
                    <Form.Control 
                        id="oldPassword" 
                        type="password" 
                        placeholder="Старый пароль"
                        {...register('oldPassword', {required: true})}>    
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Новый пароль</label>
                    <Form.Control 
                        id="newPassword" 
                        type="password" 
                        placeholder="Новый пароль"
                        {...register('newPassword', {required: true})}>    
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Подтвердите новый пароль</label>
                    <Form.Control 
                        id="newPasswordConfirm" 
                        type="password" 
                        placeholder="Подтвердите новый пароль"
                        {...register('newPasswordConfirm', {required: true})}>    
                    </Form.Control>
                </FormGroup>
                <Button type="submit">Сохранить</Button>
            </form>
        </div>
    )
}