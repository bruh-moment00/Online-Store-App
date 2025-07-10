import React from "react";

import { Page } from "../../LayoutComponents/Page";

import { Link, useParams } from "react-router-dom";

import { type Product } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Product";
import { BackButton } from "../../Components/BackButton";
import { getProductById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductsService";
import { type Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { getCategoryById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import { Button } from "react-bootstrap";
import { getPropertiesViewByProductId } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/PropertiesService";
import { type PropertyView } from "../../../../Online-Store-App.Commonlib/src/Models/ViewModels/PropertyView";
import { PropertiesList } from "../../Components/PropertiesList";
import { getImagesURLByProductId } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductImagesService";
import { ImagesCarousel } from "../../Components/ImagesCarousel";

export const ProductPage = () => {
  const [product, setProduct] = React.useState<Product | null>(null);
  const [category, setCategory] = React.useState<Category | null> (null);
  const [properties, setProperties] = React.useState<PropertyView[] | undefined> (undefined);
  const [propertiesLoading, setPropertiesLoading] = React.useState(true);
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
          const foundProps = await getPropertiesViewByProductId(productId);
          setProperties(foundProps);
          setPropertiesLoading(false);
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
    <Page title={`Подробно ${product?.name}`} tabTitle="Подробно">
      <div>
        <div>
          <dl className="row">
            {imagesRetrieving ? <div></div> : <ImagesCarousel data={imagesURLs} /> }
            <dt className="col-sm-2">Наименование</dt>
            <dd className="col-sm-10">{product?.name}</dd>
            <dt className="col-sm-2">Цена</dt>
            <dd className="col-sm-10">{product?.price}</dd>
            <dt className="col-sm-2">Описание</dt>
            <dd className="col-sm-10">{product?.description}</dd>
            {propertiesLoading && !(properties && properties?.length > 0) ? <div>Загрузка</div> : <PropertiesList data={properties} /> }
            <dt className="col-sm-2">Категория</dt>
            <dd className="col-sm-10">{category?.name}</dd>
          </dl>
        </div>
        <div className="col-sm-6">
          <Link to="edit">
          <Button>Редактировать</Button>
          </Link>
        </div>
        <div className="col-sm-6">
          <BackButton />
        </div>
      </div>
    </Page>
  );
};
