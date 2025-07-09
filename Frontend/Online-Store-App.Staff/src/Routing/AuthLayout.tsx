import { Navigate, Outlet } from "react-router";

export default function AuthLayout() {

    return localStorage.getItem("token") ? <Outlet /> : <Navigate to='/login' replace />
}