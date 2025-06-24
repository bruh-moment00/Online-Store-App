import { http } from "../../http";
import type { Category, CategoryForPost } from "../../Models/Data/Category";

export const getCategoryById = async (
    productId: number
): Promise<Category | null> => {
    const result = await http<Category>({
        path: `categories/${productId}`
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

export const postProduct = async (
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