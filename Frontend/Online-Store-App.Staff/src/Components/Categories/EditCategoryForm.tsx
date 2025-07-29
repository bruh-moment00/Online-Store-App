import React from "react";
import { useForm } from "react-hook-form";
import { Button, Form, FormGroup } from "react-bootstrap";
import { BackButton } from "../BackButton";
import { putCategory } from "commonlib/src/Services/DataOperations/CategoriesService";
import type { Category } from "commonlib/src/Models/Data/Category";

type FormData = {
    name: string;
}

interface Props {
    category: Category;
}
export const EditCategoryForm = ({ category }: Props) => {

    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(false);

    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});

    const submitForm = async (data: FormData) => {
        const result = await putCategory({
            id: category.id,
            name: data.name,
        });
        setSuccessfullySubmitted(result !== undefined);
    }

    return (
        <form onSubmit={handleSubmit(submitForm)}>
            <fieldset>
                <FormGroup>
                    <label className="constrol-label">Наименование</label>
                    <Form.Control id="name" {...register('name', {required: true})} 
                        defaultValue={category.name} 
                        onChange={() => setSuccessfullySubmitted(false)}>
                    </Form.Control>
                </FormGroup>
                <FormGroup>
                    <Button type="submit">Сохранить</Button>
                    <BackButton />
                    {successfullySubmitted ? <div>Успешно сохранено</div> : <></>}
                </FormGroup>
            </fieldset>
        </form>
    )
}