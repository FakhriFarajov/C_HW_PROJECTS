import { useState, useEffect } from "react";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { FaUser, FaCreditCard, FaHistory, FaMapMarkerAlt, FaGlobe, FaLock, FaBell, FaStore, FaStar, FaTags, FaWallet } from "react-icons/fa";
import Navbar from "@/components/custom/Navbar/navbar";
import Footer from "@/components/custom/footer";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { toast } from "sonner";

interface Profile {
  name: string;
  surname: string;
  address: string;
  paymentMethod: string;
  profilePicPreview: string;
}

const sidebarItems = [
  { icon: <FaStar />, label: "Your reviews" },
  { icon: <FaUser />, label: "Your profile" },
  { icon: <FaTags />, label: "Coupons & offers" },
  { icon: <FaWallet />, label: "Credit balance" },
  { icon: <FaStore />, label: "Followed stores" },
  { icon: <FaHistory />, label: "Browsing history" },
  { icon: <FaMapMarkerAlt />, label: "Addresses" },
  { icon: <FaGlobe />, label: "Country/Region & Language" },
  { icon: <FaCreditCard />, label: "Your payment methods" },
  { icon: <FaLock />, label: "Account security" },
  { icon: <FaBell />, label: "Notifications" },
];

export default function ProfilePage() {
  const { t } = useTranslation();
  const navigate = useNavigate();

  // Check if user is logged in (example: using a token in localStorage)
  const user = JSON.parse(localStorage.getItem("user") || "null");
  const isLoggedIn = !!localStorage.getItem("userToken") && user;
  if (!isLoggedIn) {
    navigate("/login"); // or "/register"
    return null;
  }

  const [profile, setProfile] = useState<Profile>({
    name: "",
    surname: "",
    address: "",
    paymentMethod: "",
    profilePicPreview: "",
  });
  const [profilePic, setProfilePic] = useState<File | null>(null);

  // Load profile from localStorage on mount
  useEffect(() => {
    const saved = localStorage.getItem("profile");
    if (saved) {
      setProfile(JSON.parse(saved));
    }
  }, []);

  // Show preview when profilePic changes
  useEffect(() => {
    if (profilePic) {
      const reader = new FileReader();
      reader.onloadend = () => setProfile(p => ({ ...p, profilePicPreview: reader.result as string }));
      reader.readAsDataURL(profilePic);
    }
  }, [profilePic]);

  const handleProfilePicChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      setProfilePic(e.target.files[0]);
    }
  };

  const handleChange = (field: keyof Profile, value: string) => {
    setProfile(prev => ({ ...prev, [field]: value }));
  };

  const handleSave = () => {
    // Save to localStorage, including profilePicPreview
    const updatedProfile = { ...profile };
    // If a new profilePic was uploaded and preview exists, save it
    if (profilePic && profile.profilePicPreview) {
      updatedProfile.profilePicPreview = profile.profilePicPreview;
    }
    localStorage.setItem("profile", JSON.stringify(updatedProfile));
    toast.success(t('Profile saved!'));
  };

  // Optionally, display user info in profile page
  // Example: show user's email or username
  // You can use user.username or user.email as needed

  return (
    <>
    <Navbar></Navbar>
    <div className="min-h-screen bg-gray-50">
      <div className="max-w-7xl mx-auto p-8 grid grid-cols-12 gap-8">
        
        <aside className="col-span-3 bg-white rounded-md shadow p-6 h-fit sticky top-4">
          <h2 className="text-lg font-semibold mb-6">{t('Account')}</h2>
          <ul className="space-y-3">
            {sidebarItems.map((item) => (
              <li key={item.label} className="flex items-center gap-3 text-gray-700 hover:text-blue-600 cursor-pointer">
                <span className="text-xl">{item.icon}</span>
                <span>{t(item.label)}</span>
              </li>
            ))}
          </ul>
        </aside>

        <section className="col-span-9">
          <h1 className="text-2xl font-bold mb-6">{t('Edit Profile')}</h1>
          <Card>
            <CardContent className="space-y-6 p-8">
              <div className="flex items-center gap-6 mb-6">
                <div>
                  {profile.profilePicPreview ? (
                    <img src={profile.profilePicPreview} alt={t('Profile Preview')} className="w-24 h-24 object-cover rounded-full border" />
                  ) : (
                    <div className="w-24 h-24 rounded-full bg-gray-200 flex items-center justify-center text-4xl text-gray-400 border">
                      <FaUser />
                    </div>
                  )}
                  <Input type="file" accept="image/*" onChange={handleProfilePicChange} className="mt-2" />
                </div>
                <div className="flex flex-col gap-4 flex-1">
                  <div>
                    <label className="block mb-1">{t('Name')}</label>
                    <Input
                      value={t(profile.name)}
                      onChange={e => handleChange("name", e.target.value)}
                      placeholder={t('Enter your name')}
                    />
                  </div>
                  <div>
                    <label className="block mb-1">{t('Surname')}</label>
                    <Input
                      value={profile.surname}
                      onChange={e => handleChange("surname", e.target.value)}
                      placeholder={t('Enter your surname')}
                    />
                  </div>
                </div>
              </div>
              <div>
                <label className="block mb-1">{t('Address')}</label>
                <Input
                  value={profile.address}
                  onChange={e => handleChange("address", e.target.value)}
                  placeholder={t('Enter your address')}
                />
              </div>
              <div>
                <label className="block mb-1">{t('Payment Method')}</label>
                <Input
                  value={profile.paymentMethod}
                  onChange={e => handleChange("paymentMethod", e.target.value)}
                  placeholder={t('e.g. Visa, MasterCard')}
                />
              </div>
              <div className="flex justify-end">
                <Button onClick={handleSave}>{t('Save Changes')}</Button>
              </div>
            </CardContent>
          </Card>
        </section>
      </div>
    </div>
    <Footer></Footer>
    </>
  );
}
