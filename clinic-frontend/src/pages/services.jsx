import InstrumentsImage from "../assets/images/instruments.png";
import { formatPrice } from "../utils/helpers";

const services = [
  {
    img: "https://images.pexels.com/photos/3279196/pexels-photo-3279196.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    title: "Hirurgija",
    text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text1:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text2:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",

    price: 12000,
  },
  {
    img: "https://images.pexels.com/photos/3279196/pexels-photo-3279196.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    title: "Hirurgija",
    text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text1:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text2:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    price: 12000,
  },
  {
    img: "https://images.pexels.com/photos/3279196/pexels-photo-3279196.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    title: "Hirurgija",
    text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text1:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text2:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    price: 12000,
  },
  {
    img: "https://images.pexels.com/photos/3279196/pexels-photo-3279196.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    title: "Hirurgija",
    text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text1:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text2:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    price: 12000,
  },
  {
    img: "https://images.pexels.com/photos/3279196/pexels-photo-3279196.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    title: "Hirurgija",
    text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text1:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    text2:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi laborum necessitatibus aspernatur, odit tenetur rem porro quo voluptates et ipsum distinctio est enim in debitis. Natus expedita id fuga aperiam.",
    price: 12000,
  },
];

export const ServicesPage = () => {
  return (
    <div className="servicesPage">
      <div className="hero">
        <div className="text">
          <h1>Usluge koje mi nudimo</h1>
          <div className="line"></div>
        </div>
        <div className="imgCont">
          <img src={InstrumentsImage} alt="Surgery Instruments" />
        </div>
      </div>

      <div className="container">
        <div className="services">
          {services.map(({ img, title, text, text1, text2, price }) => (
            <div className="paper">
              <div className="imgContainer">
                <img src={img} alt="Service Image" />
              </div>
              <div className="serviceData">
                <div>
                  <h3>{title}</h3>
                  <div className="line"></div>
                </div>
                <div className="texts">
                  <p>{text}</p>
                  <p>{text1}</p>
                  <p>{text2}</p>
                </div>
                <p className="price">Cena: {formatPrice(price)}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};
