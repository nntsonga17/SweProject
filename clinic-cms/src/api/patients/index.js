import { toast } from 'react-toastify';
import { apiCall } from '..';

export const getAllPatients = async () => {
  const request = await apiCall();
  return await request({ url: `/api/Pacijent/getAllPatients`, method: 'GET' });
};

export const deletePatient = async (id) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/Pacijent/removePatient/${id}`,
      method: 'DELETE',
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};
