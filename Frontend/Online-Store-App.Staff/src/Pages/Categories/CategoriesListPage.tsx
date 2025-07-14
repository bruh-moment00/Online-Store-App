import React from "react";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";

import { Page } from "../../LayoutComponents/Page";
import { getCategories } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import type { Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { CategoriesList } from "../../Components/Categories/CategoriesList";

export const CategoriesListPage = () => {
  const [categories, setCategories] = React.useState<
    Category[] | undefined
  >();
  const [categoriesLoading, setCategoriesLoading] = React.useState(true);

  React.useEffect(() => {
    let cancelled = false;
    const doGetProducts = async () => {
      const categoriesList = await getCategories();
      if (!cancelled) {
        setCategories(categoriesList);
        setCategoriesLoading(false);
      }
    };
    doGetProducts();
    return () => {
      cancelled = true;
    };
  }, []);

  return (
    <Page title="Категории" tabTitle="Категории">
      <Link to="./create">
        <Button variant="outline-primary">Создать новую категорию</Button>
      </Link>
      <hr />
      {categoriesLoading ? (
        <div>Загрузка...</div>
      ) : (
        <CategoriesList data={categories} />
      )}
    </Page>
  );
};
