import { useForm } from "react-hook-form";
import type { Property } from "commonlib/src/Models/Data/Property";
import React from "react";
import { Button, Form, FormGroup, type FormControlProps } from "react-bootstrap";
import { PropValueTypeName } from "commonlib/src/EnumStrings/PropValueType";
import { putProperty } from "commonlib/src/Services/DataOperations/PropertiesService";

type FormData = {
    id: number;
    categoryID: number,
    propName: string;
    valueType: number;
}

interface Props {
    property: Property;
}

export const EditPropForm = ({ property }: Props) => {
    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(false);
    const [editProp, setEditProp] = React.useState(property);
    
    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});

    const submitForm = async (data: FormData) => {
         const result = await putProperty({
             id: Number(data.id),
             categoryID: Number(data.categoryID),
             propName: data.propName,
             valueType: Number(data.valueType)
         });
         if (result) {
            setSuccessfullySubmitted(true);
            setTimeout(() => {
                setSuccessfullySubmitted(false)
            }, 1000);
         }
    }

    return (
        <div>
            <form onSubmit={handleSubmit(submitForm)} key={editProp.id}>
                <fieldset>
                    <input type="hidden" value={editProp.id} {...register('id')}/>
                    <input type="hidden" value={editProp.categoryID} {...register('categoryID')}/>
                    <FormGroup>
                        <label className="control-label">Наименование характеристики</label>
                        <Form.Control 
                            id={`property${editProp.id}`} 
                            defaultValue={editProp.propName} 
                            {...register('propName', {required: true})}>
                        </Form.Control>
                    </FormGroup>
                    <FormGroup>
                        <label className="control-label">Тип значения</label>
                        <Form.Select id="valueType"  defaultValue={editProp.valueType} {...register('valueType', {required: true})}>
                            {PropValueTypeName!.map((valueType) => (
                                <option key={PropValueTypeName.indexOf(valueType)} 
                                    value={PropValueTypeName.indexOf(valueType)}>
                                        {valueType}
                                </option>
                            ))}
                        </Form.Select> 
                        <Button type="submit">Сохранить</Button>
                        {successfullySubmitted ? <b>Сохранено успешно</b> : <></>}
                    </FormGroup>
                </fieldset>
            </form>
        </div>
    );
}