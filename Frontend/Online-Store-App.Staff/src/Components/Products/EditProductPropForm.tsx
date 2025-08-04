import { useForm } from "react-hook-form";
import type { ProductPropValue } from "commonlib/src/Models/Data/ProductPropValue";
import type { Property } from "commonlib/src/Models/Data/Property";
import React from "react";
import { Button, Form, FormGroup } from "react-bootstrap";
import { postPropertyValue, putPropertyValue } from "commonlib/src/Services/DataOperations/PropertiesService";

type FormData = {
    id: number;
    productId: number;
    propId: number;
    value: string;
}

interface Props {
    property: Property;
    productId: number;
    propertyValue: ProductPropValue | undefined;
}

export const EditProductPropForm = ({ property, productId, propertyValue }: Props) => {
    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(false);
    const [editPropValue, setEditPropValue] = React.useState<ProductPropValue | undefined>(propertyValue);

    const { register, handleSubmit } = useForm<FormData>({ mode: "onBlur" });

    const submitForm = async (data: FormData) => {
        if (data.id) {
            const result = await putPropertyValue({
                id: data.id,
                productID: data.productId,
                propID: data.propId,
                value: data.value
            });
            setSuccessfullySubmitted(result !== undefined);
        }
        else {
            const result = await postPropertyValue({
                productID: data.productId,
                propID: data.propId,
                value: data.value
            });
            if (result) {
                setSuccessfullySubmitted(true);
                data.id = result;
            }
        }
        
        setTimeout(() => {
                    setSuccessfullySubmitted(false)
                }, 1000);
    }
    
    return (
        <div>
            <form onSubmit={handleSubmit(submitForm)} key={property.id}>
                <fieldset>
                    <FormGroup>
                        <input
                            type="hidden"
                            value={editPropValue?.id}
                            {...register('id')} />
                        <input
                            type="hidden"
                            value={productId}
                            {...register('productId')} />
                        <input
                            type="hidden"
                            value={property.id}
                            {...register('propId')} />
                        <label className="control-label">{property.propName}</label>
                        <Form.Control
                            id={`value${property.id}`}
                            defaultValue={editPropValue?.value}
                            {...register('value')}>
                        </Form.Control>
                        <Button type="submit">Сохранить</Button>
                        {successfullySubmitted ? <text>Сохранено успешно</text> : <></>}
                    </FormGroup>
                </fieldset>
            </form>
        </div>
    );
}