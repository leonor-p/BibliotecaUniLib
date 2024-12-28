// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let currentSlide = 0;

function scrollCarousel(direction) {
    const track = document.querySelector(".carousel-track");
    const cardWidth = document.querySelector(".card").offsetWidth + 20; // Largura do card + espaçamento
    const totalCards = document.querySelectorAll(".carousel-track .card").length;

    currentSlide += direction;

    // Limita o movimento do carrossel
    if (currentSlide < 0) currentSlide = 0;
    if (currentSlide > totalCards - 3) currentSlide = totalCards - 3; // 3 cards visíveis

    // Calcula a nova posição
    const newTransform = -currentSlide * cardWidth;

    track.style.transform = `translateX(${newTransform}px)`;
}

let currentSlide = 0;

function scrollCarousel2(direction) {
    const track = document.querySelector(".carousel-track");
    const cardWidth = document.querySelector(".card").offsetWidth + 20; // Largura do card + espaçamento
    const totalCards = document.querySelectorAll(".carousel-track .card").length;

    currentSlide += direction;

    // Limita o movimento do carrossel
    if (currentSlide < 0) currentSlide = 0;
    if (currentSlide > totalCards - 3) currentSlide = totalCards - 3; // 3 cards visíveis

    // Calcula a nova posição
    const newTransform = -currentSlide * cardWidth;

    track.style.transform = `translateX(${newTransform}px)`;
}



