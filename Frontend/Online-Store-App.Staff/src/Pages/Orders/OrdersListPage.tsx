import React from "react";

import { Nav } from "react-bootstrap";

import { useSearchParams } from "react-router-dom";

import { type OrderDataWithPaging } from "commonlib/src/Models/Data/Order";
import { getOrders } from "commonlib/src/Services/DataOperations/OrdersService";
import { Page } from "../../LayoutComponents/Page";
import { Paging } from "../../Components/Paging";
import { OrdersList } from "../../Components/Orders/OrdersList";

export const OrdersListPage = () => {
  const [orders, setOrders] = React.useState<
    OrderDataWithPaging | undefined
  >();
  const [ordersLoading, setOrdersLoading] = React.useState(true);
 
  const [searchParams] = useSearchParams();

  React.useEffect(() => {
    let cancelled = false;
    const doGetOrders = async (params: URLSearchParams) => {
      const ordersList = await getOrders(params);
      if (!cancelled) {
        setOrders(ordersList);
        setOrdersLoading(false);
      }
    };
    doGetOrders(searchParams);
    return () => {
      cancelled = true;
    };
  }, [searchParams]);
   
  return (
    <Page title="Обработка заказов" tabTitle="Обработка заказов">
      {ordersLoading ? (
        <div>Загрузка...</div>
      ) : (
        <div>
          <OrdersList data={orders?.items} />
        </div>       
      )}
      {orders !== undefined && (
        <Nav>
          <Paging
            pageNumber={orders.pageNumber}
            totalPages={orders.totalPages}
            hasPrevious={orders.pageNumber > 1}
            hasNext={orders.pageNumber < orders.totalCount}
            pageSize={orders.pageSize}
          />
        </Nav>
      )}
    </Page>
  );
};
