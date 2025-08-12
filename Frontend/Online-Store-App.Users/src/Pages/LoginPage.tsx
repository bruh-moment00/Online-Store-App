import React from "react";
import { Page } from "../Components/Layout/Page";
import { Link, useNavigate } from "react-router-dom";
import { LoginForm } from "../Components/Authentication/LoginForm";

export const LoginPage = () => {
  const navigate = useNavigate();
  React.useEffect(() => {
    if (localStorage.getItem("token")) {
      navigate("/profile");
    }
  });

  return (
    <Page title="Вход в систему">
      <LoginForm />
      <span>Нет аккаунта?</span>
      <Link to="/register">Зарегистрироваться</Link>
    </Page>
  );
};
