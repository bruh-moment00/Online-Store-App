import { Table } from "react-bootstrap";
import type { Property } from "commonlib/src/Models/Data/Property";
import { PropValueTypeName } from "commonlib/src/EnumStrings/PropValueType";

interface Props {
  data: Property[] | undefined;
}

export const CategoryPropertiesList = ({ data }: Props) => (
  <div className="category-properties">
    <Table>
      <thead>
        <tr>
          <th>Характеристики товаров в категории</th>
          <th>Тип значения</th>
        </tr>
      </thead>
      <tbody>
        {data!.map((property) => (
          <tr key={property.id}>
            <td>{property.propName}</td>
            <td>{PropValueTypeName[property.valueType]}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
