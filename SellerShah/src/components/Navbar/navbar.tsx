import './navbar.css';
import { Button } from "@/components/ui/button";
import { VscAccount } from "react-icons/vsc";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { useState } from 'react';
import { HoverCard, HoverCardContent, HoverCardTrigger } from "@/components/ui/hover-card";
import { useTranslation } from "react-i18next";
import { CiLogout } from "react-icons/ci";

export default function Navbar() {
    const { t, i18n } = useTranslation();
    const [flag, setFlag] = useState<string>(() => localStorage.getItem('flag') || 'https://flagsapi.com/GB/flat/64.png');// Default to UK flag


    const handleLanguageChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const selectedLanguage = event.target.value;
        let flagUrl = 'https://flagsapi.com/GB/flat/64.png';
        switch (selectedLanguage) {
            case 'en':
                flagUrl = 'https://flagsapi.com/GB/flat/64.png';
                break;
            case 'ru':
                flagUrl = 'https://flagsapi.com/RU/flat/64.png';
                break;
            case 'az':
                flagUrl = 'https://flagsapi.com/AZ/flat/64.png';
                break;
            default:
                flagUrl = 'https://flagsapi.com/GB/flat/64.png';
        }
        setFlag(flagUrl);
        localStorage.setItem('flag', flagUrl);
        i18n.changeLanguage(selectedLanguage);
    };






    const isLoggedIn = !!localStorage.getItem("userToken");
    return (
        <div className="flex flex-col bg-gray-800 w-full p-2 sm:p-4 text-white">
            <div className="flex flex-col sm:flex-row items-center justify-between gap-2">
                <img
                    src="\src\assets\images\Gemini_Generated_Image_fym6k9fym6k9fym6-Photoroom.png"
                    className="w-20 h-20 sm:w-24 sm:h-24 cursor-pointer mb-2 sm:mb-0"
                    alt="Company Logo"
                />

                <div className="flex items-center  justify-center w-full sm:w-auto gap-2">
                    <HoverCard>
                        <HoverCardTrigger>
                            <Button className="text-white cursor-pointer h-12 bg-inherit hover:bg-gray-700" >
                                <div className="flex items-center justify-center rounded-full">
                                    <Avatar>
                                        <AvatarImage id='AvatarImage' src="" alt="User Avatar" />
                                        <AvatarFallback className='text-white-500 bg-transparent'>
                                            {!!localStorage.getItem("profile") && isLoggedIn ? (
                                                <img src={JSON.parse(localStorage.getItem("profile") || "null")?.profilePicPreview} alt="User Avatar" className="w-9 h-9 rounded-full" />
                                            ) : (
                                                <VscAccount className="w-9 h-9" />
                                            )}
                                        </AvatarFallback>
                                    </Avatar>
                                </div>
                                <span className='hidden lg:block'>
                                    {!!localStorage.getItem("profile") && isLoggedIn ? JSON.parse(localStorage.getItem("user") || "null")?.username : t('Account')}
                                </span>
                            </Button>
                        </HoverCardTrigger>
                        <HoverCardContent className="w-40 ">
                            <div className="flex flex-col space-y-2">
                                {!isLoggedIn ? (
                                    <>
                                        <Button variant="outline" className="mt-2" >{t('Login')}</Button>
                                        <Button variant="outline" className="mt-2" >{t('Sign Up')}</Button>
                                    </>
                                ) : (
                                    <>
                                        <Button variant="outline" className="mt-2" >{t('Profile')}</Button>
                                        <Button variant="outline" className="mt-2" >
                                            <CiLogout className="mr-2" />
                                            {t('Logout')}</Button>
                                    </>
                                )}
                            </div>
                        </HoverCardContent>
                    </HoverCard>

                    <div className="flex flex-col sm:flex-row items-center justify-between gap-2">
                        <div className="flex items-center space-x-2 mt-2 sm:mt-0">
                            <img src={flag} alt={t('flag')} className='w-8 h-8' />
                            <select className="languageDropdown bg-white text-gray-800 p-2 rounded"
                                onChange={handleLanguageChange}
                                value={i18n.language} >
                                <option value="en">{t('English')}</option>
                                <option value="ru">{t('Russian')}</option>
                                <option value="az">{t('Azerbaijani')}</option>
                            </select>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
}