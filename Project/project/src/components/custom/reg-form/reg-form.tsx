import { cn } from "@/lib/utils"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { useState } from "react"
import { useTranslation } from "react-i18next"
import { toast } from "sonner"

export default function RegForm({
  className,
  ...props
}: React.ComponentProps<"div">) {
  const { t } = useTranslation()
  const [username, setUsername] = useState("")
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")

  const handleRegister = (e: React.FormEvent) => {
    e.preventDefault()
    // Save user to localStorage as an object with all fields
    const user = { username, email, password }
    localStorage.setItem("userToken", "demoToken") // You can use a real token or uuid
    localStorage.setItem("user", JSON.stringify(user))
    toast.success(t('Registration successful!'))
    window.location.href = "/profile" // Redirect to profile or main page
  }

  return (
    <div className={cn("flex flex-col gap-6", className)} {...props}>
      <form onSubmit={handleRegister}>
        <div className="flex flex-col gap-6">
          <div className="flex flex-col items-center gap-2">
            <a
              href="/main"
              className="flex flex-col items-center gap-2 font-medium"
            >
              <div className="flex w-50 h-30 items-center justify-center rounded-md">
                <img
                  src="\src\assets\images\Gemini_Generated_Image_fym6k9fym6k9fym6-Photoroom.png"
                  className="w-50 h-50"
                  alt={t("Company Logo")}
                />
              </div>
            </a>
            <h1 className="text-xl font-bold">{t("Welcome to Shah.")}</h1>
            <div className="text-center text-sm">
              {t("Already have an account?")}{" "}
              <a href="/login" className="underline underline-offset-4">
                {t("Sign in")}
              </a>
            </div>
          </div>
          <div className="flex flex-col gap-6">
            <div className="grid gap-3">
              <Label htmlFor="Username">{t("Username")}</Label>
              <Input
                id="Username"
                type="text"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
            </div>
            <div className="grid gap-3">
              <Label htmlFor="email">{t("Email")}</Label>
              <Input
                id="email"
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder={t("m@example.com")}
                required
              />
            </div>

            <div className="grid gap-3">
              <Label htmlFor="password">{t("Password")}</Label>
              <Input
                id="password"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            <Button
              type="submit"
              className="w-full bg-gray-800 hover:bg-gray-700 text-white hover:text-gray-100"
            >
              {t("Register")}
            </Button>
          </div>
          <div className="after:border-border relative text-center text-sm after:absolute after:inset-0 after:top-1/2 after:z-0 after:flex after:items-center after:border-t">
            <span className="bg-background text-muted-foreground relative z-10 px-2">
              {t("Or")}
            </span>
          </div>
          <div className="grid gap-4 sm:grid-cols-2">
            <Button variant="outline" type="button" className="w-full">
              {/* Apple SVG unchanged */}
              {t("Continue with Apple")}
            </Button>
            <Button variant="outline" type="button" className="w-full">
              {/* Google SVG unchanged */}
              {t("Continue with Google")}
            </Button>
          </div>
        </div>
      </form>
      <div className="text-muted-foreground *:[a]:hover:text-primary text-center text-xs text-balance *:[a]:underline *:[a]:underline-offset-4">
        {t("By clicking continue, you agree to our")}{" "}
        <a href="#">{t("Terms of Service")}</a> {t("and")}{" "}
        <a href="#">{t("Privacy Policy")}</a>.
      </div>
    </div>
  )
}
