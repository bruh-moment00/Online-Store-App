import type { OrderedProduct } from "commonlib/src/Models/Data/OrderedProduct";
import { ProductMiniature } from "../Products/ProductMiniature";

interface Props {
    products: OrderedProduct[]
}

export const OrderedProducts = ({ products }: Props) => {
    return (
        <div>
            {products!.map((product) => (
                <ProductMiniature orderedProduct={product} key={product.id}/>
            ))}
        </div>
    )
}