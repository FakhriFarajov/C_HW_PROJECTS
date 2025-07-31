import { Card, CardHeader, CardContent, CardFooter } from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { Label } from "@/components/ui/label";
import { Star } from "lucide-react";
import { useDispatch, useSelector } from "react-redux";
import { useTranslation } from "react-i18next";


export function ProductCard({ product }) {
  const cartItems = useSelector((state) => state.cart);
  const t = useTranslation().t;

  return (
    <div
      className="cursor-pointer w-full"
      onClick={() => window.location.href = `/product/${product.id}`}
    >
      <Card className="w-full h-full flex flex-col p-0 group transition hover:scale-[1.03] hover:shadow-xl">
        <CardHeader className="p-0">
          <img
            src={product?.images?.[0]}
            alt={product.name}
            className="w-full h-40 sm:h-48 object-cover rounded-t-lg"
          />
        </CardHeader>
        <CardContent className="p-3 sm:p-4 space-y-1 flex-1 flex flex-col">
          <h4 className="font-semibold text-base sm:text-lg">{product.name}</h4>
          <p className="text-xs sm:text-sm text-muted-foreground">{t(product.category)}</p>
          {product.description && (
            <p className="text-xs text-gray-500 mb-1 line-clamp-2">{product.description.slice(0, 30)}...</p>
          )}
          <div>
            <Badge>${product.price}</Badge>
            {product.oldPrice && (
              <Badge className="bg-red-600 line-through">${product.oldPrice}</Badge>
            )}
          </div>
          <div className="flex gap-1 items-center">
            {[...Array(5)].map((_, i) => (
              <Star key={i} size={16}
                className={i < product.rating ? "text-yellow-500" : "text-gray-300"}
                fill={i < product.rating ? "currentColor" : "none"} />
            ))}
            <span className="text-xs sm:text-sm text-muted-foreground ml-2">({product.rating})</span>
          </div>
          <div className="flex items-center gap-1 mt-auto">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16">
              <path fill="currentColor" d="M8.545 13C11.93 13 14 11.102 14 8s-2.07-5-5.455-5C5.161 3 3.091 4.897 3.091 8c0 1.202.31 2.223.889 3.023-.2.335-.42.643-.656.899-.494.539-.494 1.077.494 1.077.89 0 1.652-.15 2.308-.394.703.259 1.514.394 2.42.394" />
            </svg>
            <Label>{product.reviews} {t('reviews')}</Label>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}
