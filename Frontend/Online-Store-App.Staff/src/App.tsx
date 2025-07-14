import "./css/App.css";
import "./css/CustomStyle.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Routes, Route } from "react-router-dom";

import { Header } from "./LayoutComponents/Header";
import { Footer } from "./LayoutComponents/Footer";
import { MainPage } from "./Pages/MainPage";
import { ProductPage } from "./Pages/Products/ProductPage";
import { ProductsListPage } from "./Pages/Products/ProductsListPage";
import { AddProductPage } from "./Pages/Products/AddProductPage";
import { LoginPage } from "./Pages/LoginPage";
import AuthLayout from "./Routing/AuthLayout";
import { EditProductPage } from "./Pages/Products/EditProductPage";
import { Container } from "react-bootstrap";
import { CategoriesListPage } from "./Pages/Categories/CategoriesListPage";
// import { ProfilePage } from "./Pages/ProfilePage";

function App() {
  return (
    <BrowserRouter>
      <Container>
        <Header />
        <Routes>
          <Route path="login" element={<LoginPage />} />
          <Route element={<AuthLayout />}>
            <Route path="" element={<MainPage />}  />
            <Route path="products" element={<ProductsListPage />} />
            <Route path="products/:productId" element={<ProductPage />} />
            <Route path="products/:productId/edit" element={<EditProductPage />} />
            <Route path="products/create" element={<AddProductPage />} />
            <Route path="categories" element={<CategoriesListPage />} />
          </Route>
          {/* <Route path="Profile" element={<ProfilePage />} /> */}
        </Routes>
        <Footer />
      </Container>
    </BrowserRouter>
  );
}

export default App;