import { useQuery } from "react-query";
import { getAllServices } from "../../api";
import { Healthcare } from "../../assets/icons/HealthCare";
import { MySlider } from "../shared/MySlider";

const dummyServices = [
  {
    id: 1,
    icon: <Healthcare />,
    title: "Lorem ipsum dolor sit",
    subtext:
      " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Vero sunt neque nulla, voluptatum cum inventore architecto officia velit cumque eius.",
  },
  {
    id: 2,
    icon: <Healthcare />,
    title: "Lorem ipsum dolor sit",
    subtext:
      " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Vero sunt neque nulla, voluptatum cum inventore architecto officia velit cumque eius.",
  },
  {
    id: 3,
    icon: <Healthcare />,
    title: "Lorem ipsum dolor sit",
    subtext:
      " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Vero sunt neque nulla, voluptatum cum inventore architecto officia velit cumque eius.",
  },
  {
    id: 4,
    icon: <Healthcare />,
    title: "Lorem ipsum dolor sit",
    subtext:
      " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Vero sunt neque nulla, voluptatum cum inventore architecto officia velit cumque eius.",
  },
  {
    id: 5,
    icon: <Healthcare />,
    title: "Lorem ipsum dolor sit",
    subtext:
      " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Vero sunt neque nulla, voluptatum cum inventore architecto officia velit cumque eius.",
  },
];

export const Services = () => {
  const { data } = useQuery("all-services", getAllServices);

  return (
    <div className="services">
      <div className="heading">
        <h2>Usluge koje pruža naša klinika</h2>
        <div className="line"></div>
      </div>
      <MySlider className="servicesSlider">
        {/* TODO: Postavi data umesto dummyServivces da mapiras */}
        {dummyServices.map(({ id, icon, subtext, title }) => (
          <div className="sliderItem" key={id}>
            <div className="row">
              {icon}
              <h3>{title}</h3>
            </div>
          </div>
        ))}
      </MySlider>
    </div>
  );
};
