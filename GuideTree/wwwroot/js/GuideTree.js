const software = document.querySelector("#software");
const web = document.querySelector("#web");
const mobil = document.querySelector("#mobil");
const oyun = document.querySelector("#oyun");
const robotik = document.querySelector("#robotik");
const siber = document.querySelector("#siber");
const yapayzeka = document.querySelector("#yapayzeka");
const veribilimi = document.querySelector("#veribilimi");
const warningdiv = document.querySelector("#warning-click");
software.addEventListener("click", function () {
    web.classList.add("btn-prog-second-default");
    mobil.classList.add("btn-prog-second-default");
    oyun.classList.add("btn-prog-second-default");
    robotik.classList.add("btn-prog-second-default");
    siber.classList.add("btn-prog-second-default");
    yapayzeka.classList.add("btn-prog-second-default");
    veribilimi.classList.add("btn-prog-second-default");
    warningdiv.style.display = "none";
});