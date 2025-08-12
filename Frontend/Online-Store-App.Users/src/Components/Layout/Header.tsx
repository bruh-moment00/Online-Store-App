import { Link } from "react-router-dom";

import { Container, Navbar, Nav, NavDropdown, Button, } from "react-bootstrap";
import { logout } from "commonlib/src/Services/AuthService";

export const Header = () => {
    const handleLogout = () => {
        logout();
    };

    return (
        <header>
            <Navbar expand="sm" bg="white" className="border-bottom box-shadow">
                <Container>
                    <Navbar.Brand>
                        <Link to="/">OS</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse>
                        <Nav className="me-auto">
                            <Nav.Link href="/profile">Профиль</Nav.Link>
                            {localStorage.getItem("token") ?
                                <Nav.Item>
                                    <Button onClick={handleLogout} variant="danger">Выход</Button>
                                </Nav.Item>
                            : <></>}
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </header>
    );
};
