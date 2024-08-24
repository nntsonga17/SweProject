import { toast } from 'react-toastify';
import { apiCall } from '..';

export const getAllServices = async () => {
  const request = await apiCall();
  return await request({
    url: `/api/Usluga/getAllServices}`,
    method: 'GET',
  });
};

export const addService = async (body) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/Usluga/addService`,
      method: 'POST',
      data: body,
    });
    toast('Uspesno ste kreirali uslugu!', { type: 'success' });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const updateService = async (paylaod) => {
  const request = await apiCall();
  const { id, body } = paylaod;
  try {
    await request({
      url: `/api/Usluga/updateService/${id}`,
      method: 'POST',
      data: body,
    });
    toast('Uspesno ste kreirali uslugu!', { type: 'success' });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const deleteService = async (id) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/Usluga/removeService/${id}`,
      method: 'DELETE',
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};
