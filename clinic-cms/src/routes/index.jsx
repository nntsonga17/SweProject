import { Routes, Route } from 'react-router-dom';
import { CreateProfilePage } from '../pages/create-profiles';
import { MyFormularsPage } from '../pages/my-formulars';
import { PatientsPage } from '../pages/patients';
import { ProfilePage } from '../pages/profile';
import { ServicesPage } from '../pages/services';
import { UnscheduledFormularsPage } from '../pages/unscheduled-formulars';

import { useAuthStore } from '../stores/AuthStore';
import { DoctorsPage } from '../pages/doctors';

export const AppRouter = () => {
  const { user } = useAuthStore();

  // TODO: Proveri da li je kljuc .role i da li se rola zove  admin
  const isAdmin = user?.role === 'admin';

  return (
    <aside className="appHolder">
      <div className="pageHolder customScrollbar">
        <Routes>
          <Route path="/" element={<ProfilePage />} />
          <Route
            path="/unscheduled-formulars"
            element={<UnscheduledFormularsPage />}
          />
          <Route path="/my-formulars" element={<MyFormularsPage />} />
          <Route path="/patients" element={<PatientsPage />} />
          {/* TODO: Promeni ovo "true" na isAdmin  */}
          {true && (
            <>
              <Route path="/create-profiles" element={<CreateProfilePage />} />
              <Route path="/services" element={<ServicesPage />} />
              <Route path="/doctors" element={<DoctorsPage />} />
            </>
          )}
        </Routes>
      </div>
    </aside>
  );
};
