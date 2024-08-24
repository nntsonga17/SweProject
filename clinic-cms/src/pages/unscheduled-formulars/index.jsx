import dayjs from 'dayjs';
import { useState } from 'react';
import { useQuery } from 'react-query';
import { getFormulars } from '../../api/formulars';
import { ScheduleFormularModal } from './ScheduleFormularModal';

const dummyData = [
  {
    id: 1,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
  },
  {
    id: 2,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
  },
  {
    id: 3,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
  },
];

export const UnscheduledFormularsPage = () => {
  const [formularForUpdate, setFormularForUpdate] = useState('');

  const { data, refetch } = useQuery('unscheduled-formulars', () =>
    getFormulars(false)
  );

  return (
    <div className="formularsPage paper">
      <div className="paperHeader">
        <h2>Nezakazani formulari</h2>
      </div>
      <div className="paperBody">
        {/* TODO: promeni dummyData sa data */}
        {dummyData.map((item) => (
          <div
            key={item.id}
            className="formular paper"
            onClick={() => setFormularForUpdate(item.id)}
          >
            <p>
              {item.ime} {item.prezime}
            </p>
            <p>{item.email}</p>
            <p>{item.brojTelefona}</p>
            <p>{dayjs(item.datumRodjenja).format('DD/MM/YYYY')}</p>
          </div>
        ))}
      </div>

      {formularForUpdate && (
        <ScheduleFormularModal
          refetch={refetch}
          formularId={formularForUpdate}
          close={() => setFormularForUpdate('')}
        />
      )}
    </div>
  );
};
