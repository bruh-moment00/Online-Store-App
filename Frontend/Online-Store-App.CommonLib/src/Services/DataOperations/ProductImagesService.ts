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
    let fileBody = new FormData();
    fileBody.append('file', image);

    fileBody.append('productId', productId.toString());  
    
    const result = await http<number, File>({
        path: `products/images`,
        method: "post",
        body: image
    }, fileBody);
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }    
}

export const renameImage = async (address: string, newName: string): Promise<boolean | undefined> => {
    const result = await http<boolean, string>({
        path: `products/images?newName=${newName}`,
        method: "put",
        body: address
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }  
}

export const deleteImage = async (address: string): Promise<boolean | undefined> => {
    const result = await http<boolean, string>({
        path: "products/images",
        method: "delete",
        body: address
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }  
}