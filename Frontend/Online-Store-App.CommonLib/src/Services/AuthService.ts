import axios, { type AxiosResponse } from "axios";

import { webAPIUrl } from "../AppSettings";

import authHeader from "./AuthHeader";
import { http } from "../http";

export const login = async (
  email: string,
  password: string
): Promise<string | undefined> => {
  return axios
    .post(webAPIUrl + "/login/employee", {
      email: email,
      password: password,
    })
    .then((response) => {
      if (response.data) {
        localStorage.setItem("token", JSON.stringify(response.data));
      }
      return response.data;
    });
};

export const logout = async () => {
  localStorage.removeItem("token");
};

export const getCurrentUserId = async (): Promise<number | undefined> => {
  const result = await http<number>({
    path: "login/getUserId",
    method: "post",
  });
  if (result.ok)
    return result.body
  else 
    return undefined
};

export const getCurrentEmployeeId = async (): Promise<number | undefined> => {
  const result = await http<number>({
    path: "login/getEmployeeid",
    method: "post",
  });
  if (result.ok)
    return result.body
  else 
    return undefined
};