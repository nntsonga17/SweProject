import Slider from "react-slick";
import { Arrow } from "../../assets/icons/Arrow";
import { useRef } from "react";

export const MySlider = ({ children, className }) => {
  const ref = useRef(null);

  const settings = {
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows: true,
    speed: 2000,
    autoplay: true,
    autoplaySpeed: 1000,
    pauseOnHover: true,

    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true,
        },
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          initialSlide: 2,
        },
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  };

  return (
    <div className={`${className} slider`}>
      <Slider ref={ref} {...settings}>
        {children}
      </Slider>
    </div>
  );
};
