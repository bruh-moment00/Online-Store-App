import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { getProductById } from "commonlib/src/Services/DataOperations/ProductsService";
import React from "react";
import { useParams } from "react-router-dom";
import { Page } from "../../LayoutComponents/Page";
import type { Product } from "commonlib/src/Models/Data/Product";
import { BackButton } from "../../Components/BackButton";
import { EditProductImage } from "../../Components/Products/EditProductImage";
import { Button } from "react-bootstrap";
import { UploadFileForm } from "./UploadFileForm";

export const EditProductImagesPage = () => {  
    const [product, setProduct] = React.useState<Product | undefined>(undefined);
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
    
    return(
        <Page title={`Загрузка изображений для товара ${product?.name}`}>
            {imagesRetrieving ? 
                <b>Загрузка</b> :
                <div>                   
                    <UploadFileForm productId={Number(productId)}/>
                    <BackButton/>
                    {
                        imagesURLs?.map((imageURL) => (
                            <div key={imageURL}>
                                <EditProductImage imageURL={imageURL} />
                            </div>                 
                        ))
                    }
                </div>
            }
        <br />       
        </Page>
    );
}