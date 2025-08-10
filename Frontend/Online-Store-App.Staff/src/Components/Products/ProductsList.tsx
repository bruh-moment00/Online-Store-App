import { type Product } from "commonlib/src/Models/Data/Product";
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
          <th></th>
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
              </Link>
            </td>
            <td>{product.price}</td>
            <td>
              <Link to={`/products/${product.id}`}>Подробно</Link> | <Link to={`/products/${product.id}/edit`}>Изменить</Link>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
