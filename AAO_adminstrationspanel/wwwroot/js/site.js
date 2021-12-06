//document.querySelectorAll('.expandRow').forEach(expandRow => {
//    expandRow.addEventListener('click', function() {
//        if (!expandRow.classList.contains('expandLess')) {
//            expandRow.classList.add('expandLess');
//            expandRow.nextElementSibling.classList.add('tableToOpenExpanded');
//        } else {
//            expandRow.classList.remove('expandLess');
//            expandRow.nextElementSibling.classList.remove('tableToOpenExpanded');
//        }
//    });
//});

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