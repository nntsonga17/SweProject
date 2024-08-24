import { toast } from "react-toastify";
import Axios from "axios";

const baseURL = `${process.env.REACT_APP_BASE_API_URL}`;

const apiCall = async (props) => {
  const axios = Axios.create({
    baseURL: props?.isStrangeUrl || baseURL,
    headers: { Accept: "application/json" },
  });
  axios.interceptors.response.use(
    (res) => res.data,
    ({ response }) => Promise.reject(response)
  );
  return axios;
};

export const createFormular = async (body) => {
  const request = await apiCall();
  try {
    await request({
      url: "/api/Formular/createFormular",
      method: "POST",
      data: body,
    });
    toast("Uspesno ste kreirali formular!", { type: "success" });
  } catch (error) {
    toast(error.data.message, { type: "error" });
  }
};

export const getAllDoctors = async () => {
  const request = await apiCall();
  return await request({
    url: `/api/ClanKlinike/getAllDoctors`,
    method: "GET",
  });
};

export const getAllServices = async () => {
  const request = await apiCall();
  return await request({
    url: `/api/Usluga/getAllServices}`,
    method: "GET",
  });
};
