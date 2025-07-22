import './App.css';
import Main from './pages/mainPage';
import LoginForm from './pages/auth/login';
import RegForm from './pages/auth/register';
import ProfilePage from './pages/auth/profile';
import Cart from './pages/cartPage';
import "./i18n"; // Import i18n configuration
import ProductPage from './pages/ProductPage';

import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Provider } from 'react-redux';
import { store, persistor } from '@/store';
import { PersistGate } from 'redux-persist/integration/react';
import OrderPage from './pages/orderPage';
import CategoryPage from './pages/categoriesPage';

function App() {
  return (
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <BrowserRouter>
          <Routes>
            <Route path='/main' element={<Main />} />
            <Route path='/login' element={<LoginForm />} />
            <Route path='/reg' element={<RegForm />} />
            <Route path='/cart' element={<Cart />} />
            <Route path='/order' element={<OrderPage />} />
            <Route path='/profile' element={<ProfilePage />} />
            <Route path='/' element={<Main />} />
            <Route path='/category/:category' element={<CategoryPage />} />
            <Route path='/category/:category/:subcategory' element={<CategoryPage />} />
            <Route path='/product/:id' element={<ProductPage />} />
          </Routes>
        </BrowserRouter>
      </PersistGate>
    </Provider>
  );
}

export default App;
