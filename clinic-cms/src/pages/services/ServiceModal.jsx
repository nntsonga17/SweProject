import { Form, Formik } from 'formik';
import { FormikField } from '../../components/ui/FormikField';
import { Modal } from '../../components/ui/Modal';
import { useMutation } from 'react-query';
import { addService, updateService } from '../../api/service';

export const ServiceModal = ({ close, service, refetch }) => {
  const title = service ? 'Azuriraj uslugu' : 'Dodaj novu uslugu';
  const { mutate: add } = useMutation(addService);
  const { mutate: update } = useMutation(updateService);

  const onSubmit = (values) => {
    if (service)
      update({ id: service.id, body: values }, { onSuccess: () => refetch() });
    else add(values, { onSuccess: () => refetch() });
  };
  return (
    <Modal className="addService" close={close} title={title}>
      <Formik
        onSubmit={onSubmit}
        initialValues={{
          vrstaUsluge: service?.vrstaUsluge || '',
          cena: service?.cenaUsluge || 0,
          opisUsluge: service?.opisUsluge || '',
        }}
      >
        <Form>
          <FormikField
            type="text"
            label="Vrsta Usluge"
            name="vrstaUsluge"
            required
          />
          <FormikField type="number" label="Cena" name="cena" required />
          <FormikField
            type="text"
            label="Opis usluge"
            name="opisUsluge"
            component="textarea"
            required
          />
          <button type="submit" className="contained fullWidth">
            {service ? 'Azuriraj' : 'Dodaj'}
          </button>
        </Form>
      </Formik>
    </Modal>
  );
};
