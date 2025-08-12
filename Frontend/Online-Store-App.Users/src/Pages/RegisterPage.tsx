import React from "react"
import { useNavigate } from "react-router-dom";
import { Page } from "../Components/Layout/Page";
import { RegisterForm } from "../Components/Authentication/RegisterForm";

export const RegisterPage = () => {
    const navigate = useNavigate();

    React.useEffect(() => {
        if (localStorage.getItem("token"))
            navigate("/profile");
    });

    return (
        <Page title="Регистрация" tabTitle="Регистрация">
            <RegisterForm />
        </Page>
    )
}