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