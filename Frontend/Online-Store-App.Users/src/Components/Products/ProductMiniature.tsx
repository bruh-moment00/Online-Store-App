import React from "react";
import { Card } from "react-bootstrap";

import type { Product } from "commonlib/src/Models/Data/Product";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { server } from "commonlib/src/AppSettings";
import { Link } from "react-router-dom";
import { AddToCartButton } from "./AddToCartButton";

interface Props {
    data: Product;
}

export const ProductMiniature = ({ data }: Props) => {
    const [imagePreview, setImagePreview] = React.useState<string | undefined>(undefined);
    
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

    

    return (
        <div className="col-xs-12 col-sm-12 col-md-4">
            <Card
                style={{ marginTop: '20px' }} >
                <Link to={`/products/${data.id}`}>
                    <Card.Img variant="top" src={server + "/" + imagePreview} />
                </Link>
                <Card.Body>
                    <Link to={`/products/${data.id}`} style={{color: "black"}}>
                        <Card.Title>{data.name}</Card.Title>
                        <Card.Text>{data.description}</Card.Text>
                        <Card.Text>Цена {data.price} у.е.</Card.Text>
                    </Link>
                    <AddToCartButton productId={data.id} />
                </Card.Body>
            </Card>
        </div>
    )
}