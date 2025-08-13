import type { Category } from "commonlib/src/Models/Data/Category";
import type { Product } from "commonlib/src/Models/Data/Product";
import type { PropertyView } from "commonlib/src/Models/ViewModels/PropertyView";
import { getCategoryById } from "commonlib/src/Services/DataOperations/CategoriesService";
import { getImagesURLByProductId } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { getPropertiesViewByProductId } from "commonlib/src/Services/DataOperations/PropertiesService";
import React from "react";
import { ImagesCarousel } from "./ImagesCarousel";
import { BackButton } from "../BackButton";
import { PropertiesList } from "../Properties/PropertiesList";
import { Button, Table } from "react-bootstrap";
import { getCookie } from "typescript-cookie";
import { AddToCartButton } from "./AddToCartButton";

interface Props {
    product: Product;
}

export const ProductCard = ({ product }: Props) => {
    const [category, setCategory] = React.useState<Category | undefined> (undefined);
    const [properties, setProperties] = React.useState<PropertyView[] | undefined>(undefined);
    const [imagesURLs, setImagesURLs] = React.useState<string[] | undefined>(undefined);
    const [imagesRetrieving, setImagesRetrieving] = React.useState(true);

    const [inCart, setInCart] = React.useState<boolean>(false);

    React.useEffect(() => {
        const doGetCategory = async (categoryId: number) => {
            const foundCategory = await getCategoryById(product.categoryID);
            setCategory(foundCategory);
        }
        const doGetProperties = async (productId: number) => {
            const foundProps = await getPropertiesViewByProductId(productId);
            setProperties(foundProps);
        }
        const doGetImages = async (productId: number) => {
            const foundImagesURLs = await getImagesURLByProductId(productId);
            setImagesURLs(foundImagesURLs);
            setImagesRetrieving(false);
        }

        if (product) {
            doGetCategory(product.categoryID);
            doGetProperties(product.id);
            doGetImages(product.id);
        }
    }, [])

    React.useEffect(() => {
            const getCart = async () => {
                const cart = await getCookie("cart");
                cart?.split(';').forEach(element => {
                    if (Number(element) === product.id)
                        setInCart(true);
                });
            }
            if (product) {
                getCart();
            }
        }, [])

    return (
        <div>
            <div>
                <dl className="row">
                    {imagesRetrieving ? <div></div> : <ImagesCarousel data={imagesURLs} />}
                    <Table>
                        <tbody>
                            <tr>
                                <td>
                                    <dt className="col-sm-2">Наименование</dt>
                                    <dd className="col-sm-10">{product?.name}</dd>
                                </td>
                                <td>
                                    <dt className="col-sm-2">Цена</dt>
                                    <dd className="col-sm-10"><h3>{product?.price} у.е.</h3></dd>
                                    <AddToCartButton productId={product.id} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dt className="col-sm-2">Описание</dt>
                                    <dd className="col-sm-10">{product?.description}</dd>
                                </td>
                            </tr>
                        </tbody>
                    </Table>
                    {!(properties && properties?.length > 0) ? <></> : <PropertiesList data={properties} />}
                    <dt className="col-sm-2">Категория</dt>
                    <dd className="col-sm-10">{category?.name}</dd>
                </dl>
            </div>
            <div className="col-sm-6">
                <BackButton />
            </div>
        </div>
    )
}