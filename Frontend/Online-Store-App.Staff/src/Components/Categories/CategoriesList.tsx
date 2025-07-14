import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import type { Category } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Category";

interface Props {
  data: Category[] | undefined;
}

export const CategoriesList = ({ data }: Props) => (
  <div className="">
    <Table>
      <thead>
        <tr>
          <th>Наименование</th>
        </tr>
      </thead>
      <tbody>
        {data!.map((category) => (
          <tr key={category.id}>
            <td>
              <Link to={`/categories/${category.id}`}>
                {category.name}
                <br />
              </Link>
            </td>
            <td>
              Изменить | <Link to={`/categories/${category.id}`}>Подробно</Link> |
              Удалить
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
