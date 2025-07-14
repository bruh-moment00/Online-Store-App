import { Table } from "react-bootstrap";
import type { Property } from "../../../../Online-Store-App.Commonlib/src/Models/Data/Property";

interface Props {
  data: Property[] | undefined;
}

export const CategoryPropertiesList = ({ data }: Props) => (
  <div className="category-properties">
    <Table>
      <thead>
        <tr>
          <th>Характеристики</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {data!.map((property) => (
          <tr key={property.id}>
            <td>{property.propName}</td>
            <td>{property.valueType}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
