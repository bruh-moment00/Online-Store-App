import type { Property } from "commonlib/src/Models/Data/Property";
import React from "react";
import { Button } from "react-bootstrap";
import { deleteProperty, getPropertyById, postProperty } from "commonlib/src/Services/DataOperations/PropertiesService";
import { EditPropForm } from "./EditPropForm";

interface Props {
    categoryId: number;
    properties: Property[];
}

export const EditCategoryPropertiesForm = ({ categoryId, properties }: Props) => {
    const [props, setProps] = React.useState<Property[]>(properties);

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
                <div>
                    <EditPropForm property={property} />
                    <Button variant="danger" onClick={() => handleDelete(property.id)}>Удалить характеристику</Button>
                </div>
            ))}
        </div>
    );
}