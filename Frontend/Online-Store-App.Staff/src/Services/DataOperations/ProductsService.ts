import { http } from "../../http";
import type { Product, ProductDataWithPaging, ProductForPost } from "../../Models/Data/Product";

export const getProductById = async (
    productId: number
): Promise<Product | null> => {
    const result = await http<Product>({
        path: `products/${productId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const getProducts = async (params: URLSearchParams): Promise<ProductDataWithPaging | undefined> => {
    const result = await http<ProductDataWithPaging>({
        path: `products?${params.toString()}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postProduct = async (
    product: ProductForPost
): Promise<number | undefined> => {
    const result = await http<number, ProductForPost>({
        path: "products",
        method: "post",
        body: product
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}