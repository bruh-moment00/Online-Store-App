import React from "react";
import { Button } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";

import { Page } from "../../LayoutComponents/Page";
import { getCategories, postCategory } from "commonlib/src/Services/DataOperations/CategoriesService";
import type { Category } from "commonlib/src/Models/Data/Category";
import { CategoriesList } from "../../Components/Categories/CategoriesList";

export const CategoriesListPage = () => {
  const [categories, setCategories] = React.useState<Category[] | undefined>();
  const [categoriesLoading, setCategoriesLoading] = React.useState(true);

  const navigate = useNavigate();

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

  const handleCreate = async () => {
    const newName = prompt("Введите наименование категории:")
    if (newName) {
      const result = await postCategory({name: newName});
      if (result) {
        navigate(`${result}`);
      }
    }
  }

  return (
    <Page title="Категории" tabTitle="Категории">
      <Button variant="outline-primary" onClick={handleCreate}>Создать новую категорию</Button>
      <hr />
      {categoriesLoading ? (
        <div>Загрузка...</div>
      ) : (
        <CategoriesList data={categories} />
      )}
    </Page>
  );
};
