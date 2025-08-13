import React from "react";
import { Button } from "react-bootstrap";
import { getCookie, setCookie } from "typescript-cookie";

interface Props {
    productId: number
}

export const AddToCartButton = ({ productId }: Props) => {
    const [inCart, setInCart] = React.useState<boolean>(false);

    React.useEffect(() => {
        const getCart = async () => {
            const cart = await getCookie("cart");
            cart?.split(';').forEach(element => {
                if (Number(element) === productId)
                    setInCart(true);
            });
        }
        if (productId) {
            getCart();
        }
    }, []);

    const handleCartClick = () => {
        const cart = getCookie("cart");
        setCookie("cart", cart + `;${productId}`);
        setInCart(true);
    }

    return (
        <>
            {inCart ?
                <Button variant="primary" onClick={handleCartClick}>В корзине</Button> :
                <Button variant="outline-primary" onClick={handleCartClick}>В корзину</Button>
            }
        </>
    )
}