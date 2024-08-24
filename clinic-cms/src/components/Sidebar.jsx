import { NavLink } from 'react-router-dom';

import { adminSidebarNavData, sidebarNavData } from '../data/sidebarNav.data';
import { removeStorageItem } from '../util/localStorage';
import { SignOutIcon } from '../assets/icons/SignOutIcon';
import { useAuthStore } from '../stores/AuthStore';

export const Sidebar = ({ toggleExpand }) => {
  const { setIsLogged, setUser, user } = useAuthStore();

  // TODO: Proveri da li je kljuc .role i da li se rola zove  admin
  const nav = user?.role === 'admin' ? adminSidebarNavData : sidebarNavData;

  const signOut = () => {
    removeStorageItem('token');
    setUser(undefined);
    setIsLogged(false);
  };

  return (
    <aside className="appSidebar">
      <div className="legend">
        <div className="logo">LOGO</div>
        <div className="circle" onClick={toggleExpand} />
      </div>
      <nav className="customScrollbar">
        {/* TODO: Change to nav const declared at line 11 */}
        {adminSidebarNavData.map((group) => (
          <div className="group" key={group.title}>
            <p>{group.title}</p>
            {group.links.map((link) => (
              <NavLink key={link.href} to={link.href}>
                {link.icon} {link.text}
              </NavLink>
            ))}
          </div>
        ))}
      </nav>
      <button className="contained signOut" onClick={signOut}>
        <SignOutIcon />
      </button>
    </aside>
  );
};
