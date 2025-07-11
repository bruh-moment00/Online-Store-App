import React from "react";
import { Page } from "../../LayoutComponents/Page";

import { useForm } from "react-hook-form";
import { postProduct } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/ProductsService";
import {
  Form,
  FormGroup,
  Button,
} from "react-bootstrap";
import { type Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { getCategories } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import { useNavigate } from "react-router";

type FormData = {
  name: string;
  category: any;
  price: number;
  description: string;
};

export const AddProductPage = () => {
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);
  
    let navigate = useNavigate();

  const {
    register,
    handleSubmit,
  } = useForm<FormData>({
    mode: "onBlur",
  });

  const submitForm = async (data: FormData) => {
    const result = await postProduct({
      categoryId: data.category,
      name: data.name,
      price: data.price,
      description: data.description,
    });
    setSuccessfullySubmitted(result !== undefined);
    if (result !== undefined) {
      navigate(`../products/${result}`); 
    }
  };

  const [categories, setCategories] = React.useState<Category[] | undefined>();
  const [categoriesLoading, setCategoriesLoading] = React.useState(true);

  React.useEffect(() => {
    let cancelled = false;
    const doGetCategories = async () => {
      const CategoryList = await getCategories();
      if (!cancelled) {
        setCategories(CategoryList);
        setCategoriesLoading(false);
      }
    };
    doGetCategories();
    return () => {
      cancelled = true;
    };
  }, []);

  return (
    <Page title="Добавить новый товар" tabTitle="Добавить товар">
      <form onSubmit={handleSubmit(submitForm)}>
        <fieldset>
          <FormGroup>
            <label className="control-label">Категория</label>
            <Form.Select id="categoryId" {...register('category', { required: true })}>
              <option unselectable="on">Выберите категорию</option>
              {categoriesLoading ? (
                <option>Загрузка...</option>
              ) : (
                categories!.map((category) => (
                  <option key={category.id} value={category.id}>{category.name}</option>
                ))
              )}
            </Form.Select>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Наименование</label>
            <Form.Control id="name" {...register('name', { required: true })}></Form.Control>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Цена</label>
            <Form.Control id="price" {...register('price', { required: true })}></Form.Control>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Описание</label>
            <Form.Control as="textarea" id="description" {...register('description', { required: true })}></Form.Control>
          </FormGroup>
          <FormGroup>
            <Button type="submit">Добавить</Button>
          </FormGroup>
        </fieldset>
      </form>
    </Page>
  );
};