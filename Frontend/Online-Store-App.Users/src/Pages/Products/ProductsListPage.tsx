import React from "react";

import type { ProductDataWithPaging } from "commonlib/src/Models/Data/Product"
import { getProducts } from "commonlib/src/Services/DataOperations/ProductsService";
import { useNavigate, useSearchParams } from "react-router-dom";
import { getCategories } from "commonlib/src/Services/DataOperations/CategoriesService";
import type { Category } from "commonlib/src/Models/Data/Category";
import { Page } from "../../Components/Layout/Page";
import { Form } from "react-bootstrap";
import { ProductsList } from "../../Components/Products/ProductsList";

export const ProductsListPage = () => {
    const [products, setProducts] = React.useState<ProductDataWithPaging | undefined>(undefined);
    const [productsLoading, setProductsLoading] = React.useState(true);
    const [categories, setCategories] = React.useState<Category[] | undefined>();

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

    React.useEffect(() => {
        let cancelled = false;
        const doGetCategories = async () => {
            const CategoryList = await getCategories();
            if (!cancelled) {
                setCategories(CategoryList);
            }
        };
        doGetCategories();
        return () => {
            cancelled = true;
        };
    }, []);

    const navigate = useNavigate();

    const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const id = e.currentTarget.value;
        if (id != "-1")
            searchParams.set('categoryId', e.currentTarget.value)
        else
            searchParams.delete('categoryId');

        navigate(`?${searchParams.toString()}`);
    }

    const getCategoryFromParams = (): number => {
        let result = searchParams.get('categoryId');
        if (Number(result)) {
            return Number(result);
        }
        else
            return -1;
    }

    return (
        <Page title="Товары" tabTitle="Товары">
            {productsLoading ? (
                <div>Загрузка...</div>
            ) : (
                <div>
                    <Form.Select onChange={handleChange} defaultValue={getCategoryFromParams()}>
                        <option value={-1}>Выберите категорию</option>
                        {!categories ? (
                            <option>Загрузка...</option>
                        ) : (
                            categories!.map((category) => (
                                <option
                                    key={category.id}
                                    value={category.id}>
                                    {category.name}
                                </option>
                            ))
                        )}
                    </Form.Select>
                    <ProductsList data={products?.items} />
                </div>
            )}
        </Page>
    )
}