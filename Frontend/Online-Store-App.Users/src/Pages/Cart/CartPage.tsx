import { Page } from "../../Components/Layout/Page";
import { Cart } from "../../Components/Cart/Cart";
import { getCookie } from "typescript-cookie";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";
import React from "react";
import { getProductsCost } from "commonlib/src/Services/DataOperations/ProductsService";
import { CreateOrderButton } from "../../Components/Cart/CreateOrderButton";

export const CartPage = () => {
    const cart = getCookie('cart');

    const [cost, setCost] = React.useState<number | undefined>();

    React.useEffect(() => {
        const doGetCost = async (ids: number[]) => {
            const cost = await getProductsCost(ids);
            if (cost) {
                setCost(cost);
            }
        }
        if (cart){
            const productIds = cart?.split(';');
            let ids: number[] = [];
            productIds.forEach(id => {
                ids.push(Number(id));
            });
            
            doGetCost(ids);
        }                 
    }, [cart])

    return(
        <Page title="Корзина" tabTitle="Корзина">
        {!cart ? (
            <span>Корзина пуста</span>
        ) : <>
                <span>Итоговая стоимость: {cost} у.е.</span>
                <CreateOrderButton />
                <Cart data={cart!}/>
            </>}
        </Page>
    )
}