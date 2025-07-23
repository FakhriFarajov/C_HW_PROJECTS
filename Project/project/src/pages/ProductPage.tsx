import { useParams } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { Badge } from '@/components/ui/badge';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Star } from 'lucide-react';
import ImageCarousel from "../components/custom/carousel";
import { BsCart3 } from 'react-icons/bs';
import { addToCart } from '@/store/cartSlice';
import { useDispatch } from 'react-redux';
import Navbar from '@/components/custom/Navbar/navbar';
import Footer from '@/components/custom/footer';
import { useState } from 'react';
import { useTranslation } from "react-i18next";

export default function ProductPage() {
  const { t } = useTranslation();
  const dispatch = useDispatch();
  const cartItems = useSelector((state: any) => state.cart);
  const { id } = useParams();

  const product = useSelector((state: any) =>
    state.product.find((p: any) => String(p.id) === String(id))
  );
  const isOutOfStock = product?.inStock <= 0;

  // Use product.sizes and product.colors for initial state
  const [selectedSize, setSelectedSize] = useState(Array.isArray(product?.sizes) ? product.sizes[0] : null);
  const [selectedColor, setSelectedColor] = useState(Array.isArray(product?.colors) ? product.colors[0] : null);

  // Check if this exact variant is in cart
  const isVariantInCart = cartItems.some((item: any) =>
    item.id === product.id &&
    item.size === selectedSize &&
    item.color === selectedColor
  );

  const renderButtonLabel = () => {
    if (isOutOfStock) return t('Out of Stock');
    if (isVariantInCart) return t('Already in Cart');
    if (!selectedSize || !selectedColor) return t('Select Size and Color');
    return t('Add to Cart');
  };

  const handleAddToCart = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.stopPropagation();
      // Prevent add to cart if not logged in
    const user = JSON.parse(localStorage.getItem("user") || "null");
    const isLoggedIn = !!localStorage.getItem("userToken") && user;
    if (!isLoggedIn) {
      alert("Please log in to add items to your cart.");
      return;
    }
    if (isOutOfStock || isVariantInCart || !selectedSize || !selectedColor) return;
    const productWithSelection = {
      ...product,
      selectedSize,
      selectedColor,
    };
    dispatch(addToCart(productWithSelection));
  };



  if (!product) {
    return <div className="p-8 text-center text-red-500">{t('Product not found')}</div>;
  }
  return (
    <>
      <Navbar></Navbar>
      <div className="w-full mx-auto p-6 bg-white rounded-lg shadow-lg mt-8 h-lvh">
        <div className="flex flex-col md:flex-row gap-8">
          <div className="flex-1 flex flex-col items-center">
            {product?.images?.length ? (
              <ImageCarousel slides={product.images}  />
            ) : (
              <div className="w-full h-64 bg-gray-200 flex items-center justify-center rounded-lg">
                {t('No Image')}
              </div>
            )}
          </div>
          <div className="flex-1 flex flex-col gap-4">
                <h1 className="text-2xl font-bold">{t(product.name)}</h1>
                <p className="text-muted-foreground">{t(product.category)}</p>
                <div>
                    <Badge>{t('Price')}: ${product.price}</Badge>
                    {product.oldPrice && (
                        <Badge className="bg-red-600 line-through ml-2">{t('Old Price')}: ${product.oldPrice}</Badge>
                    )}
                    <div className="flex gap-1 items-center">
                        <span className="text-sm text-muted-foreground">{t('In Stock')}: {product.inStock}</span>
                    </div>
                </div>
                {product.description && (
                    <p className="text-gray-700 text-sm">{t(product.description)}</p>
                )}
                <div className="flex gap-1 items-center">
                    {[...Array(5)].map((_, i) => (
                        <Star key={i} size={20}
                            className={i < product.rating ? 'text-yellow-500' : 'text-gray-300'}
                            fill={i < product.rating ? 'currentColor' : 'none'} />
                    ))}
                    <span className="text-sm text-muted-foreground ml-2">({product.rating})</span>
                </div>
                <div className="flex items-center gap-1">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16">
                        <path fill="currentColor" d="M8.545 13C11.93 13 14 11.102 14 8s-2.07-5-5.455-5C5.161 3 3.091 4.897 3.091 8c0 1.202.31 2.223.889 3.023-.2.335-.42.643-.656.899-.494.539-.494 1.077.494 1.077.89 0 1.652-.15 2.308-.394.703.259 1.514.394 2.42.394" />
                    </svg>
                    <Label>{product.reviews} {t('reviews')}</Label>
                </div>
                <div className="flex gap-2 mt-4">
                    <Button
                        size="sm"
                        className="w-full"
                        onClick={handleAddToCart}
                        disabled={isOutOfStock || isVariantInCart || !selectedSize || !selectedColor}
                    >
                        <BsCart3 className="mr-2 w-4 h-4" />
                        {renderButtonLabel()}
                    </Button>
                </div>
          </div>
        </div>
        <div className="flex flex-col mt-4">
          <Label>{t('Size')}:</Label>
          <select
            value={selectedSize}
            onChange={(e) => setSelectedSize(e.target.value)}
            className="border rounded p-2"
          >
            {product.sizes.map((size: string) => (
              <option key={size} value={size}>
                {t(size)}
              </option>
            ))}
          </select>
        </div>

        <div className="flex flex-col mt-4">
          <Label>{t('Color')}:</Label>
          <div className="flex gap-2">
            {product.colors.map((color: string) => (
              <button
                key={color}
                onClick={() => setSelectedColor(color)}
                className={`w-8 h-8 rounded-full border-2 ${selectedColor === color ? 'border-black' : 'border-transparent'}`}
                style={{ backgroundColor: color }}
                title={t(color)}
              />
            ))}
          </div>
        </div>

      </div>
      <Footer></Footer>
    </>
  );
}
