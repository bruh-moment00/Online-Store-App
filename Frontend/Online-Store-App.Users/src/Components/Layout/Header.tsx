import { Link } from "react-router-dom";

import { Container, Navbar, Nav, Button, } from "react-bootstrap";
import { logout } from "commonlib/src/Services/AuthService";
import { useState } from "react";

export const Header = () => {
    const [logged, setLogged] = useState<boolean>(localStorage.getItem("token") !== null);

    const handleLogout = () => {
        logout();
        setLogged(false);
        window.location.reload();
    };

    return (
        <header>
            <Navbar expand="sm" bg="white" className="border-bottom">
                <Container>
                    <Navbar.Brand>
                        <Link to="/">OS</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse className="justify-content-end">
                        <Nav className="me-auto">
                            <Nav.Link href="/cart">Корзина</Nav.Link>
                            {logged ?
                                <>
                                <Nav.Link href="/orders">Заказы</Nav.Link>
                                <Nav.Link href="/profile">Профиль</Nav.Link>
                                <Nav.Item>
                                    <Button onClick={handleLogout} variant="danger">Выход</Button>
                                </Nav.Item>
                                </>
                                : 
                                <Nav.Link href="/login">
                                    <Button>Войти</Button>
                                </Nav.Link>}
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </header>
    );
};
