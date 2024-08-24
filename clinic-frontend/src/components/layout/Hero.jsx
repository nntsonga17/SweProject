import { Link } from "react-router-dom";
import HeroImage from "../../assets/images/hero.jpeg";

export const Hero = () => {
  return (
    <div className="hero">
      <div className="overlay"></div>
      <img src={HeroImage} alt="Clinic Hero Image" />

      <div className="content">
        <h1>Izvanredna zdravstvena nega na dohvat ruke</h1>
        <p>
          Vaš partner u očuvanju zdravlja i ostvarivanju kvalitetnog života –
          Jer vaše blagostanje je naš prioritet.
        </p>

        <div className="link">
          <Link to="/create-appointment">Zakazi pregled</Link>
        </div>
      </div>
    </div>
  );
};
