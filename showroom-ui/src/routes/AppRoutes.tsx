import React from "react";
import { Routes, Route } from "react-router-dom";
import { Home } from "@pages/Home";
import { ProfileSettings } from "@ui/profile/ProfileSettings"
import {NotFound }from "@pages/NotFound"; 
import Registration from "@/components/ui/account/registration";
import Login from "@/components/ui/account/login";

const AppRoutes: React.FC = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/account/registration" element={<Registration />} />
      <Route path="/account/login" element={<Login />} />
      <Route path="/profile/settings" element={<ProfileSettings />} />
      <Route path="/notfound" element={<NotFound />} /> {/* 404 fallback */}  
    </Routes>
  );
};

export default AppRoutes;
