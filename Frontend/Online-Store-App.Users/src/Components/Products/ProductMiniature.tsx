import React from "react";
import { Button, Card } from "react-bootstrap";

import type { Product } from "commonlib/src/Models/Data/Product";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { server } from "commonlib/src/AppSettings";
import { getCookie, setCookie } from "typescript-cookie";

interface Props {
    data: Product;
}

export const ProductMiniature = ({ data }: Props) => {
    const [imagePreview, setImagePreview] = React.useState<string | undefined>(undefined);
    const [inCart, setInCart] = React.useState<boolean>(false);
    
    React.useEffect(() => {
        const doGetImage = async (productId: number) => {
            const foundImages = await getImagesURLByProductId(productId);
            if (foundImages)
                setImagePreview(foundImages[0])
            else
                setImagePreview(undefined); 
        }

        if (data) {
            doGetImage(data.id);
        }
    }, [data]);

    React.useEffect(() => {
        const getCart = async () => {
            const cart = await getCookie("cart");
            cart?.split(';').forEach(element => {
                if (Number(element) === data.id)
                    setInCart(true);
            });
        }
        if (data) {
            getCart();
        }
    }, [])

    const handleCartClick = () => {
        const cart = getCookie("cart");
        setCookie("cart", cart + `;${data.id}`);
        setInCart(true);
    }

    return (
        <div className="col-xs-12 col-sm-12 col-md-4">
            <Card 
                style={{marginTop: '20px'}} >
                <Card.Img variant="top" src={server + "/" + imagePreview} />
                <Card.Body>
                    <Card.Title>{data.name}</Card.Title>
                    <Card.Text>{data.description}</Card.Text>
                    <Card.Text>Цена {data.price} у.е.</Card.Text>
                    {inCart ? 
                    <Button variant="primary" onClick={handleCartClick}>В корзине</Button> :
                    <Button variant="outline-primary" onClick={handleCartClick}>В корзину</Button>
                    }
                </Card.Body>
            </Card>
        </div>
    )
}