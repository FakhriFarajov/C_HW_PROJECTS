const carousel = document.getElementById("carouselImages");
const slides = carousel.querySelectorAll("img");
const totalSlides = slides.length;
let currentIndex = 0;

const prevBtn = document.getElementById("PrevButton");
const nextBtn = document.getElementById("NextButton");

function updateCarousel() { 
    const slideWidth = carousel.offsetWidth;
    carousel.style.transform = `translateX(-${currentIndex * slideWidth}px)`;

    prevBtn.disabled = currentIndex === 0;
    nextBtn.disabled = currentIndex === totalSlides - 1;
}

function nextSlide() {
    if (currentIndex < totalSlides - 1) {
        currentIndex++;
        updateCarousel();
    }
}

function prevSlide() {
    if (currentIndex > 0) {
        currentIndex--;
        updateCarousel();
    }
}

prevBtn.addEventListener("click", prevSlide);
nextBtn.addEventListener("click", nextSlide);

updateCarousel();