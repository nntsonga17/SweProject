import { useState } from 'react';
import { useQuery } from 'react-query';
import { deleteService, getAllServices } from '../../api/service';
import { CloseIcon } from '../../assets/icons/CloseIcon';
import { DeleteSecurityModal } from '../../components/shared/DeleteSecurityModal';
import { useModal } from '../../hooks/useModal';
import { formatPrice } from '../../util/mix';
import { ServiceModal } from './ServiceModal';

const dummyServices = [
  {
    id: 1,
    vrstaUsluge: 'Usluga 1',
    opisUsluge:
      'Lorem ipsum dolor sit amet consectetur adipisicing elit. Explicabo rem iure, nobis ea voluptatem veritatis esse accusantium hic. Doloribus, odit.',
    cenaUsluge: 14000,
  },
  {
    id: 2,
    vrstaUsluge: 'Usluga 2',
    opisUsluge:
      'Lorem ipsum dolor sit amet consectetur adipisicing elit. Explicabo rem iure, nobis ea voluptatem veritatis esse accusantium hic. Doloribus, odit.',
    cenaUsluge: 14000,
  },
  {
    id: 3,
    vrstaUsluge: 'Usluga 3',
    opisUsluge:
      'Lorem ipsum dolor sit amet consectetur adipisicing elit. Explicabo rem iure, nobis ea voluptatem veritatis esse accusantium hic. Doloribus, odit.',
    cenaUsluge: 14000,
  },
];

export const ServicesPage = () => {
  const { close, open, isOpen } = useModal();
  const [serviceForUpdate, setServiceForUpdate] = useState(null);
  const [serviceForDelete, setServiceForDelete] = useState('');
  const { data, refetch } = useQuery('all-services', getAllServices);

  return (
    <div className="servicesPage paper">
      <div className="paperHeader">
        <h2>Usluge</h2>
        <button type="submit" className="contained" onClick={open}>
          Dodaj uslugu
        </button>
      </div>
      <div className="paperBody">
        {/* TODO: Promeni dummyServices sa data */}
        {dummyServices.map((service) => (
          <div
            className="service paper"
            key={service.vrstaUsluge}
            onClick={() => setServiceForUpdate(service)}
          >
            <div
              className="closeBtn"
              onClick={(e) => {
                e.stopPropagation();
                setServiceForDelete(service.id);
              }}
            >
              <CloseIcon />
            </div>
            <h3>{service?.vrstaUsluge}</h3>
            <p>{service?.opisUsluge}</p>
            <p>{formatPrice(service?.cenaUsluge)}</p>
          </div>
        ))}
      </div>

      {(serviceForUpdate || isOpen) && (
        <ServiceModal
          service={serviceForUpdate}
          refetch={refetch}
          close={() => {
            close();
            setServiceForUpdate(null);
          }}
        />
      )}

      {serviceForDelete && (
        <DeleteSecurityModal
          id={serviceForDelete}
          refetch={refetch}
          close={() => setServiceForDelete('')}
          deleteFunc={deleteService}
        />
      )}
    </div>
  );
};
