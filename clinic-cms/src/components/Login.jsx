import { Formik, Form } from 'formik';
import { useMutation } from 'react-query';

import { useAuthStore } from '../stores/AuthStore';
import { signIn } from '../api/auth';
import { FormikField } from './ui/FormikField';

export const Login = () => {
  const { setIsLogged } = useAuthStore();
  const { mutate, isLoading } = useMutation(signIn);

  const onSubmit = (body) =>
    mutate(body, { onSuccess: () => setIsLogged(true) });

  return (
    <div className="loginWrapper">
      <div className="inner">
        <h2 className="hello">Klinika</h2>
        <h5>Dobrodošli na kontrolni panel</h5>
        <p>Prijavite se na svoj nalog</p>
        <Formik initialValues={{ email: '', password: '' }} onSubmit={onSubmit}>
          <Form>
            <FormikField
              type="email"
              name="email"
              label="Email"
              autoFocus
              required
            />
            <FormikField
              type="password"
              name="password"
              label="Password"
              required
            />
            <button type="submit" className="contained lg" disabled={isLoading}>
              Login
            </button>
          </Form>
        </Formik>
      </div>
    </div>
  );
};
