let btnDropDown = document.querySelector("#dropdownMenuButton");
let dropDownMenu = document.querySelector(".nonscroll-menu ");

btnDropDown.addEventListener('click', () => {
    dropDownMenu.classList.toggle("d-block");
})
let btnDropDownToogle=document.querySelector(".dropdown-toggle");
let dropDownScrollMenu = document.querySelector(".scrollable-menu");

btnDropDownToogle.addEventListener('click', () => {
    dropDownScrollMenu.classList.toggle("d-block");
})
let btnCoutryDropDown=document.querySelector("#dropdownCountry");
let btnCountryMenu=document.querySelector(".dropdown-country");

btnCoutryDropDown.addEventListener('click', () => {
    btnCountryMenu.classList.toggle("d-block");
})
let btnLiveCoutryDropDown=document.querySelector("#dropdownLiveCountry");
let btnLiveCountryMenu=document.querySelector(".dropdown-live-country");

btnLiveCoutryDropDown.addEventListener('click', () => {
    btnLiveCountryMenu.classList.toggle("d-block");
})
