import type { Category } from "commonlib/src/Models/Data/Category";
import type { Product } from "commonlib/src/Models/Data/Product"
import type { PropertyView } from "commonlib/src/Models/ViewModels/PropertyView";
import { getCategoryById } from "commonlib/src/Services/DataOperations/CategoriesService";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { getProductById } from "commonlib/src/Services/DataOperations/ProductsService";
import { getPropertiesViewByProductId } from "commonlib/src/Services/DataOperations/PropertiesService";

import React from "react"
import { useNavigate, useParams } from "react-router-dom";
import { Page } from "../../Components/Layout/Page";
import { ProductCard } from "../../Components/Products/ProductCard";

export const ProductPage = () => {
    const [product, setProduct] = React.useState<Product | undefined>(undefined);

    const { productId } = useParams();

    const navigate = useNavigate();

    React.useEffect(() => {
        let cancelled = false;

        const doGetProduct = async (productId: number) => {
            const foundProduct = await getProductById(productId);
            if (!cancelled) {
                setProduct(foundProduct);
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
        <Page title={`${product?.name}`} tabTitle={`${product?.name}`}>
            {product ? 
                (<ProductCard product={product}/>) 
                : 
                (<></>)}
        </Page>
    )
}