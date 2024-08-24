import { toast } from 'react-toastify';
import { apiCall } from '..';

export const getFormulars = async (scheduled) => {
  const request = await apiCall();
  return await request({
    url: `/api/Formular/getFormulars/${scheduled}`,
    method: 'GET',
  });
};

export const getFormularsByDoctorId = async (doctorId) => {
  const request = await apiCall();
  return await request({
    url: `/api/Formulars/getFormularsByDoctorId/${doctorId}`,
    method: 'GET',
  });
};

export const scheduleFormular = async (body) => {
  const request = await apiCall();
  const { formularId, dateTime, doctorId } = body;
  try {
    // TODO: Mozda dateTime pravi problem da se posalje kroz url, ili se treba formatirati datum
    // ili da se posalje sve kroz body (pametnije)
    await request({
      url: `/api/Formular/scheduleFormular/${formularId}/${dateTime}/${doctorId}`,
      method: 'PUT',
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const deleteFormular = async (id) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/Formular/removeFormular/${id}`,
      method: 'DELETE',
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};
