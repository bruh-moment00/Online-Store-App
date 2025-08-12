import axios from "axios";

import { webAPIUrl } from "../AppSettings";
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

export const loginUser = async (
  password: string,
  email: string | undefined = undefined,
  phoneNum: string | undefined = undefined,
  login: string | undefined = undefined
): Promise<string | undefined> => {
  return axios
    .post(webAPIUrl + "/login/user", {
      phoneNum: phoneNum,
      login: login,
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
    path: "login/getEmployeeId",
    method: "post",
  });
  if (result.ok)
    return result.body
  else 
    return undefined
};