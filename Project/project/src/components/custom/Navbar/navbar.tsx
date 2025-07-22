import './navbar.css';
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { VscAccount } from "react-icons/vsc";
import { BsCart3 } from "react-icons/bs";
import { TfiPackage } from "react-icons/tfi";
import { useNavigate } from "react-router-dom";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { useEffect, useState } from 'react';
import SideBar from "@/components/custom/sidebar"
import { useDispatch, useSelector } from "react-redux";
import { HoverCard, HoverCardContent, HoverCardTrigger } from "@/components/ui/hover-card";
import { useTranslation } from "react-i18next";

// Helper function to translate categories
export function getTranslatedCategories(t) {
    return {
        home: {
            id: 1,
            name: t("Home"),
            subcategories: [
                {
                    id: 101,
                    name: t("Furniture"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Sofa"), t("Table"), t("Chair"), t("Bed")] },
                    ],
                },
                {
                    id: 102,
                    name: t("Decor"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Wall Art"), t("Vase"), t("Clock"), t("Lamp")] },
                    ],
                },
                {
                    id: 103,
                    name: t("Lighting"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Ceiling"), t("Table"), t("Floor"), t("Outdoor")] },
                    ],
                },
            ],
        },
        man: {
            id: 2,
            name: t("Man"),
            subcategories: [
                {
                    id: 201,
                    name: t("Clothing"),
                    filters: [
                        { id: "size", name: t("Size"), options: ["S", "M", "L", "XL"] },
                    ],
                },
                {
                    id: 202,
                    name: t("Shoes"),
                    filters: [
                        { id: "size", name: t("Size"), options: ["7", "8", "9", "10", "11"] },
                    ],
                },
                {
                    id: 203,
                    name: t("Accessories"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Watch"), t("Belt"), t("Wallet")] },
                    ],
                },
            ],
        },
        woman: {
            id: 3,
            name: t("Woman"),
            subcategories: [
                {
                    id: 301,
                    name: t("Clothing"),
                    filters: [
                        { id: "size", name: t("Size"), options: ["S", "M", "L", "XL"] },
                    ],
                },
                {
                    id: 302,
                    name: t("Shoes"),
                    filters: [
                        { id: "size", name: t("Size"), options: ["5", "6", "7", "8", "9"] },
                        { id: "brand", name: t("Brand"), options: ["Zara", "H&M", "Prada"] },
                    ],
                },
                {
                    id: 303,
                    name: t("Jewelry"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Necklace", "Ring", "Earrings"] },
                        { id: "material", name: t("Material"), options: ["Gold", "Silver"] },
                    ],
                },
            ],
        },
        kids: {
            id: 4,
            name: t("Kids"),
            subcategories: [
                {
                    id: 401,
                    name: t("Clothing"),
                    filters: [
                        { id: "age", name: t("Age Group"), options: ["0-2", "3-5", "6-10"] },
                        { id: "gender", name: t("Gender"), options: ["Boys", "Girls"] },
                    ],
                },
                {
                    id: 402,
                    name: t("Toys"),
                    filters: [
                        { id: "age", name: t("Age Group"), options: ["0-2", "3-5", "6-10"] },
                        { id: "type", name: t("Type"), options: [t("Educational"), t("Outdoor"), t("Indoor")] },
                    ],
                },
                {
                    id: 403,
                    name: t("School Supplies"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Stationery"), t("Bags"), t("Lunch Box")] },
                        { id: "brand", name: t("Brand"), options: ["Crayola", "Pilot", "Staedtler"] },
                    ],
                },
            ],
        },
        electronics: {
            id: 5,
            name: t("Electronics"),
            subcategories: [
                {
                    id: 501,
                    name: t("Phones"),
                    filters: [
                        { id: "brand", name: t("Brand"), options: ["Apple", "Samsung", "Xiaomi"] },
                    ],
                },
                {
                    id: 502,
                    name: t("Laptops"),
                    filters: [
                        { id: "brand", name: t("Brand"), options: ["Dell", "HP", "Apple", "Lenovo"] },
                        { id: "price", name: t("Price Range"), options: ["Under $500", "$500 - $1500", "Above $1500"] },
                    ],
                },
                {
                    id: 503,
                    name: t("Audio"),
                    filters: [
                        { id: "type", name: t("Type"), options: [t("Headphones"), t("Speakers"), t("Earbuds")] },
                        { id: "brand", name: t("Brand"), options: ["Sony", "Bose", "JBL"] },
                    ],
                },
            ],
        },
        books: {
            id: 6,
            name: t("Books"),
            subcategories: [
                {
                    id: 601,
                    name: t("Fiction"),
                    filters: [
                        { id: "genre", name: t("Genre"), options: ["Fantasy", "Romance", "Thriller"] },
                        { id: "format", name: t("Format"), options: ["Paperback", "Hardcover", "E-book"] },
                    ],
                },
                {
                    id: 602,
                    name: t("Non-Fiction"),
                    filters: [
                        { id: "topic", name: t("Topic"), options: ["Biography", "Self-Help", "Business"] },
                        { id: "format", name: t("Format"), options: ["Paperback", "Hardcover", "E-book"] },
                    ],
                },
                {
                    id: 603,
                    name: t("Comics"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Manga", "Graphic Novel", "Superhero"] },
                        { id: "age", name: t("Audience"), options: ["Kids", "Teens", "Adults"] },
                    ],
                },
            ],
        },
        beauty: {
            id: 7,
            name: t("Beauty"),
            subcategories: [
                {
                    id: 701,
                    name: t("Makeup"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Lipstick", "Foundation", "Mascara"] },
                        { id: "brand", name: t("Brand"), options: ["Maybelline", "L'Oreal", "MAC"] },
                    ],
                },
                {
                    id: 702,
                    name: t("Skincare"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Moisturizer", "Serum", "Cleanser"] },
                        { id: "brand", name: t("Brand"), options: ["Neutrogena", "Olay", "Clinique"] },
                    ],
                },
                {
                    id: 703,
                    name: t("Fragrances"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Perfume", "Cologne", "Body Mist"] },
                        { id: "brand", name: t("Brand"), options: ["Chanel", "Dior", "Gucci"] },
                    ],
                },
            ],
        },
        sports: {
            id: 8,
            name: t("Sports"),
            subcategories: [
                {
                    id: 801,
                    name: t("Fitness Equipment"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Treadmill", "Dumbbells", "Yoga Mat"] },
                        { id: "brand", name: t("Brand"), options: ["Nike", "Adidas", "Reebok"] },
                    ],
                },
                {
                    id: 802,
                    name: t("Outdoor Sports"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Camping", "Cycling", "Fishing"] },
                        { id: "brand", name: t("Brand"), options: ["Coleman", "Shimano"] },
                    ],
                },
                {
                    id: 803,
                    name: t("Team Sports"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Soccer", "Basketball", "Baseball"] },
                        { id: "brand", name: t("Brand"), options: ["Adidas", "Nike"] },
                    ],
                },
            ],
        },
        toys: {
            id: 9,
            name: t("Toys"),
            subcategories: [
                {
                    id: 901,
                    name: t("Action Figures"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Superhero", "Anime", "Movie"] },
                        { id: "brand", name: t("Brand"), options: ["Hasbro", "Mattel"] },
                    ],
                },
                {
                    id: 902,
                    name: t("Puzzles"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Jigsaw", "3D", "Wooden"] },
                        { id: "age", name: t("Age Group"), options: ["Kids", "Adults"] },
                    ],
                },
                {
                    id: 903,
                    name: t("Educational Toys"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["STEM", "Language", "Creative"] },
                        { id: "age", name: t("Age Group"), options: ["Preschool", "Elementary"] },
                    ],
                },
            ],
        },
        home_kitchen: {
            id: 10,
            name: t("Home & Kitchen"),
            subcategories: [
                {
                    id: 1001,
                    name: t("Kitchen Appliances"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Microwave", "Blender", "Coffee Maker"] },
                        { id: "brand", name: t("Brand"), options: ["Philips", "KitchenAid"] },
                    ],
                },
                {
                    id: 1002,
                    name: t("Cookware"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Pots", "Pans", "Utensils"] },
                        { id: "brand", name: t("Brand"), options: ["Tefal", "Prestige"] },
                    ],
                },
                {
                    id: 1003,
                    name: t("Bedding"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Sheets", "Blankets", "Pillows"] },
                        { id: "material", name: t("Material"), options: ["Cotton", "Silk", "Polyester"] },
                    ],
                },
            ],
        },
        health: {
            id: 11,
            name: t("Health"),
            subcategories: [
                {
                    id: 1101,
                    name: t("Personal Care"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Toothpaste", "Shampoo", "Deodorant"] },
                        { id: "brand", name: t("Brand"), options: ["Colgate", "Dove"] },
                    ],
                },
                {
                    id: 1102,
                    name: t("Medical Supplies"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Bandages", "Thermometers", "First Aid"] },
                        { id: "brand", name: t("Brand"), options: ["3M", "Omron"] },
                    ],
                },
                {
                    id: 1103,
                    name: t("Nutrition"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Vitamins", "Supplements", "Protein"] },
                        { id: "brand", name: t("Brand"), options: ["GNC", "Herbalife"] },
                    ],
                },
            ],
        },
        automotive: {
            id: 12,
            name: t("Automotive"),
            subcategories: [
                {
                    id: 1201,
                    name: t("Car Accessories"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Seat Covers", "Floor Mats", "Car Audio"] },
                        { id: "brand", name: t("Brand"), options: ["Ford", "Toyota", "Honda"] },
                    ],
                },
                {
                    id: 1202,
                    name: t("Motorcycle Parts"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Helmets", "Brakes", "Mirrors"] },
                        { id: "brand", name: t("Brand"), options: ["Yamaha", "Suzuki"] },
                    ],
                },
                {
                    id: 1203,
                    name: t("Tools & Equipment"),
                    filters: [
                        { id: "type", name: t("Type"), options: ["Wrenches", "Jacks", "Battery Chargers"] },
                        { id: "brand", name: t("Brand"), options: ["Bosch", "Makita"] },
                    ],
                },
            ],
        },

    };
}



