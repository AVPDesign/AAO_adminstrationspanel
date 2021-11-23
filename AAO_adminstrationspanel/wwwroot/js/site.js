var tableToOpen = document.getElementById("tableToOpen")
var expandArrow = document.querySelector(".expandArrow")
var expandMore = document.querySelector(".expandMore")
var expandLess = document.querySelector(".expandLess")

//function tableOpenClose() {
//    tableToOpen.style.display = "revert";
//    expandArrow.classList.remove("expandMore");
//    expandArrow.classList.add("expandLess");
//    if (tableToOpen.style.display = "revert") {
//        tableToOpen.style.display = "none";
//        expandArrow.classList.remove("expandLess");
//        expandArrow.classList.add("expandMore");
//    }
//}





const expandRows = document.querySelectorAll('.expandRow');

expandRows.forEach(expandRow => {
    expandRow.addEventListener('click', function() {
        if (!expandRow.classList.contains('expandLess')) {
            expandRow.classList.add('expandLess');
            expandRow.nextElementSibling.classList.add('tableToOpenExpanded');
        } else {
            expandRow.classList.remove('expandLess');
            expandRow.nextElementSibling.classList.remove('tableToOpenExpanded');
        }
    });
});