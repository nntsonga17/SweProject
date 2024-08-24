import { Form, Formik } from 'formik';
import { useMutation } from 'react-query';
import { scheduleFormular } from '../../api/formulars';
import { Modal } from '../../components/ui/Modal';
import { useAuthStore } from '../../stores/AuthStore';

export const ScheduleFormularModal = ({ close, refetch, formularId }) => {
  const { mutate } = useMutation(scheduleFormular);
  const { user } = useAuthStore();

  const onSubmit = (values) =>
    mutate(
      { formularId, doctorId: user?.id, dateTime: values.dateTime },
      { onSuccess: () => refetch() }
    );

  return (
    <Modal className="scheduleFormular" title="Zakazi pregled" close={close}>
      <Formik onSubmit={onSubmit} initialValues={{ dateTime: '' }}>
        {({ values, setFieldValue }) => (
          <Form>
            <input
              type="date"
              onChange={(e) => {
                setFieldValue('dateTime', e.target.value);
              }}
              value={values.dateTime}
            />
            <button type="submit" className="contained fullWidth">
              Azuriraj
            </button>
          </Form>
        )}
      </Formik>
    </Modal>
  );
};
