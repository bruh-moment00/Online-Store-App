import { http } from "../../http";
import type { Product, ProductDataWithPaging, ProductForPost, ProductForPut } from "../../Models/Data/Product";

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

export const putProduct = async (
    product: ProductForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, ProductForPut>({
        path: `products/${product.id}`,
        method: "put",
        body: product
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deleteProduct = async (
    productId: number
): Promise<number | null> => {
    const result = await http<number>({
        path: `products/${productId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}