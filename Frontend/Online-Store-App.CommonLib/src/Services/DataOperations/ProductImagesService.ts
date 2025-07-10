import { http } from "../../http";

export const getImagesURLByProductId = async (productId: number): Promise<string[] | undefined> => {
    const result = await http<string[]>({
        path: `products/images?productId=${productId}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const uploadImage = async (image: File, productId: number): Promise<number | undefined> => {
    const result = await http<number, File>({
        path: `products/images?productID=${productId}`,
        method: "post",
        body: image
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }    
}