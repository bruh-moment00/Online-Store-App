import React from "react";
import { useForm } from "react-hook-form";
import type { Product } from "commonlib/src/Models/Data/Product";
import { Button, Form, FormGroup } from "react-bootstrap";
import { BackButton } from "../BackButton";
import { putProduct } from "commonlib/src/Services/DataOperations/ProductsService";

type FormData = {
    name: string;
    price: number;
    description: string;
}

interface Props {
    product: Product;
}
export const EditProductForm = ({ product }: Props) => {

    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(false);

    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});

    const submitForm = async (data: FormData) => {
        const result = await putProduct({
            id: product.id,
            name: data.name,
            description: data.description,
            categoryId: product.categoryID,
            price: data.price
        });
        setSuccessfullySubmitted(result !== undefined);
    }

    return (
        <form onSubmit={handleSubmit(submitForm)}>
            <fieldset>
                <FormGroup>
                    <label className="constrol-label">Наименование</label>
                    <Form.Control id="name" {...register('name', {required: true})} defaultValue={product.name}></Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Цена</label>
                    <Form.Control id="price" {...register('price', { required: true })} defaultValue={product.price}></Form.Control>
                </FormGroup>
                <FormGroup>
                    <label className="control-label">Описание</label>
                    <Form.Control as="textarea" id="description" {...register('description', { required: true })} defaultValue={product.description}></Form.Control>
                </FormGroup>
                <FormGroup>
                    <Button type="submit">Сохранить</Button>
                    <BackButton />
                </FormGroup>
            </fieldset>
        </form>
    )
}