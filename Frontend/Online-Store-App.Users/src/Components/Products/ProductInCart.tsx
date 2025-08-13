import { server } from "commonlib/src/AppSettings";
import type { Product } from "commonlib/src/Models/Data/Product";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { getProductById } from "commonlib/src/Services/DataOperations/ProductsService";
import React from "react";
import { Button, Card, Image } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
    productId: number;
    onRemove: React.MouseEventHandler<HTMLButtonElement>;
}

export const ProductInCart = ({ productId, onRemove }: Props) => {
    const [product, setProduct] = React.useState<Product | undefined>(undefined);
    const [imagePreview, setImagePreview] = React.useState<string | undefined>(undefined);

    React.useEffect(() => {
        const getProduct = async () => {
            const foundProduct = await getProductById(productId);
            if (foundProduct) {
                setProduct(foundProduct);

                const foundImages = await getImagesURLByProductId(productId);
                if (foundImages)
                    setImagePreview(foundImages[0])
                else
                    setImagePreview(undefined);
            }
        }

        getProduct();
    }, [productId]);

    return (
        <Card>
            <Link to={`/products/${product?.id}`}>
                <Card.Header as={"h3"}>
                    {product?.name}
                </Card.Header>
            </Link>
            <Link to={`/products/${product?.id}`}>
                <Card.Body className="">
                    <Image src={server + "/" + imagePreview} width={200}/>
                    {product?.price} у.е.
                </Card.Body>
            </Link>
            <Card.Footer>
                <Button variant="danger" onClick={onRemove}>Удалить из корзины</Button>                 
            </Card.Footer>
            
        </Card>
    )
}