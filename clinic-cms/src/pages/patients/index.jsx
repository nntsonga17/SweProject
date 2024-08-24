import { useQuery } from 'react-query';
import { deletePatient, getAllPatients } from '../../api/patients';
import { useAuthStore } from '../../stores/AuthStore';
import { CloseIcon } from '../../assets/icons/CloseIcon';
import { DeleteSecurityModal } from '../../components/shared/DeleteSecurityModal';
import { useState } from 'react';

const dummyData = [
  {
    id: 1,
    ime: 'Djordje',
    prezime: 'Stefanovic',
    email: 'test@gmail.com',
    brojTelefona: '060 12345567',
    datumRodjenja: new Date(),
  },
  {
    id: 2,
    ime: 'Djordje',
    prezime: 'Stefanovic',
    email: 'test@gmail.com',
    brojTelefona: '060 12345567',
    datumRodjenja: new Date(),
  },
  {
    id: 3,
    ime: 'Djordje',
    prezime: 'Stefanovic',
    email: 'test@gmail.com',
    brojTelefona: '060 12345567',
    datumRodjenja: new Date(),
  },
];

export const PatientsPage = () => {
  const { user } = useAuthStore();

  const { data, refetch } = useQuery('all-patients', getAllPatients);
  const [idForDelete, setIdForDelete] = useState('');
  const [patient, setPatient] = useState(null);
  // TODO: Proveri da li je kljuc .role i da li se rola zove  admin
  const isAdmin = user?.role === 'admin';

  return (
    <div className="patientsPage paper">
      <div className="paperHeader">
        <h2>Pacijenti</h2>
      </div>
      <div className="paperBody">
        {/* TODO: zameni dummyData sa data */}
        {dummyData.map((item) => (
          <div
            key={item.id}
            className="patient paper"
            onClick={() => setPatient(item)}
          >
            {isAdmin && (
              <div className="closeBtn" onClick={() => setIdForDelete(item.id)}>
                <CloseIcon />
              </div>
            )}
            <h3>
              {item.ime} {item.prezime}
            </h3>
            <p>{item.email}</p>
            <p>{item.brojTelefona}</p>
          </div>
        ))}
      </div>

      {idForDelete && (
        <DeleteSecurityModal
          refetch={refetch}
          id={idForDelete}
          close={() => setIdForDelete('')}
          deleteFunc={deletePatient}
        />
      )}
    </div>
  );
};
