import { Link, useLocation } from "react-router-dom";
import { Fade as Hamburger } from "hamburger-react";
import { isActiveClass } from "../../utils/helpers";
import { useState } from "react";

export const Header = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { pathname } = useLocation();

  return (
    <header>
      <nav className={isActiveClass(isOpen)}>
        <ul>
          {navLinks.map(({ text, href }, i) => (
            <li key={i} onClick={() => setIsOpen(false)}>
              <Link to={href}>{text}</Link>
            </li>
          ))}
        </ul>
      </nav>

      <Hamburger
        color={isOpen || pathname === "/create-formular" ? "#000" : "#fff"}
        toggled={isOpen}
        toggle={setIsOpen}
      />
    </header>
  );
};

export const navLinks = [
  {
    text: "Pocetna",
    href: "/",
  },
  {
    text: "Zakazi pregled",
    href: "/create-formular",
  },
  {
    text: "Nase usluge",
    href: "/services",
  },
];
