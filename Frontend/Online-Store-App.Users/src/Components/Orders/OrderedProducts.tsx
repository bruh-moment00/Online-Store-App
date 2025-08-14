import type { OrderedProduct } from "commonlib/src/Models/Data/OrderedProduct";
import { ProductInOrder } from "../Products/ProductInOrder";

interface Props {
    products: OrderedProduct[]
}

export const OrderedProducts = ({ products }: Props) => {
    return (
        <div>
            {products!.map((product) => (
                <ProductInOrder orderedProduct={product} key={product.id}/>
            ))}
        </div>
    )
}