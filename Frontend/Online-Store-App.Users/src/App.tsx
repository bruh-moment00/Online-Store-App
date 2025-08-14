import './App.css'
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import { Header } from './Components/Layout/Header'
import { Footer } from './Components/Layout/Footer';
import { MainPage } from './Pages/MainPage';
import { LoginPage } from './Pages/LoginPage';
import { RegisterPage } from './Pages/RegisterPage';
import { ProductsListPage } from './Pages/Products/ProductsListPage';
import { ProductPage } from './Pages/Products/ProductPage';
import { ProfilePage } from './Pages/Profile/ProfilePage';
import { EditProfilePage } from './Pages/Profile/EditProfilePage';
import { CartPage } from './Pages/Cart/CartPage';
import { OrderPage } from './Pages/Orders/OrderPage';
import { OrdersListPage } from './Pages/Orders/OrdersListPage';

function App() {
    return (
        <BrowserRouter>
            <Container>
                <Header/>
                <Routes>
                    <Route path='' element={<MainPage />} />
                    <Route path='login' element={<LoginPage />} />
                    <Route path='register' element={<RegisterPage />} />
                    <Route path="products" element={<ProductsListPage />} />
                    <Route path="products/:productId" element={<ProductPage />} />
                    <Route path="profile" element={<ProfilePage />} />
                    <Route path="profile/edit" element={<EditProfilePage />} />
                    <Route path='cart' element={<CartPage />} />
                    <Route path="orders" element={<OrdersListPage />} />
                    <Route path="orders/:orderId" element={<OrderPage />} />
                </Routes>
                <Footer/>
            </Container>
        </BrowserRouter>
    )
}

export default App
