import NavBar  from "@/components/custom/Navbar/navbar";
import { getTranslatedCategories } from '@/components/custom/Navbar/getTranslatedCategories';
import Carousel from "@/components/custom/carousel";
import Grid from "@/components/custom/ProductGrid";
import Footer from "@/components/custom/footer"
import { Label } from "@/components/ui/label";
import { ProductCard } from "@/components/custom/itemCard";
import { useDispatch, useSelector } from "react-redux";
import { setProducts } from "@/store/productSlice";
import { useEffect } from "react";
import "../i18n"; // Import i18n configuration
import { useTranslation } from "react-i18next";

interface Product {
    id: string;
    name: string;
    description: string;
    category: string;
    subcategoryId?: number;
    brand: string; // Added brand field
    price: number;
    oldPrice: number;
    image: string;
    size: string | string[];
    currency: string;
    discount: number;
    daysLeft: number;
    rating: number;
    reviews: number;
    inStock: number;
}

// Type for subcategory filter
interface SubcategoryFilter {
    id: string;
    options: string[];
    multi?: boolean;
}

const slides = [
    "https://aimg.kwcdn.com/material-put/2079f6251c/cc20ce65-db4a-4d92-aeee-37122020bca6.png?imageView2/q/70/format/webp",
    "https://ir.ozone.ru/s3/cms/fb/ta5/wc1450/en-tur_desktop_2832x600_1.jpg",
    "https://ir.ozone.ru/s3/cms/c4/t38/wc1450/azengchina.jpg",
    "https://ir.ozone.ru/s3/cms/14/ta8/wc1450/2832x600.jpg"


]


export default function Main() {
    const { t } = useTranslation();
    const categories: { [key: string]: { id: number; name: any; subcategories: { id: number; name: any; filters: SubcategoryFilter[] }[] } } = getTranslatedCategories(t);
    const dispatch = useDispatch();
    const products = useSelector((state: any) => state.product);


    useEffect(() => {
        if (products.length === 0) {
            const generatedProducts = Array.from({ length: 300 }, (_, i) => {
                const categoryKeys = Object.keys(categories);
                const randomCategoryKey = categoryKeys[Math.floor(Math.random() * categoryKeys.length)];
                const categoryObj = categories[randomCategoryKey];

                const randomSubcat = categoryObj.subcategories[
                    Math.floor(Math.random() * categoryObj.subcategories.length)
                ];

                const filterFields: Record<string, string | string[]> = {};
                (randomSubcat.filters as SubcategoryFilter[]).forEach((filter: SubcategoryFilter) => {
                    if (Array.isArray(filter.options) && filter.options.length > 0) {
                        if (filter.multi) {
                            const shuffled = [...filter.options].sort(() => 0.5 - Math.random());
                            filterFields[filter.id] = shuffled.slice(0, Math.max(1, Math.floor(Math.random() * 2 + 1)));
                        } else {
                            filterFields[filter.id] = filter.options[Math.floor(Math.random() * filter.options.length)];
                        }
                    }
                });

                const brandFilter = (randomSubcat.filters as SubcategoryFilter[]).find((f: SubcategoryFilter) => f.id === "brand");
                const randomBrand = brandFilter
                    ? brandFilter.options[Math.floor(Math.random() * brandFilter.options.length)]
                    : "GenericBrand";

                const price = +(Math.random() * 200 + 10).toFixed(2);
                const oldPrice = +(price + Math.random() * 100 + 10).toFixed(2);

                return {
                    id: (i + 3).toString().padStart(3, '0'),
                    name: `Product ${i + 3}`,
                    description: `This is a description for Product ${i + 3}. High quality and great value!`,
                    category: categoryObj.name,
                    categoryId: categoryObj.id,
                    subcategoryId: randomSubcat.id,
                    brand: randomBrand,
                    price,
                    oldPrice,
                    images: Array.from({ length: 4 }, (_, j) => `https://picsum.photos/seed/product${i + 3}-${j}/400/400`),
                    sizes: ["S", "M", "L", "XL"],
                    colors: ["Red", "Blue", "Green", "Black"],
                    storage: ["64GB", "128GB", "256GB"],
                    currency: "USD",
                    discount: +(oldPrice - price).toFixed(2),
                    daysLeft: Math.floor(Math.random() * 30) + 1,
                    rating: Math.floor(5),
                    reviews: Math.floor(Math.random() * 100) + 1,
                    inStock: Math.floor(Math.random() * 20) + 1,
                    ...filterFields
                };
            });

            dispatch(setProducts([...generatedProducts]));
        }
        console.log("Products loaded:", products);
    }, [dispatch, products.length]);

    return (
        <>
            <NavBar />
            <div className="flex flex-col items-center justify-center bg-gray-100">
                <div className="flex flex-col items-center justify-center w-full p-2 sm:p-4 bg-white rounded-lg shadow-md">
                    <Carousel slides={slides} />
                </div>
            </div>

            <div className="flex flex-col justify-center align-center w-full p-2 sm:p-6 bg-white rounded-lg shadow-md mt-4 sm:mt-6">
                <Label className="text-2xl sm:text-4xl text-center font-semibold mb-4">{t('Featured Products')}</Label>
                <div className="w-full max-w-full mx-auto">
                    <div className="grid grid-cols-2 xs:grid-cols-2 md:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-3 sm:gap-4">
                        {products.slice(0, 30).map((product: Product, i: number) => (
                            <ProductCard key={product.id || i} product={{
                                ...product,
                                name: t(product.name),
                                description: t(product.description),
                                category: t(product.category),
                                brand: t(product.brand),
                                currency: t(product.currency)
                            }} />
                        ))}
                    </div>
                </div>
            </div>
            <div className="flex flex-col items-center justify-center w-full p-2 sm:p-6 bg-white rounded-lg shadow-md mt-4 sm:mt-6">
                <Label className="text-2xl sm:text-4xl text-center font-semibold mb-4">{t('Explore More')}</Label>
            </div>

            <div className="flex flex-col items-center justify-center w-full p-2 sm:p-6 bg-white rounded-lg shadow-md mt-4 sm:mt-6">
                <div className="w-full max-w-full">
                    <Grid />
                </div>
            </div>


            <Footer />
        </>
    );
}