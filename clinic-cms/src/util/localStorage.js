export const getStorageItem = (keyName) => {
  try {
    return JSON.parse(localStorage.getItem(keyName) || 'null');
  } catch (error) {
    return null;
  }
};

export const setStorageItem = (keyName, value) =>
  localStorage.setItem(keyName, JSON.stringify(value));

export const removeStorageItem = (keyName) => localStorage.removeItem(keyName);
