import { useParams } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { Badge } from '@/components/ui/badge';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Star } from 'lucide-react';
import ImageCarousel from './carousel';
import { BsCart3 } from 'react-icons/bs';

export default function ProductPage() {
  const { id } = useParams();
  const product = useSelector((state: any) =>
    state.product.find((p: any) => String(p.id) === String(id))
  );

  if (!product) {
    return <div className="p-8 text-center text-red-500">Product not found.</div>;
  }

  const handleAddToCart = () => {
    // Prevent add to cart if not logged in
    const user = JSON.parse(localStorage.getItem("user") || "null");
    const isLoggedIn = !!localStorage.getItem("userToken") && user;
    if (!isLoggedIn) {
      alert("Please log in to add items to your cart.");
      return;
    }
    // ...add to cart logic here...
  };

  return (
    <div className="max-w-3xl mx-auto p-6 bg-white rounded-lg shadow-lg mt-8">
      <div className="flex flex-col md:flex-row gap-8">
        <div className="flex-1 flex flex-col items-center">
          {product?.images?.length ? (
            <ImageCarousel slides={product.images} />
          ) : (
            <div className="w-full h-64 bg-gray-200 flex items-center justify-center rounded-lg">
              No Image
            </div>
          )}
        </div>
        <div className="flex-1 flex flex-col gap-4">
          <h1 className="text-2xl font-bold">{product.name}</h1>
          <p className="text-muted-foreground">{product.category}</p>
          <div>
            <Badge>${product.price}</Badge>
            {product.oldPrice && (
              <Badge className="bg-red-600 line-through ml-2">${product.oldPrice}</Badge>
            )}
          </div>
          {product.description && (
            <p className="text-gray-700 text-sm">{product.description}</p>
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
            <Label>{product.reviews} reviews</Label>
          </div>
          <div className="flex gap-2 mt-4">
            <Button size="sm" className="w-full" onClick={handleAddToCart}>
              <BsCart3 className="mr-2 w-4 h-4" />
              Add to Cart
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}
