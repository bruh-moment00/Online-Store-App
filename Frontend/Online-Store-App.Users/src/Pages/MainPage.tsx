import { useState } from "react"
import { Page } from "../Components/Layout/Page"
import type { Category } from "commonlib/src/Models/Data/Category"
import { getCategories } from "commonlib/src/Services/DataOperations/CategoriesService";
import React from "react";
import { CategoriesList } from "../Components/Categories/CategoriesList";

export const MainPage = () => {
    const [categories, setCategories] = useState<Category[] | undefined>(undefined);

    React.useEffect(() => {
        let cancelled = false;
        const doGetProducts = async () => {
            const categoriesList = await getCategories();
            if (!cancelled) {
                setCategories(categoriesList);
            }
        };
        doGetProducts();
        return () => {
            cancelled = true;
        };
    }, []);

    return (
        <Page tabTitle="Главная">
            <div>
                {categories ? 
                <CategoriesList data={categories}/> 
                : <></>}
            </div>
        </Page>
    )
}