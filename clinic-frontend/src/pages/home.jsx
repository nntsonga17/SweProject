import { AboutUs } from "../components/layout/AboutUs";
import { Hero } from "../components/layout/Hero";
import { OurTeam } from "../components/layout/OurTeam";
import { Services } from "../components/layout/Services";

export const HomePage = () => {
  return (
    <div className="home">
      <Hero />
      <div className="container">
        <Services />
        <AboutUs />
        <OurTeam />
      </div>
    </div>
  );
};
