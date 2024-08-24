import Axios from 'axios';

import { getStorageItem } from '../util/localStorage';

const baseURL = `${process.env.REACT_APP_BASE_API_URL}`;

const apiCall = async (props) => {
  const token = getStorageItem('token');

  const axios = Axios.create({
    baseURL: props?.isStrangeUrl || baseURL,
    headers: {
      Accept: 'application/json',
    },
  });

  axios.interceptors.response.use(
    (res) => res.data,
    ({ response }) => Promise.reject(response)
  );

  if (token) axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;

  return axios;
};

export { apiCall };
