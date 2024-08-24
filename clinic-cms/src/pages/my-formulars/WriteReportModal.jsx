import { Form, Formik } from 'formik';
import { Modal } from '../../components/ui/Modal';
import { FormikField } from '../../components/ui/FormikField';
import { useAuthStore } from '../../stores/AuthStore';
import { useMutation } from 'react-query';
import { createReport } from '../../api/reports';

export const WriteReportModal = ({ idPacijenta, close, refetch }) => {
  const { user } = useAuthStore();
  const { mutate } = useMutation(createReport);

  const onSubmit = (values) =>
    mutate(
      { idLekara: user.id, idPacijenta, values },
      { onSuccess: () => refetch() }
    );

  return (
    <Modal className="createReport" close={close} title="Napisi izveštaj">
      <Formik onSubmit={onSubmit} initialValues={{ dijagnoza: '' }}>
        <Form>
          <FormikField
            type="text"
            label="Dijagnoza"
            name="dijagnoza"
            component="textarea"
            required
          />
          <button type="submit" className="contained fullWidth">
            Pošalji
          </button>
        </Form>
      </Formik>
    </Modal>
  );
};
