import { Link } from "react-router-dom";
import { Facebook } from "../../assets/icons/Facebook";
import { Instagram } from "../../assets/icons/Instagram";
import { navLinks } from "../../components/abstract/Header";

export const Footer = () => (
  <>
    <div className="footer">
      <svg
        className="wave"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 1440 320">
        <path
          fill="#1d1d1e"
          fillOpacity="1"
          d="M0,128L48,160C96,192,192,256,288,261.3C384,267,480,213,576,197.3C672,181,768,203,864,218.7C960,235,1056,245,1152,261.3C1248,277,1344,299,1392,309.3L1440,320L1440,320L1392,320C1344,320,1248,320,1152,320C1056,320,960,320,864,320C768,320,672,320,576,320C480,320,384,320,288,320C192,320,96,320,48,320L0,320Z"></path>
      </svg>
      <footer>
        <div className="top">
          <div className="social">
            <p>Zapratite nas na drustvenim mrezama</p>
            <div className="icons">
              <a href="#">
                <Facebook />
              </a>
              <a href="#">
                <Instagram />
              </a>
            </div>
          </div>

          <ul>
            {navLinks.map(({ text, href }, i) => (
              <li key={i}>
                <Link to={href}>{text}</Link>
              </li>
            ))}
          </ul>
        </div>
        <div className="bot">Copyright © 2023 Clinic All rights reserved.</div>
      </footer>
    </div>
  </>
);
