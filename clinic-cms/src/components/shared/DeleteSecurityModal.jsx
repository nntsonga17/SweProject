import { useMutation } from 'react-query';
import { Modal } from '../ui/Modal';

export const DeleteSecurityModal = ({ close, id, refetch, deleteFunc }) => {
  const { mutate, isLoading } = useMutation(deleteFunc);

  const onDelete = () =>
    mutate(id, {
      onSuccess: () => {
        refetch();
        close();
      },
    });

  return (
    <Modal close={close} title="Da li ste sigurni?">
      <button
        className="contained error fullWidth"
        disabled={isLoading}
        onClick={onDelete}
      >
        Obirsi
      </button>
    </Modal>
  );
};
