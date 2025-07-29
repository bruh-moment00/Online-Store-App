import { useForm } from "react-hook-form";
import type { Property } from "commonlib/src/Models/Data/Property";
import React from "react";
import { Button, Form, FormGroup } from "react-bootstrap";
import { PropValueTypeName } from "commonlib/src/EnumStrings/PropValueType";
import { deleteProperty, getPropertyById, postProperty, putProperty } from "commonlib/src/Services/DataOperations/PropertiesService";

type FormData = {
    id: number;
    categoryID: number,
    propName: string;
    valueType: number;
}

interface Props {
    categoryId: number;
    properties: Property[];
}

export const EditCategoryPropertiesForm = ({ categoryId, properties }: Props) => {
    const [props, setProps] = React.useState<Property[]>(properties);
    
    const {register, handleSubmit} = useForm<FormData>({mode: "onBlur"});

    const submitForm = async (data: FormData) => {
         const result = await putProperty({
             id: Number(data.id),
             categoryID: Number(data.categoryID),
             propName: data.propName,
             valueType: Number(data.valueType)
         });
         if (result) {
            alert("Успешно изменено");
         }
    }

    const handleCreate = async () => {
        const newName = prompt("Введите наименование категории:")
        if (newName) {
            const result = await postProperty({
                categoryID: categoryId,
                propName: newName,
                valueType: 0
            });
            if (result) {
                let newProp = await getPropertyById(result);
                if (newProp) setProps([...props, newProp]);
            }
        }
    }

    const handleDelete = (id: number) => {
        if (id && confirm("Точно удалить данную характеристику?")) {
            const result = deleteProperty(id);
            if (result != null) {
                setProps(props.filter(p => p.id !== id))
            }      
        }
    }

    return (
        <div>
            <Button variant="outline-primary" onClick={handleCreate}>Добавить характеристику</Button>
            {props!.map((property) => (
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
                            <Button variant="danger" onClick={() => handleDelete(property.id)}>Удалить характеристику</Button>
                        </FormGroup>
                    </fieldset>
                </form>
            ))}
        </div>
    );
}