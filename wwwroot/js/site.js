// Função genérica para controlar o movimento de carrosséis
function scrollCarouselGeneric(trackSelector, cardSelector, direction) {
    const track = document.querySelector(trackSelector);
    const cards = document.querySelectorAll(`${trackSelector} ${cardSelector}`);
    if (cards.length === 0) return; // Verifica se há cartões

    const cardWidth = cards[0].offsetWidth + 20; // Largura do card + espaçamento
    const visibleCards = Math.floor(track.offsetWidth / cardWidth); // Quantos cabem visíveis
    const totalCards = cards.length;

    // Pegamos o índice atual do slide
    let currentSlide = parseInt(track.getAttribute("data-current-slide") || 0);

    // Atualizamos o índice baseado na direção
    currentSlide += direction;

    // Limitar os índices para não sair fora
    currentSlide = Math.max(0, Math.min(currentSlide, totalCards - visibleCards));

    // Atualizamos o atributo no elemento track
    track.setAttribute("data-current-slide", currentSlide);

    // Movemos o carrossel
    const newTransform = -currentSlide * cardWidth;
    track.style.transform = `translateX(${newTransform}px)`;
}

// Eventos para o carrossel "Livros em Destaque"
document.querySelector("#carousel-destaques .prev").addEventListener("click", () => {
    scrollCarouselGeneric("#carousel-destaques .carousel2-track", ".card_ld", -1);
});
document.querySelector("#carousel-destaques .next").addEventListener("click", () => {
    scrollCarouselGeneric("#carousel-destaques .carousel2-track", ".card_ld", 1);
});

// Eventos para o carrossel "Adicionados Recentemente"
document.querySelector("#carousel-adicionados .prev").addEventListener("click", () => {
    scrollCarouselGeneric("#carousel-adicionados .carousel2-track", ".card_ld", -1);
});
document.querySelector("#carousel-adicionados .next").addEventListener("click", () => {
    scrollCarouselGeneric("#carousel-adicionados .carousel2-track", ".card_ld", 1);
});


document.addEventListener("DOMContentLoaded", function () {
    var toggleDescriptionButton = document.querySelector(".toggle-description");
    var descriptionContent = document.querySelector(".description-content");

    toggleDescriptionButton.addEventListener("click", function () {
        if (descriptionContent.classList.contains("expanded")) {
            descriptionContent.classList.remove("expanded");
            toggleDescriptionButton.textContent = "Ver Mais";
        } else {
            descriptionContent.classList.add("expanded");
            toggleDescriptionButton.textContent = "Ver Menos";
        }
    });
});


