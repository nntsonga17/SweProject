import { toast } from 'react-toastify';
import { apiCall } from '..';

export const createReport = async (body) => {
  const request = await apiCall();
  try {
    await request({
      url: `/api/Pregled/createReport`,
      method: 'POST',
      data: body,
    });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const getAllReportssByDoctorId = async (doctorId) => {
  const request = await apiCall();
  return await request({
    url: `/api/Formulars/getAllReportsByDoctorId/${doctorId}`,
    method: 'GET',
  });
};
