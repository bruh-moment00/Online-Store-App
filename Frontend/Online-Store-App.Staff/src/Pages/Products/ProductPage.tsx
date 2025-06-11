import React from "react";

import { Page } from "../../LayoutComponents/Page";

import { useParams } from "react-router-dom";

import { type Product } from "../../Models/Data/Product";
import { BackButton } from "../../Components/BackButton";
import { getProductById } from "../../Services/DataOperations/ProductsService";

export const ProductPage = () => {
  const [product, setProduct] = React.useState<Product | null>(null);

  const { productId } = useParams();

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
    <Page>
      <div>
        <div>
          <h1>Подробно</h1>
        </div>
        <div>
          <dl className="row">
            <dt className="col-sm-2">Наименование</dt>
            <dd className="col-sm-10">{product?.name}</dd>
            <dt className="col-sm-2">Цена</dt>
            <dd className="col-sm-10">{product?.price}</dd>
            <dt className="col-sm-2">Описание</dt>
            <dd className="col-sm-10">{product?.description}</dd>
            {/* <dt className="col-sm-2">Характеристики</dt>
            <dd className="col-sm-10">{product?.specs}</dd> */}
            {/* <dt className="col-sm-2">Производитель</dt>
            <dd className="col-sm-10">{product?.brand.name}</dd> */}
            {/* <dt className="col-sm-2">Категория</dt>
            <dd className="col-sm-10">{product?.category.name}</dd> */}
          </dl>
        </div>
        <div>
          <BackButton />
        </div>
      </div>
    </Page>
  );
};
