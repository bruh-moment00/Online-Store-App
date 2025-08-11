import React from "react";
import type { Product } from "commonlib/src/Models/Data/Product";
import { Page } from "../../LayoutComponents/Page"
import { createSearchParams, Link, useParams } from "react-router-dom";
import { getProductById } from "commonlib/src/Services/DataOperations/ProductsService";
import { getProperties, getPropertyValues } from "commonlib/src/Services/DataOperations/PropertiesService";
import type { Property } from "commonlib/src/Models/Data/Property";
import type { ProductPropValue } from "commonlib/src/Models/Data/ProductPropValue";
import { EditProductForm } from "../../Components/Products/EditProductForm";
import { EditProductPropertiesForm } from "../../Components/Products/EditProductPropertiesForm";
import { Button } from "react-bootstrap";

export const EditProductPage = () => {
    const [product, setProduct] = React.useState<Product | undefined>(undefined);
    const [properties, setProperties] = React.useState<Property[] | undefined> (undefined);
    const [propertiesValues, setPropertiesValues] = React.useState<ProductPropValue[] | undefined> (undefined);

    const { productId } = useParams();

    React.useEffect(() => {
        let cancelled = false;

        const doGetProduct = async (productId: number) => {
            const foundProduct = await getProductById(productId);
            if (!cancelled) {
                setProduct(foundProduct);
                
                if (foundProduct) {
                    const foundCategoryProperties = await getProperties(createSearchParams({categoryId: [`${foundProduct.categoryID}`]}));
                    setProperties(foundCategoryProperties);
                    const foundProductPropertiesValues = await getPropertyValues(createSearchParams({productId: [`${foundProduct.id}`]}));
                    setPropertiesValues(foundProductPropertiesValues);
                }
            }
        };

        if (productId) {
            doGetProduct(Number(productId));
        }
        return () => {
            cancelled = true;
        };
    }, [productId]);
    
    return (
    <Page title="Редактирование товара">
        <div>
            {product ? <EditProductForm product={product} /> : <></>}
            <hr/>
            <Link to={"images"}>
                <Button variant="outline-primary">Загрузка изображений</Button>
            </Link>
            <hr/>
            <h4>Характеристики</h4>
            {(properties && propertiesValues) ? <EditProductPropertiesForm properties={properties} values={propertiesValues} productId={product!.id}/> : <></>}         
        </div>
    </Page>
)
}