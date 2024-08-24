import { Routes, Route } from "react-router-dom";
import { CreatAppointmentPage } from "../../pages/create-formular";
import { HomePage } from "../../pages/home";
import { ServicesPage } from "../../pages/services";

export const AppRouter = () => (
  <Routes>
    <Route path="/" element={<HomePage />} />
    <Route path="/create-formular" element={<CreatAppointmentPage />} />
    <Route path="/services" element={<ServicesPage />} />
  </Routes>
);
