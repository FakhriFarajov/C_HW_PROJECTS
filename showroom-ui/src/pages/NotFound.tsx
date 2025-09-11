import SideBar from '@/components/ui/navigation/SideBar';
import styles from './NotFound.module.css';
import { Link } from 'react-router-dom';

export const NotFound: React.FC = () => {
    return (
        <div className={styles['notfound-container']}>
            <SideBar />
            <div className={styles['notfound-title']}>404</div>
            <div className={styles['notfound-message']}>
                Oops! The page you're looking for doesn't exist.
            </div>
            <Link to="/" className={styles['notfound-link']}>
                Back to Home
            </Link>
        </div>
    );
}