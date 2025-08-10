import { Link, useNavigate } from "react-router-dom";

import { Container, Navbar, Nav, NavDropdown, Button, } from "react-bootstrap";
import { logout } from "commonlib/src/Services/AuthService";

export const Header = () => {
  const navigate = useNavigate();
  const handleLogout = () => {
    logout();
    navigate("/login", {replace: true});
  };

  if (!localStorage.getItem("token")){
    return null;
  }

  return (
    <header>
      <Navbar expand="sm" bg="white" className="border-bottom box-shadow">
        <Container>
          <Navbar.Brand>
            <Link to="/">Name</Link>
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse>
            <Nav className="me-auto">
              <Nav.Link href="/">На главную</Nav.Link>
              <NavDropdown title="Работа с базой">
                <NavDropdown.Item>
                  <Link to="/products">Товары</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/categories">Категории</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/">Заказы</Link>
                </NavDropdown.Item>
              </NavDropdown>
              <Nav.Link href="/profile">Профиль</Nav.Link>
              <Nav.Item>
                <Button onClick={handleLogout} variant="danger">Выход</Button>
              </Nav.Item>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
