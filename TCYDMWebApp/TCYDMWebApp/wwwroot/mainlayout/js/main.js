function navbarOC() {
    var x = document.getElementById("Mobile-Nav-Links");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}

let btn_register = document.querySelector("#btn-register");
let btn_login = document.querySelector("#btn-login");

let register_form = document.querySelector("#register-form");
let login_form = document.querySelector("#login-form");

if (btn_login !=null && btn_register != null){
    btn_register.addEventListener("click", (e) => {
        e.preventDefault();
        login_form.classList.remove("d-flex");
        login_form.classList.add("d-none");~
    
        register_form.classList.remove("d-none");
        register_form.classList.add("d-flex");
    
        btn_login.style.color = "#ffffff8c";
        btn_register.style.color = "#fff";
    
        btn_register.style.textDecoration = "underline";
        btn_login.style.textDecoration = "none";
    
    })
    
    btn_login.addEventListener("click", (e) => {
        e.preventDefault();
        register_form.classList.add("d-none");
        register_form.classList.remove("d-flex");
    
        login_form.classList.add("d-flex");
        login_form.classList.remove("d-none");
    
        btn_login.style.color = "#fff";
        btn_register.style.color = "#ffffff8c";
    
        btn_register.style.textDecoration = "none";
        btn_login.style.textDecoration = "underline";
    })
}

let btn_hamburger = document.querySelector(".hamburger-menu");
let icon_hamburger = document.querySelector(".hamburger-menu i");

btn_hamburger.addEventListener("click",()=>{
    icon_hamburger.classList.toggle("fa-times");
})

let btn_ourServicesMobile = document.querySelector("#btn-our-services-mobile");
let btn_ourServicesMenuMobile = document.querySelector("#our-services-menu-mobile");
let icon_ourServicesAngle = document.querySelector("#btn-our-services-mobile>i");

btn_ourServicesMobile.addEventListener("click",(e)=>{
    e.preventDefault();
    btn_ourServicesMenuMobile.classList.toggle("d-block");
    icon_ourServicesAngle.classList.toggle("fa-angle-up");
})