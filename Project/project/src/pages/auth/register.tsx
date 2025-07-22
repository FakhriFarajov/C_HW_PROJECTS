import RegForm from "@/components/custom/reg-form/reg-form";

export default function register() {
    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-md p-8 bg-white rounded-lg shadow-md">
                <RegForm />
            </div>
        </div>
    );
}