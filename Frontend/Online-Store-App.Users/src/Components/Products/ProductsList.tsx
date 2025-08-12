import type { Product } from "commonlib/src/Models/Data/Product";
import { ProductMiniature } from "./ProductMiniature";

interface Props {
    data: Product[] | undefined;
}

export const ProductsList = ({ data }: Props) => {
    return (
        <div className="row">
            {data!.map((product) => (
                <ProductMiniature data={product} key={product.id}/>
            ))}
        </div>       
    )
}