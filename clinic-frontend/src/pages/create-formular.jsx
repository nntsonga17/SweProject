import { Formik, Field, Form, ErrorMessage } from "formik";
import { useMutation } from "react-query";
import { createFormular } from "../api";

const initialValues = {
  email: "",
  ime: "",
  prezime: "",
  brojTelefona: "",
};

export const CreatAppointmentPage = () => {
  const { mutate } = useMutation(createFormular);

  const onSubmit = (values) => mutate(values);

  return (
    <div className="createAppointment">
      <div className="inner">
        <h1>Kreirajte zahtev za pregled</h1>
        <Formik initialValues={initialValues} onSubmit={onSubmit}>
          <Form>
            <div className="field">
              <Field type="email" id="email" name="email" />
              <label htmlFor="email">Email</label>
              <ErrorMessage
                className="errorMessage"
                name="email"
                component="div"
              />
            </div>
            <div className="field">
              <Field type="text" id="ime" name="ime" />
              <label htmlFor="ime">Ime</label>
              <ErrorMessage
                className="errorMessage"
                name="ime"
                component="div"
              />
            </div>
            <div className="field">
              <Field type="text" id="prezime" name="prezime" />
              <label htmlFor="prezime">Prezime</label>
              <ErrorMessage
                className="errorMessage"
                name="prezime"
                component="div"
              />
            </div>
            <div className="field">
              <Field type="text" id="brojTelefona" name="brojTelefona" />
              <label htmlFor="brojTelefona">Broj Telefona</label>
              <ErrorMessage
                className="errorMessage"
                name="brojTelefona"
                component="div"
              />
            </div>

            <button type="submit">Posalji zahtev</button>
          </Form>
        </Formik>
      </div>
    </div>
  );
};
