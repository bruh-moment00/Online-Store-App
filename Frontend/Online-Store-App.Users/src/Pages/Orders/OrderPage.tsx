import type { Order } from "commonlib/src/Models/Data/Order";
import { getOrderById, getOrderedProductsByOrderId, putOrder } from "commonlib/src/Services/DataOperations/OrdersService";
import React from "react"
import { useParams } from "react-router";
import { OrderStatus } from "commonlib/src/EnumStrings/OrderStatus";
import type { OrderedProduct } from "commonlib/src/Models/Data/OrderedProduct";
import { Page } from "../../Components/Layout/Page";
import { OrderedProducts } from "../../Components/Orders/OrderedProducts";
import { Button } from "react-bootstrap";

export const OrderPage = () => {
    const [order, setOrder] = React.useState<Order | undefined>(undefined);
    const [products, setProducts] = React.useState<OrderedProduct[] | undefined>(undefined);

    const { orderId } = useParams();

    React.useEffect(() => {
        const doGetOrder = async (orderId: number) => {
            const foundOrder = await getOrderById(orderId);
            if (foundOrder) {
                setOrder(foundOrder);
                const foundProducts = await getOrderedProductsByOrderId(orderId);
                if (foundProducts) {
                    setProducts(foundProducts)
                }
            }
        }

        if (orderId) {
            doGetOrder(Number(orderId));
        }
    }, [orderId]);

    const handlePay = async () => {
        if (order) {
            const result = await putOrder({
                id: order.id,
                userID: order.userID,
                status: 1
            });
            if (result) {
                window.location.reload();
            }
        }
    }

    return (
        <Page title={`Заказ № ${order?.id}`}>
            {order ? 
            <div>
                <dl className="row">
                    <dt className="col-sm-2">Номер</dt>
                    <dt className="col-sm-10">{order.id}</dt>
                    <dt className="col-sm-2">Создан</dt>
                    <dt className="col-sm-10">{order.createdDateTime.toLocaleString()}</dt>
                    <dt className="col-sm-2">Итоговая стоимость</dt>
                    <dt className="col-sm-10">{order.totalPrice} у.е.</dt>
                    <dt className="col-sm-2">Статус</dt>
                    <dt className="col-sm-10">{OrderStatus[order.status]}</dt>
                </dl>
                {order.status === 0 ? 
                    <Button onClick={handlePay}>Оплатить</Button> : <></>}
                {products ? 
                <dl className="row">
                    <dt className="col-sm-12">
                        Товары в заказе
                    </dt>
                    <dt className="col-sm-12">
                        <OrderedProducts products={products} />
                    </dt>
                </dl>
                : <></>
                }            
            </div>
            : <></>}
        </Page>
    )

}