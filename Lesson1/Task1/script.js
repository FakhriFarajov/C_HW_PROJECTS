
let userName = document.getElementsByTagName("input")[0];

userName.addEventListener("input", function () {
    this.value = this.value.replace(/[0-9]/g, '');
});
