import { server } from "commonlib/src/AppSettings";
import type { OrderedProduct } from "commonlib/src/Models/Data/OrderedProduct";
import type { Product } from "commonlib/src/Models/Data/Product";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { getProductById } from "commonlib/src/Services/DataOperations/ProductsService";
import React from "react";
import { Card, Image } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
    orderedProduct: OrderedProduct;
}

export const ProductMiniature = ({ orderedProduct }: Props) => {
    const [product, setProduct] = React.useState<Product | undefined>(undefined);
    const [imagePreview, setImagePreview] = React.useState<string | undefined>(undefined);

    React.useEffect(() => {
        const getProduct = async () => {
            const foundProduct = await getProductById(orderedProduct.productID);
            if (foundProduct) {
                setProduct(foundProduct);

                const foundImages = await getImagesURLByProductId(orderedProduct.productID);
                if (foundImages)
                    setImagePreview(foundImages[0])
                else
                    setImagePreview(undefined);
            }
        }

        getProduct();
    }, [orderedProduct]);

    return (
        <Card>
            <Link to={`/products/${product?.id}`}>
                <Card.Header>
                    {product?.name}
                </Card.Header>
            </Link>
            <Link to={`/products/${product?.id}`}>
                <Card.Body>
                    <Image src={server + "/" + imagePreview} width={150}/>
                    {orderedProduct.priceWhenAdded} у.е.
                </Card.Body>
            </Link>
        </Card>
    )
}