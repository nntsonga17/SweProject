import { toast } from 'react-toastify';

import { apiCall } from '../index';
import { removeStorageItem, setStorageItem } from '../../util/localStorage';

export const signIn = async (body) => {
  const request = await apiCall();
  try {
    const { data } = await request({
      url: '/api/ClanKlinike/login',
      method: 'POST',
      data: body,
    });

    setStorageItem('token', data.token);

    toast('Uspesno ste pristupili nalogu!', { type: 'success' });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const register = async (body) => {
  const request = await apiCall();
  try {
    await request({
      url: '/api/ClanKlinike/register',
      method: 'POST',
      data: body,
    });

    toast('Uspesno ste kreirali nalog!', { type: 'success' });
  } catch (error) {
    toast(error.data.message, { type: 'error' });
  }
};

export const fetchAuthUser = async () => {
  const request = await apiCall();
  // ovo je get request u kome se u controlleru proverava da li je valdan token
  // i izvlace podaci o useru iz tokena i vracaju se nazad, pa se taj user stavlja u state
  try {
    // TODO: Pormeni url kad se napravi endpoint!
    const { data } = await request({ url: `/auth/me`, method: 'GET' });
    return data;
  } catch (error) {
    removeStorageItem('token');
    toast(error.data.message, { type: 'error' });
  }
};
