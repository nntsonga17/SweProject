import { ProfileIcon } from '../assets/icons/ProfileIcon';
import { ScheduledIcon } from '../assets/icons/ScheduledIcon';
import { UnscheduledIcon } from '../assets/icons/UnscheduledIcon';

export const sidebarNavData = [
  {
    title: 'Genralno',
    links: [{ icon: <ProfileIcon />, href: '/', text: 'Moj profil' }],
  },
  {
    title: 'Formulari',
    links: [
      {
        icon: <UnscheduledIcon />,
        href: '/unscheduled-formulars',
        text: 'Nezakazani formulari',
      },
      {
        icon: <ScheduledIcon />,
        href: '/my-formulars',
        text: 'Moj Formulari',
      },
    ],
  },
  {
    title: 'Pacijenti',
    links: [
      {
        icon: <ProfileIcon />,
        href: '/patients',
        text: 'Pacijenti',
      },
    ],
  },
];

export const adminSidebarNavData = [
  {
    title: 'Administrator',
    links: [
      { icon: <ProfileIcon />, href: '/create-profiles', text: 'Dodaj profil' },
      { icon: <ProfileIcon />, href: '/services', text: 'Usluge' },
      { icon: <ProfileIcon />, href: '/doctors', text: 'Doktori' },
    ],
  },
  ...sidebarNavData,
];
