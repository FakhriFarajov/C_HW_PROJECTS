export class ValidationService {
    static emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    static passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/; 

    static validateEmail(email) {
        return this.emailRegex.test(email);
    }

    static validatePassword(password) {
        return this.passwordRegex.test(password);
    }
}
