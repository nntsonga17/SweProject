import { Form, Formik } from 'formik';
import { useMutation } from 'react-query';
import { register } from '../../api/auth';
import { Checkbox } from '../../components/ui/Checkbox';
import { FormikField } from '../../components/ui/FormikField';

export const CreateProfilePage = () => {
  const { mutate } = useMutation(register);
  const onSubmit = (values) => mutate(values);
  return (
    <div className="createProfiePage">
      <Formik
        onSubmit={onSubmit}
        initialValues={{
          email: '',
          password: '',
          ime: '',
          prezime: '',
          direktor: false,
          brojTelefona: '',
        }}
      >
        {({ values, setFieldValue }) => (
          <Form className="paper">
            <div className="paperHeader">
              <h2>Dodaj nove profile</h2>
              <button type="submit" className="contained">
                Dodaj profil
              </button>
            </div>
            <div className="paperBody">
              <FormikField type="email" label="Email" name="email" required />
              <FormikField
                type="password"
                label="Lozinka"
                name="password"
                required
              />
              <FormikField type="text" label="Ime" name="ime" required />
              <FormikField
                type="text"
                label="Prezime"
                name="prezime"
                required
              />

              <FormikField
                type="text"
                label="Broj telefona"
                name="brojTelefona"
                required
              />
              <div className="check">
                <Checkbox
                  isChecked={values.direktor}
                  onChange={() => setFieldValue('direktor', !values.direktor)}
                />
                <p>Direktor</p>
              </div>
            </div>
          </Form>
        )}
      </Formik>
    </div>
  );
};
