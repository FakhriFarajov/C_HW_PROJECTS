import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Home, Users, ShoppingCart, Store } from "lucide-react";
import { Link } from "react-router-dom";

export default function AdminSidebar() {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <div className="flex">
      {/* Sidebar */}
      <aside
        className="h-screen bg-gray-900 text-white flex flex-col shadow-lg"
      >

        <nav className="flex-1 space-y-2 p-2">
          <Link to="/buyers" className="flex items-center gap-3 p-2 rounded-lg hover:bg-gray-800">
            <Users size={20} /><span>Buyers</span>
          </Link>
          <Link to="/sellers" className="flex items-center gap-3 p-2 rounded-lg hover:bg-gray-800">
            <Store size={20} /> {!collapsed && <span>Sellers</span>}
          </Link>
          <Link to="/orders" className="flex items-center gap-3 p-2 rounded-lg hover:bg-gray-800">
            <ShoppingCart size={20} /> {!collapsed && <span>Orders</span>}
          </Link>
        </nav>
      </aside>

      {/* Main content */}
      <main className="flex-1 p-6">
        {/* Your NavBar is already here above or can be included */}
        <h2 className="text-2xl font-semibold">Dashboard Content</h2>
      </main>
    </div>
  );
}
