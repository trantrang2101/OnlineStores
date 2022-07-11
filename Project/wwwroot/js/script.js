window.addEventListener('DOMContentLoaded', event => {
    var price = document.querySelectorAll('.price');
    if (price) {
        price.forEach(item => { if (item.tagName != 'input') { item.innerHTML = Number.parseInt(item.innerHTML).toLocaleString() + 'đ'; } })
    }
    var prepay = document.querySelector('#prepay');
    if (prepay) {
        prepay.addEventListener('click', function () {
            if (this.checked == true) {
                document.getElementById('prepayDetail').style.display = 'block';
            } else {
                document.getElementById('prepayDetail').style.display = 'none';
            }
        })
    }
});