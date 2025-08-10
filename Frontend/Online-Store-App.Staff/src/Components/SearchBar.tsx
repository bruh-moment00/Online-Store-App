import { Button, Col, Form, Navbar, Row } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { useNavigate, useSearchParams } from "react-router"

type FormData = {
    search: string;
}

export const SearchBar = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();

    const {register, handleSubmit} = useForm<FormData>({mode: "onSubmit"});

    const submitForm = (data: FormData) => {
        if (data.search != "")
            searchParams.set("search", data.search);
        else
            searchParams.delete("search");
        navigate(`?${searchParams.toString()}`);
    }
    return (
        <Navbar>
            <Form onSubmit={handleSubmit(submitForm)}>
                <Row>
                    <Col xs="auto">
                        <Form.Control
                            type="text"
                            placeholder="Поиск"
                            className=" mr-sm-2"
                            {...register("search")}
                            defaultValue={searchParams.get("search") ? searchParams.get("search")! : ""}
                        />
                    </Col>
                    <Col xs="auto">
                        <Button type="submit">Поиск</Button>
                    </Col>
                </Row>
            </Form>
        </Navbar>
    )
}