import { type Order } from "commonlib/src/Models/Data/Order";
import { OrderStatus } from "commonlib/src/EnumStrings/OrderStatus"
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
  data: Order[] | undefined;
}

export const OrdersList = ({ data }: Props) => (
  <div className="">
    <Table>
      <thead>
        <tr>
            <th>Номер</th>
            <th>Создан</th>
            <th>Статус</th>
            <th></th>
        </tr>
      </thead>
      <tbody>
        {data!.map((order) => (
          <tr key={order.id}>
            <td><Link to={`/orders/${order.id}`}>{order.id}</Link></td>
            <td>
                <Link to={`/orders/${order.id}`}>{order.createdDateTime.toLocaleString()}</Link>
            </td>
            <td>
              <Link to={`/orders/${order.id}`}>
                {OrderStatus[order.status]}
                <br />
              </Link>
            </td>            
            <td>
              <Link to={`/orders/${order.id}`}>Подробно</Link>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  </div>
);
