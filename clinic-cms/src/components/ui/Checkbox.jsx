import { CheckIcon } from '../../assets/icons/CheckIcon';
import { isActiveClass } from '../../util/classes';

export const Checkbox = ({ isChecked, onChange }) => (
  <div className={isActiveClass(isChecked, 'checkbox')} onClick={onChange}>
    <CheckIcon />
  </div>
);
