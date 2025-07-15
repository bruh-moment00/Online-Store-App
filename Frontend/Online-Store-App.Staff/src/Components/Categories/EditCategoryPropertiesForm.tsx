import { useForm } from "react-hook-form";
import type { Property } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Property";
import React from "react";
import { Button, Form, FormGroup } from "react-bootstrap";
import { PropValueTypeName } from "../../../../Online-Store-App.CommonLib/src/EnumStrings/PropValueType";
import { putProperty } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/PropertiesService";

type FormData = {
    id: number;
    categoryID: number,
    propName: string;
    valueType: number;
}

interface Props {
    properties: Property[];
}

export const EditCategoryPropertiesForm = ({ properties }: Props) => {
    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(false);
    
    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});
    
    const submitForm = async (data: FormData) => {
         const result = await putProperty({
             id: Number(data.id),
             categoryID: Number(data.categoryID),
             propName: data.propName,
             valueType: Number(data.valueType)
         });
        setSuccessfullySubmitted(result !== undefined);
    }
    return (
        <div>
            {properties!.map((property) => (
                <form onSubmit={handleSubmit(submitForm)} key={property.id}>
                    <fieldset>
                        <FormGroup>
                            <input type="hidden" value={property.id} {...register('id')}/>
                            <input type="hidden" value={property.categoryID} {...register('categoryID')}/>
                            <label className="control-label">Наименование характеристики</label>
                            <Form.Control 
                                id={`property${property.id}`} 
                                defaultValue={property.propName} 
                                {...register('propName', {required: true})}>
                            </Form.Control>
                        </FormGroup>
                        <FormGroup>
                            <label className="control-label">Тип значения</label>
                            <Form.Select id="valueType"  defaultValue={property.valueType} {...register('valueType', {required: true})}>
                                {PropValueTypeName!.map((valueType) => (
                                    <option key={PropValueTypeName.indexOf(valueType)} 
                                        value={PropValueTypeName.indexOf(valueType)}>
                                            {valueType}
                                    </option>
                                ))}
                            </Form.Select> 
                            <Button type="submit">Сохранить</Button>
                            <Button variant="danger">Удалить характеристику</Button>
                        </FormGroup>
                    </fieldset>
                </form>
            ))}
        </div>
    );
}