export default function Navbar() {
    const { t, i18n } = useTranslation();
    const categories = getTranslatedCategories(t);
    const cartItems = useSelector((state) => state.cart);
    const orders = useSelector((state) => state.orders);
    const [flag, setFlag] = useState<string>(() => localStorage.getItem('flag') || 'https://flagsapi.com/GB/flat/64.png');
    const [searchTerm, setSearchTerm] = useState("");
    const [searchResults, setSearchResults] = useState<any[]>([]); // Explicitly type as any[] or Product[] if available
    const products = useSelector((state) => state.product);

    const navigate = useNavigate();

    const navigateToCart = () => {
        navigate('/cart');
    };
    const navigateToOrders = () => {
        navigate('/order');
    }
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

    const handleSearch = (e) => {
        e.preventDefault();
        if (!searchTerm.trim()) return;
        const found = products.find((p) => p.name.toLowerCase() === searchTerm.trim().toLowerCase());
        if (found) {
            const categoryKey = Object.keys(categories).find(
                (key) => categories[key].id === found.categoryId
            );
            if (categoryKey) {
                if (found.subcategoryId) {
                    navigate(`/category/${categoryKey}/${found.subcategoryId}`);
                } else {
                    navigate(`/category/${categoryKey}`);
                }
            }
        } else {
            alert("Product not found");
        }
    };

    const handleSearchChange = (e) => {
        const value = e.target.value;
        setSearchTerm(value);
        if (value.trim()) {
            const results = products.filter((p) =>
                p.name.toLowerCase().includes(value.trim().toLowerCase())
            );
            setSearchResults(results);
        } else {
            setSearchResults([]);
        }
    };

    const handleProductClick = (product) => {
        const categoryKey = Object.keys(categories).find(
            (key) => categories[key].id === product.categoryId
        );
        if (categoryKey) {
            if (product.subcategoryId) {
                navigate(`/category/${categoryKey}/${product.subcategoryId}`);
            } else {
                navigate(`/category/${categoryKey}`);
            }
        }
        setSearchResults([]);
        setSearchTerm(product.name);
    };


    const isLoggedIn = !!localStorage.getItem("userToken");
    const handleLogout = () => {
        localStorage.removeItem("userToken");
        navigate('/login');
    };
    return (
        <div className="flex flex-col bg-gray-800 w-full p-4 text-white">
            <div className='flex flex-row items-center justify-between'>
                <img src="\src\assets\images\Gemini_Generated_Image_fym6k9fym6k9fym6-Photoroom.png" className='w-50 h-50 cursor-pointer' alt="Company Logo" onClick={() => { navigate("/") }} />
                <form className="relative w-full ml-6" onSubmit={handleSearch}>
                    <Input
                        value={searchTerm}
                        onChange={handleSearchChange}
                        placeholder={t('Search on Shah')}
                        className='bg-white pl-10 pr-4 py-2 w-full text-gray-800 rounded-100 rounded-4xl'
                    />
                    <span className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400 hover:text-gray-600 transition duration-200">
                        <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <circle cx="11" cy="11" r="7" stroke="currentColor" strokeWidth="2" />
                            <line x1="16.65" y1="16.65" x2="21" y2="21" stroke="currentColor" strokeWidth="2" strokeLinecap="round" />
                        </svg>
                    </span>
                    {searchResults.length > 0 && (
                        <div className="absolute z-10 left-0 right-0 mt-2 bg-white text-gray-800 rounded shadow-lg max-h-60 overflow-y-auto">
                            {searchResults.map((product: any) => (
                                <div
                                    key={product.id}
                                    className="px-4 py-2 cursor-pointer hover:bg-gray-200"
                                    onClick={() => handleProductClick(product)}
                                >
                                    {product.image && (
                                        <img src={product.image} alt={t(product.name)} className="w-10 h-10 ml-2 inline-block" />
                                    )}
                                    {t(product.name)}

                                </div>
                            ))}
                        </div>
                    )}
                </form>


                <div className="flex items-center justify-center w-200 items-center ml-4">
                    <HoverCard>
                        <HoverCardTrigger>
                            <Button variant="outline" className="text-white cursor-pointer h-12 bg-gray-700" >
                                <div className="flex items-center justify-center rounded-full">
                                    <Avatar>
                                        <AvatarImage id='AvatarImage' src="" alt="User Avatar" />
                                        <AvatarFallback className='text-white-500 bg-transparent'>
                                            {!!localStorage.getItem("profile") && isLoggedIn? (
                                                <img src={JSON.parse(localStorage.getItem("profile")).profilePicPreview} alt="User Avatar" className="w-6 h-6 rounded-full" />
                                            ) : (
                                                <VscAccount className="w-6 h-6" />
                                            )}
                                        </AvatarFallback>
                                    </Avatar>
                                </div>
                                <span>
                                    {!!localStorage.getItem("profile") && isLoggedIn ? JSON.parse(localStorage.getItem("user")).username : t('Account')}
                                </span>
                            </Button>
                        </HoverCardTrigger>
                        <HoverCardContent className="w-40 ">
                            <div className="flex flex-col space-y-2">
                                {!isLoggedIn ? (
                                    <>
                                        <Button variant="outline" className="mt-2" onClick={() => navigate('/login')}>{t('Login')}</Button>
                                        <Button variant="outline" className="mt-2" onClick={() => navigate('/reg')}>{t('Sign Up')}</Button>
                                    </>
                                ) : (
                                    <>
                                        <Button variant="outline" className="mt-2" onClick={() => navigate('/profile')}>{t('Profile')}</Button>
                                        <Button variant="outline" className="mt-2" onClick={handleLogout}>{t('Logout')}</Button>
                                    </>
                                )}
                            </div>
                        </HoverCardContent>
                    </HoverCard>

                    <Button variant="outline" className="relative text-white bg-gray-700 h-12 cursor-pointer ml-2" onClick={navigateToOrders}>
                        <div id='Orders' className="flex items-center justify-center rounded-full p-2 relative">
                            <TfiPackage className="mr-2 w-2" />
                            {orders.length > 0 ? (
                                <span id="ordersCount" className="absolute -top-1 -right-1 bg-red-600 text-white text-xs font-bold rounded-full px-1.5 py-0.5 border-2 border-gray-800">
                                    {orders.length}
                                </span>)
                                : null}
                        </div>
                        <span>{t('Orders')}</span>
                    </Button>
                    <Button variant="outline" className="text-white bg-gray-700 h-12 cursor-pointer ml-2" onClick={navigateToCart}>
                        <div id='Cart' className="flex items-center justify-center rounded-full p-2 relative">
                            <BsCart3 className="mr-2 w-2" />
                            {cartItems.length > 0 ? (
                                <span id="CartCount" className="absolute -top-1 -right-1 bg-red-600 text-white text-xs font-bold rounded-full px-1.5 py-0.5 border-2 border-gray-800">
                                    {cartItems.length}
                                </span>)
                                : null}
                        </div>
                        <span>{t('Cart')}</span>
                    </Button>
                </div>
            </div>
            <div>
                <div className="flex items-center justify-between mt-4">
                    <SideBar categories={categories}></SideBar>
                    <div className="flex items-center space-x-2">
                        <img src={flag} alt={t('flag')} className='w-10 h-10' />
                        <select className="languageDropdown bg-white text-gray-800 p-2 rounded" id="langSelect"
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
    );
}