import { useQuery } from "react-query";
import { getAllDoctors } from "../../api";
import DoctorImage from "../../assets/images/doctor.png";
import { MySlider } from "../shared/MySlider";

const dummyDoctors = [
  {
    id: 1,
    name: "Dragan",
    spec: "Specijalista za deciju hirurgiju",
    img: DoctorImage,
  },
  {
    id: 2,
    name: "Dragan",
    spec: "Specijalista za deciju hirurgiju",
    img: DoctorImage,
  },
  {
    id: 3,
    name: "Dragan",
    spec: "Specijalista za deciju hirurgiju",
    img: DoctorImage,
  },
  {
    id: 4,
    name: "Dragan",
    spec: "Specijalista za deciju hirurgiju",
    img: DoctorImage,
  },
  {
    id: 5,
    name: "Dragan",
    spec: "Specijalista za deciju hirurgiju",
    img: DoctorImage,
  },
];

export const OurTeam = () => {
  const { data } = useQuery("all-doctors", getAllDoctors);

  return (
    <div className="team">
      <div className="heading">
        <h2>Naš tim</h2>
        <div className="line"></div>
      </div>

      <MySlider className="teamSlider">
        {/* TODO: Zameni dummyDoctors sa data  */}
        {dummyDoctors.map(({ id, name, spec, img }) => (
          <div className="sliderItem" key={id}>
            <div className="imageContainer">
              <img src={img} alt="Doctor Image" />
            </div>

            <div className="content">
              <h3>{name}</h3>
              <p>{spec}</p>
            </div>
          </div>
        ))}
      </MySlider>
    </div>
  );
};
