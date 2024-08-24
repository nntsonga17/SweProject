import { Portal } from 'react-portal';
import { CloseIcon } from '../../assets/icons/CloseIcon';

export const Modal = ({ close, title, children, className }) => (
  <Portal>
    <div className={`modal ${className}`} onMouseDown={close}>
      <div className="modalBox" onMouseDown={(e) => e.stopPropagation()}>
        <div className="modalHeader">
          <p>{title}</p>
          <div className="closeBtn">
            <CloseIcon onClick={close} />
          </div>
        </div>
        <div className="modalBody">{children}</div>
      </div>
    </div>
  </Portal>
);

Modal.defaultProps = {
  className: '',
};
