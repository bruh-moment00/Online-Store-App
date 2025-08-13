import React from "react";
import { ProductInCart } from "../Products/ProductInCart";
import { removeCookie, setCookie } from "typescript-cookie";

interface Props {
    data: string;
}

export const Cart = ({ data }: Props) => {
    const [cart, setCart] = React.useState<string[] | undefined>(data.split(';'));

    const handleRemove = (index: number) => {      
        let newCart: string = "";
        if (cart){
            for (let i = 0; i < cart?.length; i++) {
                if (i !== index)
                    newCart = newCart + (cart[i]) + ((i === cart.length - 1) ? "" : ";")
            }
        }       
        if (newCart.length > 0)
            setCookie('cart', newCart); 
        else
            removeCookie('cart');

        window.location.reload();
    }

    const CartMap = () => {
        const rows = [];
        if (cart) {
            for (let i = 0; i < cart?.length; i++) {
                if (cart[i] && !isNaN(Number(cart[i])))
                    rows.push(ProductInCart({
                        productId: Number(cart[i]),
                        onRemove: (() => handleRemove(i))
                }))
            }    
        }  
        return rows;
    }

    return (
        <CartMap />
    )
}