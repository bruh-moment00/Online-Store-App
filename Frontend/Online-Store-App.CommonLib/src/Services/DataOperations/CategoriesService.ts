import { http } from "../../http";
import type { Category, CategoryForPost, CategoryForPut } from "../../Models/Data/Category";

export const getCategoryById = async (
    categoryId: number
): Promise<Category | null> => {
    const result = await http<Category>({
        path: `categories/${categoryId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const getCategories = async (): Promise<Category[] | undefined> => {
    const result = await http<Category[]>({
        path: `categories`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postCategory = async (
    category: CategoryForPost
): Promise<number | undefined> => {
    const result = await http<number, CategoryForPost>({
        path: "categories",
        method: "post",
        body: category
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const putCategory = async (
    category: CategoryForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, CategoryForPut>({
        path: "categories",
        method: "put",
        body: category
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const deleteCategory = async (
    categoryId: number
): Promise<number | null> => {
    const result = await http<number>({
        path: `categories/${categoryId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}