// TableToOpen
document.querySelectorAll('.expandRow').forEach(expandRow => {
    expandRow.addEventListener('click', function () {
        if (!expandRow.classList.contains('expandLess')) {
            expandRow.classList.add('expandLess');
            expandRow.nextElementSibling.classList.add('tableToOpenExpanded');
        } else {
            expandRow.classList.remove('expandLess');
            expandRow.nextElementSibling.classList.remove('tableToOpenExpanded');
        }
    });
});

// DateTime substring(s)

let startDate = document.querySelectorAll('.startDate');
let endDate = document.querySelectorAll('.endDate');
let startTime = document.querySelectorAll('.startTime');

startDate.forEach((element) => {
    element.innerHTML = element.innerHTML.substring(0, 10);
});

endDate.forEach((element) => {
    element.innerHTML = element.innerHTML.substring(0, 10);
});

startTime.forEach((element) => {
    element.innerHTML = element.innerHTML.substring(11, 16);
});