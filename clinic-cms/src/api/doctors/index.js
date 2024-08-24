import { toast } from 'react-toastify';
import { apiCall } from '..';

export const getAllDoctors = async () => {
  const request = await apiCall();
  return await request({
    url: `/api/ClanKlinike/getAllDoctors`,
    method: 'GET',
  });
};

export const updateDoctor = async (payload) => {
  const request = await apiCall();
  const { id, body } = payload;
  try {
    await request({
      url: `/api/ClanKlinike/updateDoctor/${id}`,
      method: 'PUT',
      data: body,
    });
    toast('Uspesno ažurirani podaci!', { type: 'success' });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const deleteDoctor = async (email) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/ClanKlinike/removeDoctor/${email}`,
      method: 'DELETE',
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};
