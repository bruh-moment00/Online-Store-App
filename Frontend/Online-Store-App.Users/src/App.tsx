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
                </Routes>
                <Footer/>
            </Container>
        </BrowserRouter>
    )
}

export default App
