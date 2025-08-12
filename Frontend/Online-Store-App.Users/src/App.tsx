import './App.css'
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import { Header } from './Components/Layout/Header'
import { Footer } from './Components/Layout/Footer';
import { MainPage } from './Pages/MainPage';

function App() {
    return (
        <BrowserRouter>
            <Container>
                <Header/>
                <Routes>
                    <Route path='' element={<MainPage />} />
                </Routes>
                <Footer/>
            </Container>
        </BrowserRouter>
    )
}

export default App
