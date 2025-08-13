import { Page } from "../../Components/Layout/Page";
import { Cart } from "../../Components/Cart/Cart";
import { getCookie } from "typescript-cookie";

export const CartPage = () => {
    const cart = getCookie('cart');

    return(
        <Page title="Корзина" tabTitle="Корзина">
        {!cart ? (
            <span>Корзина пуста</span>
        ) : <Cart data={cart!}/>}
        </Page>
    )
}