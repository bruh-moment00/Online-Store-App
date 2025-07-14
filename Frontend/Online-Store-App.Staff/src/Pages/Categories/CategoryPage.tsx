import React from "react";

import { Page } from "../../LayoutComponents/Page";

import { createSearchParams, Link, useNavigate, useParams } from "react-router-dom";

import { BackButton } from "../../Components/BackButton";
import { type Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { deleteCategory, getCategoryById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import { Button } from "react-bootstrap";
import type { Property } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Property";
import { CategoryPropertiesList } from "../../Components/Categories/CategoryProperties";
import { getProperties } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/PropertiesService";

export const CategoryPage = () => {
  const [category, setCategory] = React.useState<Category | null> (null);
  const [properties, setProperties] = React.useState<Property[] | undefined> (undefined);

  const { categoryId } = useParams();

  const navigate = useNavigate();

  const handleDelete = (event: React.MouseEvent<HTMLButtonElement>) => {
    if (category && confirm("Точно удалить данную категорию?")) {
      const result = deleteCategory(category.id);
      if (result != null) {
        navigate("/categories")
      }      
    }
  }

  React.useEffect(() => {
    let cancelled = false;
    
    const doGetCategory = async (categoryId: number) => {
      const foundCategory = await getCategoryById(categoryId);
      if (!cancelled) {
        setCategory(foundCategory);

        if (foundCategory) {
            const foundProps = await getProperties(createSearchParams({categoryId: [`${foundCategory.id}`]}));
            setProperties(foundProps);
        }
      }
    };

    if (categoryId) {
      doGetCategory(Number(categoryId));
    }
    return () => {
      cancelled = true;
    };
  }, [categoryId]);

  return (
    <Page title={`Параметры категории "${category?.name}"`} tabTitle="Подробно">
      <div>
        <div>
          <dl className="row">
            <dt className="col-sm-2">Наименование</dt>
            <dd className="col-sm-10">{category?.name}</dd>
            <h6>Характеристики товаров в категории</h6>
            {!(properties && properties?.length > 0) ? <></> : <CategoryPropertiesList data={properties} /> }
          </dl>
        </div>
        <div className="col-sm-6">
          <Link to="edit">
            <Button>Редактировать</Button>
          </Link>
          <Button variant="danger" onClick={handleDelete}>Удалить</Button>
        </div>
        <div className="col-sm-6">
          <BackButton />
        </div>
      </div>
    </Page>
  );
};
