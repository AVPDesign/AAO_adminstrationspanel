var tableToOpen = document.getElementById("tableToOpen")
var expandArrow = document.querySelector(".expandArrow")
var expandMore = document.querySelector(".expandMore")
var expandLess = document.querySelector(".expandLess")

function tableOpenClose() {
    tableToOpen.style.display = "revert";
    expandArrow.classList.remove("expandMore");
    expandArrow.classList.add("expandLess");
//    if (tableToOpen.style.display = "revert") {
//        tableToOpen.style.display = "none";
//        expandArrow.classList.remove("expandLess");
//        expandArrow.classList.add("expandMore");
//    }
}