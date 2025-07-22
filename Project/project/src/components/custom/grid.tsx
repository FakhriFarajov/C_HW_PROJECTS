import { Badge } from "@/components/ui/badge";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { getTranslatedCategories } from "./Navbar/navbar"; // Use the helper function

export default function Grid() {
    const navigate = useNavigate();
    const { t } = useTranslation();
    const categories = getTranslatedCategories(t);
    return (
        Object.entries(categories).map(([key, category]: [string, any]) => (
            <div className="flex justify-center" key={key}>
                <span className="cursor-pointer" onClick={() => navigate(`/category/${key}`)}>
                    <Badge className="text-xs bg-white-100 border-solid border-gray text-gray-700 h-12 w-24">{t(category.name)}</Badge>
                </span>
            </div>
        ))
    );
}