import { useFormikContext } from 'formik';

export const FormFieldError = ({ name }) => {
  const { errors, touched } = useFormikContext();

  return errors[name] && touched[name] ? (
    <p className="errorMessage">
      {errors[name] && touched[name] && errors[name]}
    </p>
  ) : null;
};
