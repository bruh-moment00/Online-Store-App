import { Link } from "react-router-dom";
import type { Category } from "commonlib/src/Models/Data/Category";

interface Props {
  data: Category[] | undefined;
}

export const CategoriesList = ({ data }: Props) => (
  <div className="row">
    {data!.map((category) => (
        <div className="col-xs-12 col-sm-12 col-md-4" key={category.id}>
            <Link to={`/products?categoryId=${category.id}`}>
                <div className="floating-block transition">
                    <h4>{category.name}</h4>
                </div>
            </Link>
        </div>
    ))}
  </div>
);
