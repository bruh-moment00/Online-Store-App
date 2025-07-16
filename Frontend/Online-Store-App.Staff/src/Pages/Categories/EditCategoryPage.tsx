import React from "react";
import { Page } from "../../LayoutComponents/Page"
import { createSearchParams, useParams } from "react-router-dom";
import { getProperties } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/PropertiesService";
import type { Property } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Property";
import type { Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";
import { getCategoryById } from "../../../../Online-Store-App.Commonlib/src/Services/DataOperations/CategoriesService";
import { EditCategoryForm } from "../../Components/Categories/EditCategoryForm";
import { EditCategoryPropertiesForm } from "../../Components/Categories/EditCategoryPropertiesForm";

export const EditCategoryPage = () => {
    const [category, setCategory] = React.useState<Category | null>(null);
    const [properties, setProperties] = React.useState<Property[] | undefined> (undefined);

    const { categoryId } = useParams();

    React.useEffect(() => {
        let cancelled = false;

        const doGetCategory = async (categoryId: number) => {
            const foundCategory = await getCategoryById(categoryId);
            if (!cancelled) {
                setCategory(foundCategory);
                
                if (foundCategory) {
                    const foundCategoryProperties = await getProperties(createSearchParams({categoryId: [`${foundCategory.id}`]}));
                    setProperties(foundCategoryProperties);
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
    <Page title="Редактирование">
        <div>
            {category ? <EditCategoryForm category={category} /> : <></>}  
            <h4>Характеристики</h4>
            {(properties) ? <EditCategoryPropertiesForm categoryId={category!.id} properties={properties} /> : <></>}         
        </div>
    </Page>
)
}