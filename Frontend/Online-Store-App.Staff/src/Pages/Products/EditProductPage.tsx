import React from "react";
import type { Product } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Product";
import { Page } from "../../LayoutComponents/Page"
import type { Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { createSearchParams, useParams } from "react-router-dom";
import { getCategoryById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import { getImagesURLByProductId } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductImagesService";
import { getProductById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductsService";
import { getProperties, getPropertiesViewByProductId } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/PropertiesService";
import type { Property } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Property";
import type { ProductPropValue } from "../../../../Online-Store-App.Commonlib/src/Models/Data/ProductPropValue";
import { useForm } from "react-hook-form";
import { EditProductForm } from "../../Components/Products/EditProductForm";

type FormPropertiesValuesData = {
    property: any;
    value: string;
}

type FormImageData = {
    image: File;
}

export const EditProductPage = () => {
    const [product, setProduct] = React.useState<Product | null>(null);
    const [category, setCategory] = React.useState<Category | null> (null);
    const [properties, setProperties] = React.useState<Property[] | undefined> (undefined);
    const [propertiesValues, setPropertiesValues] = React.useState<ProductPropValue | undefined> (undefined);
    const [imagesURLs, setImagesURLs] = React.useState<string[] | undefined>(undefined);
    const [imagesRetrieving, setImagesRetrieving] = React.useState(true);

    const { productId } = useParams();

    React.useEffect(() => {
        let cancelled = false;

        const doGetProduct = async (productId: number) => {
            const foundProduct = await getProductById(productId);
            if (!cancelled) {
                setProduct(foundProduct);
                
                if (foundProduct) {
                    const foundCategory = await getCategoryById(foundProduct.categoryID);
                    setCategory(foundCategory);
                    const categoryProperties = await getProperties(createSearchParams({categoryId: [`${foundProduct.categoryID}`]}));
                    setProperties(categoryProperties);
                    const foundImagesURLs = await getImagesURLByProductId(productId);
                    setImagesURLs(foundImagesURLs);
                    setImagesRetrieving(false);
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
    <Page title="Редактирование">
        <div>
            {product? <EditProductForm product={product} /> : <></>}           
        </div>
    </Page>
)
}