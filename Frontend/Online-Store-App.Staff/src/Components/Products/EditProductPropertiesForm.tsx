import type { ProductPropValue } from "commonlib/src/Models/Data/ProductPropValue";
import type { Property } from "commonlib/src/Models/Data/Property";
import { EditProductPropForm } from "./EditProductPropForm";

interface Props {
    properties: Property[];
    values: ProductPropValue[];
    productId: number;
}

export const EditProductPropertiesForm = ({ properties, values, productId }: Props) => {
    return (
        <div>
            {properties!.map((property) => (
                <EditProductPropForm 
                    productId={productId} 
                    property={property} 
                    propertyValue={values.find(v => v.propID === property.id)}/>
            ))}
        </div>
    );
}