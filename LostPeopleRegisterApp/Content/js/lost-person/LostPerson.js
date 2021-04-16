/*
 * Skrypt do zarządzania zachowaniami elementów na stronie
 * wyświetlającej wyniki wyszukiwania osób zaginionych
 */
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";

var profleImages = [...document.querySelectorAll(".lost-person-thumbnail")];


profleImages.forEach(img => {
    img.appendChild(new ProfileImage({
        image: img.dataset.image,
        cornered: true,
        width: "100px",
        iconFontSize: "32px"
    }).print());
});