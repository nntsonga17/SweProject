import { Formik, Form } from 'formik';
import { useMutation } from 'react-query';
import { updateDoctor } from '../../api/doctors';
import { FormikField } from '../../components/ui/FormikField';
import { useAuthStore } from '../../stores/AuthStore';
import { UploadImageDropzone } from '../../components/ui/UploadImageDropzone';

export const ProfilePage = () => {
  const { user } = useAuthStore();
  const { mutate } = useMutation(updateDoctor);

  const onSubmit = (values) => mutate({ id: user?.id, body: values });

  return (
    <div className="profilePage">
      <Formik
        initialValues={{
          email: user?.email || '',
          ime: user?.ime || '',
          prezime: user?.prezime || '',
          brojTelefona: user?.brojTelefona || '',
          brojKancelarije: user?.brojKancelarije || '',
          specijalizacija: user?.specijalizacija || '',
          direktor: user?.direktor || false,
        }}
        onSubmit={onSubmit}
        enableReinitialize
      >
        <Form className="paper">
          <div className="paperHeader">
            <h2>Lični podaci</h2>
            <button type="submit" className="contained">
              Sačuvaj izmene
            </button>
          </div>
          <div className="paperBody">
            <div className="fields">
              <FormikField label="Ime" name="ime" required />
              <FormikField label="Prezime" name="prezime" required />
              <FormikField type="email" label="Email" name="email" required />
              <FormikField label="Broj Telefona" name="brojTelefona" required />
              <FormikField
                label="Broj Kancelarije"
                name="brojKancelarije"
                required
              />
              <FormikField
                label="Specijalizacija"
                name="specijalizacija"
                required
              />
            </div>
          </div>
        </Form>
      </Formik>
    </div>
  );
};
