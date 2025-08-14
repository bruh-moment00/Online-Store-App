import type { Order } from "commonlib/src/Models/Data/Order";
import { getOrderById, getOrderedProductsByOrderId, putOrder } from "commonlib/src/Services/DataOperations/OrdersService";
import React from "react"
import { useParams } from "react-router";
import { Page } from "../../LayoutComponents/Page";
import { OrderStatus } from "commonlib/src/EnumStrings/OrderStatus";
import type { OrderedProduct } from "commonlib/src/Models/Data/OrderedProduct";
import { OrderedProducts } from "../../Components/Orders/OrderedProducts";
import { Button, Form, FormGroup } from "react-bootstrap";
import { useForm } from "react-hook-form";

type FormData = {
    status: number;
}

export const OrderPage = () => {
    const [order, setOrder] = React.useState<Order | undefined>(undefined);
    const [products, setProducts] = React.useState<OrderedProduct[] | undefined>(undefined);

    const { orderId } = useParams();

    const {register, handleSubmit} = useForm<FormData>({mode: "onSubmit"});

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

    const submitForm = async (data: FormData) => {
        if (order) {
            const result = await putOrder({
                id: order.id,
                userID: order.userID,
                status: Number(data.status)
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
                <form onSubmit={handleSubmit(submitForm)}>
                    <FormGroup>
                        <label className="control-label">Изменить статус</label>
                        <Form.Select 
                            id="status" 
                            defaultValue={order.status}
                            {...register('status', {required: true})}>
                                {OrderStatus.map((status) => (
                                    <option key={status} value={OrderStatus.indexOf(status)}>
                                        {status}
                                    </option>
                                ))}
                        </Form.Select>
                    </FormGroup>
                    <Button type="submit">Применить</Button>
                </form>                
            </div>
            : <></>}
        </Page>
    )

}