import { postOrder, postProductToOrder } from "commonlib/src/Services/DataOperations/OrdersService";
import React from "react";
import { Button } from "react-bootstrap"
import { useNavigate } from "react-router-dom";
import { getCookie, removeCookie } from "typescript-cookie";

export const CreateOrderButton = () => {
    const [created, setCreated] = React.useState<boolean>(false);
    const cart = getCookie('cart');

    const navigate = useNavigate();

    const handleClick = () => {
        const createOrder = async(productIds: number[]) => {
            const orderId = await postOrder();
            if (orderId) {
                productIds.forEach(id => {
                    postProductToOrder({
                        orderID: orderId,
                        productID: id
                    });
                });
                setCreated(true);
                removeCookie('cart');
                setTimeout(() => {navigate(`orders/${orderId}`)}, 1500);
            }
        }

        if (cart) {
            const cartArray = cart.split(';');
            let productIds: number[] = [];
            cartArray.forEach(idStr => {
                if (Number(idStr))
                    productIds.push(Number(idStr));
            });
            createOrder(productIds);            
        }      
    };

    return (
        <Button onClick={handleClick}>Оформить заказ</Button>
    )
}