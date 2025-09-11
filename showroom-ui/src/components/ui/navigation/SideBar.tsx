import React from 'react';
import { NavLink } from 'react-router-dom';
import { useThemeContext } from '../../shared/hooks/useThemeContext';
import styles from './SideBar.module.css';

const navItems = [
	{ to: '/', label: 'home' },
	{ to: '/account/login', label: 'login' },
	{ to: '/account/registration', label: 'register' },
	{ to: '/profile', label: 'profile' },
];

const SideBar: React.FC = () => {
	const { theme, toggleTheme } = useThemeContext();

	return (
		<aside className={styles.sidebar}>
			<div className={styles['sidebar-logo']}>Showroom</div>
			<nav className={styles['sidebar-nav']}>
				{navItems.map((item) => (
					<NavLink
						key={item.to}
						to={item.to}
						className={({ isActive }) =>
							isActive ? `${styles['sidebar-link']} ${styles['active']}` : styles['sidebar-link']
						}
						end={item.to === '/'}
					>
						{item.label}
					</NavLink>
				))}
			</nav>
			<button
				onClick={toggleTheme}
				className={styles['theme-toggle']}
			>
				{theme === 'light' ? '🌙 Night theme' : '☀️ Light theme'}
			</button>
		</aside>
	);
};

export default SideBar;
