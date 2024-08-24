import AboutImage from "../../assets/images/about.png";

export const AboutUs = () => {
  return (
    <div className="about">
      <div className="imageContainer">
        <img src={AboutImage} alt="About Us Image" />
        <div className="border"></div>
        <div className="border second"></div>
      </div>

      <div>
        <div className="sectionTitle">
          <h2>O nama</h2>
          <div className="line"></div>
        </div>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum nam,
          unde enim itaque atque sit expedita deleniti minima. Nostrum unde sunt
          eum corporis ducimus incidunt laudantium perferendis velit temporibus
          ipsum.
        </p>
        <p>
          Aspernatur deserunt vero illum, magnam perspiciatis temporibus
          provident, commodi vitae quasi a culpa hic cupiditate dolorem velit
          iusto maiores! Tempore laboriosam qui id fuga non totam harum, nam
          pariatur sed!
        </p>
        <p>
          Ratione aut voluptate nesciunt quasi ut. Voluptatum dolores dolor
          illum nemo repellendus est illo aliquid nulla eius voluptatibus
          veritatis dicta, vitae repudiandae consectetur praesentium repellat
          quae non. Dolor, eius fugiat.
        </p>
        <p>
          Optio voluptatibus, nesciunt quisquam reprehenderit ex quas velit modi
          in animi non ipsum beatae odit corporis natus doloremque ratione
          quibusdam perspiciatis dicta cupiditate accusamus aut sequi voluptates
          tenetur! Quo, soluta.
        </p>
        <p>
          Voluptatem magnam cumque maxime soluta dolor saepe unde, voluptatum
          quasi consequatur dolore ipsa? Cum mollitia commodi, nisi nostrum non
          suscipit inventore repellendus corrupti maxime quo quos tempore
          corporis neque molestiae.
        </p>
      </div>
    </div>
  );
};
