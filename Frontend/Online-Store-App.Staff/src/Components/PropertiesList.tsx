import { Table } from "react-bootstrap";
import type { PropertyView } from "../../../Online-Store-App.Commonlib/src/Models/ViewModels/PropertyView";

interface Props {
  data: PropertyView[] | undefined;
}

export const PropertiesList = ({ data }: Props) => (
  <div className="properties">
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
            <td>{property.name}</td>
            <td>{property.value}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
