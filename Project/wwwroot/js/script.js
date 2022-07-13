var labels = document.getElementsByTagName('LABEL');
function findLableForControl(el) {
    for (var i = 0; i < labels.length; i++) {
        if (labels[i].htmlFor != '') {
            if (labels[i].htmlFor == el) {
                return labels[i];
            }
        }
    }
    return null;
}
window.addEventListener('DOMContentLoaded', event => {
    var price = document.querySelectorAll('.price');
    if (price) {
        price.forEach(item => { if (item.tagName != 'input') { item.innerHTML = Number.parseInt(item.innerHTML).toLocaleString() + 'đ'; } })
    }
});
function showForm() {
    if (document.getElementById('takeAway').checked) {
        document.getElementById('shipForm').style.display = 'none';
    } else {
        console.log(document.getElementById('takeAway'));
        document.getElementById('shipForm').style.display = 'block';
    }
}
function changeStatus(id, trueValue, falseValue) {
    var label = findLableForControl(id);
    if (document.getElementById(id) && document.getElementById(id).tagName.toLowerCase() == 'input' && document.getElementById(id).type.toLowerCase() == 'checkbox') {
        if (document.getElementById(id).checked) {
            label.innerHTML = trueValue;
        } else {
            label.innerHTML = falseValue;
        }
    }
}