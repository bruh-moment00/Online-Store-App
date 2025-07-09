import { type Product } from "../../../Online-Store-App.Commonlib/src/Models/Data/Product";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
  data: Product[] | undefined;
}

export const ProductList = ({ data }: Props) => (
  <div className="">
    <Table>
      <thead>
        <tr>
          <th>Наименование</th>
          <th>Цена</th>
          <th>Производитель</th>
          <th>Категория</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {data!.map((product) => (
          <tr key={product.id}>
            <td>
              <Link to={`/products/${product.id}`}>
                {product.name}
                <br />
                {/* {product.image ? (
                  <img src={product.image} height="150" alt="" />
                ) : (
                  ""
                )} */}
              </Link>
            </td>
            <td>{product.price}</td>
            <td>{product.categoryID}</td>
            <td>
              Изменить | <Link to={`/products/${product.id}`}>Подробно</Link> |
              Удалить
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
