import React from 'react';

const Nav = () => {
  return (
    <nav className="bg-gray-800 p-4">
      <div className="container mx-auto flex justify-between items-center">
        <div className="text-white text-lg font-bold">Movie App</div>
        <div>
          <a href="/reg" className="text-white px-4 py-2 hover:bg-gray-700 rounded">Logout</a>
        </div>
      </div>
    </nav>
  );
};

export default Nav;