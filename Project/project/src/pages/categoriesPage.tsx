import { useParams, useNavigate } from 'react-router-dom';
import { useMemo, useState } from 'react';
import { useSelector } from 'react-redux';
import { getTranslatedCategories } from '@/components/custom/Navbar/navbar';
import NavBar from '@/components/custom/Navbar/navbar';
import { ProductCard } from '@/components/custom/itemCard';
import { use } from 'i18next';
import { useEffect } from 'react';
import { useTranslation } from 'react-i18next';

export default function CategoryPage() {
  const { t } = useTranslation();
  const categories = getTranslatedCategories(t);
  const { category: categoryId, subcategory: subcategoryId } = useParams();
  const navigate = useNavigate();
  const allProducts = useSelector((state) => state.product);
  const category = categoryId ? categories[categoryId] : undefined;
  const [selectedFilters, setSelectedFilters] = useState<{ [key: string]: string[] }>({});
  const [priceRange, setPriceRange] = useState({ min: '', max: '' });
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 10;

  const selectedSubcategory = subcategoryId ?? null;

  const handleSubcategoryClick = (subcatId: string | null) => {
    if (!categoryId) return;
    navigate(subcatId ? `/category/${categoryId}/${subcatId}` : `/category/${categoryId}`);
    setSelectedFilters({});
    setPriceRange({ min: '', max: '' });
  };

  const filteredProducts = useMemo(() => {
    if (!category) return [];
    return allProducts.filter((product: any) => {
      if (product.categoryId !== category.id) return false;
      if (selectedSubcategory && String(product.subcategoryId) !== selectedSubcategory) return false;
      // Price filter
      const price = product.price;
      if (priceRange.min && price < Number(priceRange.min)) return false;
      if (priceRange.max && price > Number(priceRange.max)) return false;
      return Object.entries(selectedFilters).every(([filterId, values]: [string, any[]]) => {
        if (!values.length) return true;
        return values.includes(String(product[filterId]));
      });
    });
  }, [allProducts, selectedFilters, category, selectedSubcategory, priceRange]);

  const allFilters = useMemo(() => {
    if (!category) return [];
    const filtersMap: Record<string, any> = {};
    category.subcategories.forEach((subcat: any) => {
      subcat.filters.forEach((filter: any) => {


        if (!filtersMap[filter.id]) {
          filtersMap[filter.id] = {
            id: filter.id,
            name: filter.name,
            options: new Set(filter.options),
          };
        } else {
          filter.options.forEach((opt: any) => filtersMap[filter.id].options.add(opt));
        }
      });
    });
    return Object.values(filtersMap).map((f: any) => ({
      id: f.id,
      name: f.name,
      options: Array.from(f.options),
    }));
  }, [category]);


  useEffect(() => {
    if (!categoryId) return;
    setSelectedFilters({});
    setPriceRange({ min: '', max: '' });
  }, [categoryId])

  // Reset page when filters, category, or subcategory change
  useEffect(() => {
    setCurrentPage(1);
  }, [selectedFilters, priceRange, categoryId, selectedSubcategory]);

  // Paginated products
  const paginatedProducts = filteredProducts.slice((currentPage - 1) * pageSize, currentPage * pageSize);
  const totalPages = Math.ceil(filteredProducts.length / pageSize);

  if (!category) return <div className="p-8">Category not found.</div>;

  return (
    <>
      <NavBar />
      <div className="p-8 grid grid-cols-12 gap-6">
        <section className="col-span-12 mb-4">
          <h1 className="text-3xl font-bold mb-6 text-left">{category.name} </h1>
        </section>
        <aside className="col-span-3 bg-white rounded-md shadow p-4 sticky top-4 h-fit">
          <h2 className="text-lg font-semibold mb-4">{t('Filters')}</h2>
          <button
            className="mb-4 px-3 py-1 bg-gray-200 rounded hover:bg-gray-300 text-sm"
            onClick={() => setSelectedFilters({})}
          >
            {t('Uncheck All')}
          </button>
          {/* Price filter UI */}
          <div className="mb-4">
            <h3 className="font-medium mb-2">{t('Price')}</h3>
            <div className="flex gap-2">
              <input
                type="number"
                placeholder={t('Min')}
                className="border rounded px-2 py-1 w-20"
                value={priceRange.min}
                onChange={e => setPriceRange(r => ({ ...r, min: e.target.value }))}
              />
              <span>-</span>
              <input
                type="number"
                placeholder={t('Max')}
                className="border rounded px-2 py-1 w-20"
                value={priceRange.max}
                onChange={e => setPriceRange(r => ({ ...r, max: e.target.value }))}
              />
            </div>
          </div>
          {allFilters.map((filter: any) => (
            <div key={filter.id} className="mb-4">
              <h3 className="font-medium mb-2">{t(filter.name)}</h3>
              <div className="space-y-1">
                {filter.options.map((option: string) => (
                  <label key={option} className="flex items-center space-x-2">
                    <input
                      type="checkbox"
                      checked={selectedFilters[filter.id]?.includes(option) || false}
                      onChange={(e) => {
                        const checked = e.target.checked;
                        setSelectedFilters((prev: Record<string, any[]>) => {
                          const current = prev[filter.id] || [];
                          return {
                            ...prev,
                            [filter.id]: checked
                              ? [...current, option]
                              : current.filter((v: string) => v !== option),
                          };
                        });
                      }}
                      className="form-checkbox"
                    />
                    <span>{t(option)}</span>
                  </label>
                ))}
              </div>
            </div>
          ))}
        </aside>

        <section className="col-span-9">
          <div className="mb-6 flex flex-wrap gap-2">
            {category.subcategories.map((subcat: any) => (
              <button
                key={subcat.id}
                className={`px-4 py-2 rounded border ${selectedSubcategory === String(subcat.id) ? 'bg-blue-600 text-white' : 'bg-white text-gray-800'}`}
                onClick={() => handleSubcategoryClick(subcat.id)}
              >
                {subcat.name}
              </button>
            ))}
            <button
              className={`px-4 py-2 rounded border ${!selectedSubcategory ? 'bg-blue-600 text-white' : 'bg-white text-gray-800'}`}
              onClick={() => handleSubcategoryClick(null)}
            >
              {t('All')}
            </button>
          </div>
          {filteredProducts.length > 0 ? (
            <>
              <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 2xl:grid-cols-5 gap-4">
                {paginatedProducts.map((product: any) => (
                  <ProductCard key={product.id} product={product} />
                ))}
              </div>
              {/* Pagination controls */}
              <div className="flex justify-center items-center mt-6 gap-2">
                <button
                  className="px-3 py-1 rounded border bg-gray-200 hover:bg-gray-300"
                  disabled={currentPage === 1}
                  onClick={() => setCurrentPage(p => Math.max(1, p - 1))}
                >
                  {t('Prev')}
                </button>
                {Array.from({ length: totalPages }, (_, i) => i + 1).map(page => (
                  <button
                    key={page}
                    className={`px-3 py-1 rounded border ${currentPage === page ? 'bg-blue-600 text-white' : 'bg-white text-gray-800'}`}
                    onClick={() => setCurrentPage(page)}
                  >
                    {page}
                  </button>
                ))}
                <button
                  className="px-3 py-1 rounded border bg-gray-200 hover:bg-gray-300"
                  disabled={currentPage === totalPages}
                  onClick={() => setCurrentPage(p => Math.min(totalPages, p + 1))}
                >
                  {t('Next')}
                </button>
              </div>
            </>
          ) : (
            <p className="text-center text-gray-500">{t('no_products_found')}</p>
          )}
        </section>
      </div>
    </>
  );
}