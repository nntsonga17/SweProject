import { useEffect, useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import { useQuery } from 'react-query';

import { AppRouter } from './routes/index';
import { isActiveClass } from './util/classes';
import { Sidebar } from './components/Sidebar';
import { useAuthStore } from './stores/AuthStore';
import { getStorageItem } from './util/localStorage';
import { fetchAuthUser } from './api/auth';
import { Login } from './components/Login';

export const App = () => {
  const [isExpandedSidebar, setIsExpandedSidebar] = useState(false);
  const { isLogged, setIsLogged, setUser } = useAuthStore();

  const { data } = useQuery('me', fetchAuthUser, {
    enabled: isLogged, // kad je isLogged true, fetchuj ulogovanog usera
  });

  useEffect(() => {
    const token = getStorageItem('token');
    if (token) setIsLogged(true);
  }, []);

  useEffect(() => {
    if (data) setUser(data);
  }, [data]);

  // TODO: Ovo sam zakomentarisao da bih mogao da vidim aplikaciju bez da se logujem, kad se poveze login,
  // odkomentarisite uslov
  return (
    <main className={isActiveClass(isExpandedSidebar, 'pageWrapper')}>
      {/* {isLogged ? ( */}
      <BrowserRouter>
        <Sidebar toggleExpand={() => setIsExpandedSidebar((prev) => !prev)} />
        <AppRouter />
      </BrowserRouter>
      {/* // ) : (
      //   <Login />
      // )} */}
    </main>
  );
};
