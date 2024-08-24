import create from 'zustand';

const useAuthStore = create((set) => ({
  isLogged: false,
  setIsLogged: (isLogged) => set({ isLogged }),
  user: undefined,
  setUser: (user) => set({ user }),
}));

export { useAuthStore };
