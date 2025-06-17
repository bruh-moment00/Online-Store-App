import { Navigate, Outlet } from "react-router";

export default function AuthLayout() {

    return localStorage.getItem("employee_token") ? <Outlet /> : <Navigate to='/login' replace />
}