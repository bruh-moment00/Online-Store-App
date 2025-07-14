import React from "react";

import { Nav, Button } from "react-bootstrap";

import { Link, useSearchParams } from "react-router-dom";

import { type ProductDataWithPaging } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Product";
import { getProducts } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductsService";
import { Page } from "../../LayoutComponents/Page";
import { ProductList } from "../../Components/Products/ProductsList";
import { Paging } from "../../Components/Paging";

export const ProductsListPage = () => {
  const [products, setProducts] = React.useState<
    ProductDataWithPaging | undefined
  >();
  const [productsLoading, setProductsLoading] = React.useState(true);
  const [searchParams] = useSearchParams();

  React.useEffect(() => {
    let cancelled = false;
    const doGetProducts = async (params: URLSearchParams) => {
      const productsList = await getProducts(params);
      if (!cancelled) {
        setProducts(productsList);
        setProductsLoading(false);
      }
    };
    doGetProducts(searchParams);
    return () => {
      cancelled = true;
    };
  }, [searchParams]);

  return (
    <Page title="Список товаров" tabTitle="Список товаров">
      <Link to="./create">
        <Button variant="outline-primary">Создать новый товар</Button>
      </Link>
      <hr />
      {productsLoading ? (
        <div>Загрузка...</div>
      ) : (
        <ProductList data={products?.items} />
      )}
      {products !== undefined && (
        <Nav>
          <Paging
            pageNumber={products.pageNumber}
            totalPages={products.totalPages}
            hasPrevious={products.pageNumber > 1}
            hasNext={products.pageNumber < products.totalCount}
            pageSize={products.pageSize}
          />
        </Nav>
      )}
    </Page>
  );
};
