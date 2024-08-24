import dayjs from 'dayjs';
import { useState } from 'react';
import { useQuery } from 'react-query';
import { getFormulars } from '../../api/formulars';
import { WriteReportModal } from './WriteReportModal';

const dummyData = [
  {
    id: 1,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
    idPacijenta: 111,
  },
  {
    id: 2,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
    idPacijenta: 222,
  },
  {
    id: 3,
    ime: 'Djordje',
    prezime: 'Stefanvic',
    email: 'test@test.com',
    brojTelefona: '060 1234567',
    datumRodjenja: new Date(),
    idPacijenta: 333,
  },
];

export const MyFormularsPage = () => {
  const { data, refetch } = useQuery('scheduled-formulars', () =>
    getFormulars(true)
  ); // scheduled true
  const [idForReport, setIdForReport] = useState('');

  return (
    <div className="formularsPage paper">
      <div className="paperHeader">
        <h2>Nezakazani formulari</h2>
      </div>
      <div className="paperBody">
        {/* TODO: Promeni dummyData sa data */}
        {dummyData.map((item) => (
          <div
            key={item.id}
            className="formular paper"
            onClick={() => setIdForReport(item.idPacijenta)}
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

      {idForReport && (
        <WriteReportModal
          refetch={refetch}
          idPacijenta={idForReport}
          close={() => setIdForReport('')}
        />
      )}
    </div>
  );
};
