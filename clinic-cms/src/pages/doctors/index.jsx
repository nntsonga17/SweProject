import { useState } from 'react';
import { useQuery } from 'react-query';
import { deleteDoctor, getAllDoctors } from '../../api/doctors';
import { CloseIcon } from '../../assets/icons/CloseIcon';
import { DeleteSecurityModal } from '../../components/shared/DeleteSecurityModal';

const dummyDoctors = [
  {
    id: 1,
    email: 'test@test.com',
    ime: 'Dragan',
    prezime: 'Karanikolic',
    brojTelefona: '060 1234567',
    brojKancelarije: 1,
    specijalizacija: 'hirurgija',
    direktor: false,
  },
  {
    id: 2,
    email: 'test@test.com',
    ime: 'Dragan',
    prezime: 'Karanikolic',
    brojTelefona: '060 1234567',
    brojKancelarije: 1,
    specijalizacija: 'hirurgija',
    direktor: false,
  },
  {
    id: 3,
    email: 'test@test.com',
    ime: 'Dragan',
    prezime: 'Karanikolic',
    brojTelefona: '060 1234567',
    brojKancelarije: 1,
    specijalizacija: 'hirurgija',
    direktor: false,
  },
];

export const DoctorsPage = () => {
  const { data, refetch } = useQuery('all-doctors', getAllDoctors);
  const [doctorForDelete, setDoctorForDelete] = useState('');

  return (
    <div className="servicesPage paper">
      <div className="paperHeader">
        <h2>Doktori</h2>
      </div>
      <div className="paperBody">
        {/* TODO: Promeni dummyServices sa data */}
        {dummyDoctors.map((doctor) => (
          <div className="service paper" key={doctor.vrstaUsluge}>
            <div
              className="closeBtn"
              onClick={(e) => {
                e.stopPropagation();
                setDoctorForDelete(doctor.id);
              }}
            >
              <CloseIcon />
            </div>

            <p>
              {doctor.ime} {doctor.prezime}
            </p>
            <p>{doctor.email}</p>
            <p>{doctor.brojTelefona}</p>
            <p>{doctor.specijalizacija}</p>
          </div>
        ))}
      </div>

      {doctorForDelete && (
        <DeleteSecurityModal
          id={doctorForDelete}
          refetch={refetch}
          close={() => setDoctorForDelete('')}
          deleteFunc={deleteDoctor}
        />
      )}
    </div>
  );
};
