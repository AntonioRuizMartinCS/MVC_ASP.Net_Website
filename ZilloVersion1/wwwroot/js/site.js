// Get the left and right arrow elements
const leftArrow = document.getElementById("leftArrow");
const rightArrow = document.getElementById("rightArrow");

// Get the three elements to be swapped
const element1 = document.getElementById("element1");
const element2 = document.getElementById("element2");
const element3 = document.getElementById("element3");

// Initialize the current index to 1 (the middle element)
let currentIndex = 1;

// Add click event listeners to the left and right arrow elements
if (leftArrow != null || rightArrow != null) {

    leftArrow.addEventListener("click", () => {
        // Decrease the current index by 1
        currentIndex--;

        // Wrap the index around if it goes below 1
        if (currentIndex < 1) {
            currentIndex = 3;
        }

        // Hide all elements
        element1.classList.add("invisible");
        element2.classList.add("invisible");
        element3.classList.add("invisible");


        if (currentIndex === 1) {
            element1.classList.remove("invisible");
        } else if (currentIndex === 2) {
            element2.classList.remove("invisible");
        } else {
            element3.classList.remove("invisible");
        }
    });

    rightArrow.addEventListener("click", () => {
        // Increase the current index by 1
        currentIndex++;

        // Wrap the index around if it goes above 3
        if (currentIndex > 3) {
            currentIndex = 1;
        }

        // Hide all elements
        element1.classList.add("invisible");
        element2.classList.add("invisible");
        element3.classList.add("invisible");

        // Show the element at the current index
        if (currentIndex === 1) {
            element1.classList.remove("invisible");
        } else if (currentIndex === 2) {
            element2.classList.remove("invisible");
        } else {
            element3.classList.remove("invisible");
        }
    });

}

window.onload = function () {

    const menu_btn = document.querySelector('.hamburger');
    const mobile_menu = document.querySelector('.mobile-nav');

    menu_btn.addEventListener('click', function () {
        menu_btn.classList.toggle('is-active');
        mobile_menu.classList.toggle('is-active');
    });
}


















































































