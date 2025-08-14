import { http } from "../../http";
import type { Order, OrderDataWithPaging, OrderForPut } from "../../Models/Data/Order";
import type { OrderedProduct, OrderedProductForPost } from "../../Models/Data/OrderedProduct";

export const getOrderById = async (
    orderId: number
): Promise<Order | null> => {
    const result = await http<Order>({
        path: `orders/${orderId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const getOrders = async (params: URLSearchParams): Promise<OrderDataWithPaging | undefined> => {
    const result = await http<OrderDataWithPaging>({
        path: `orders?${params.toString()}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postOrder = async (): Promise<number | undefined> => {
    const result = await http<number>({
        path: "orders",
        method: "post",
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const putOrder = async (
    order: OrderForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, OrderForPut>({
        path: `orders/${order.id}`,
        method: "put",
        body: order
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deleteOrder = async (
    orderId: number
): Promise<number | undefined> => {
    const result = await http<number>({
        path: `orders/${orderId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return undefined;
    }
}

export const getOrderedProductsByOrderId = async (orderId: number): Promise<OrderedProduct[] | undefined> => {
    const result = await http<OrderedProduct[]>({
        path: `orders/products?orderId=${orderId}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postProductToOrder = async (
    product: OrderedProductForPost
): Promise<number | undefined> => {
    const result = await http<number, OrderedProductForPost>({
        path: "orders/products",
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

export const deleteOrderedProduct = async (
    orderedProductId: number
): Promise<number | undefined> => {
    const result = await http<number>({
        path: `orders/products/${orderedProductId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return undefined;
    }
}