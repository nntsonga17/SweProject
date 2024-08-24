import { Field } from 'formik';
import { FormFieldError } from './FormFieldError.jsx';

export const FormikField = ({
  label,
  type,
  name,
  required,
  readOnly,
  autoFocus,
  component,
}) => {
  return (
    <>
      <div className={`field ${component ? 'textareaField' : ''}`}>
        <Field
          type={type}
          name={name}
          required={required}
          readOnly={readOnly}
          autoFocus={autoFocus}
          component={component}
        />
        <label>{label}</label>
      </div>
      <FormFieldError name={name} />
    </>
  );
};

FormikField.defaultProps = {
  type: 'text',
  required: false,
  readOnly: false,
  autoFocus: false,
};
