function navbarOC() {
    var x = document.getElementById("Mobile-Nav-Links");
    if (x.style.display === "block") {
      x.style.display = "none";
    } else {
      x.style.display = "block";
    }
  }

queueBtn = document.querySelector(".online-btn");

queueBtn.addEventListener("click",()=>{
  window.location.replace("online-turn.html")
})

