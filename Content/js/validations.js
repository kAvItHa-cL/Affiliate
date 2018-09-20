function validateEmail(email) {
    var reg = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (reg.test(email) == false) {
        //$('#invalidInput').text("Invalid EMail Address").css("color", "blue");
        return false;

    } 
}