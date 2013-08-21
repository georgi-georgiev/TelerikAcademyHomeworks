function validate(field)
{
	var errorList="";
	if (document.getElementById("number").value === "" || document.getElementById("number").value === null) {
        errorList += 'You have to enter number<br />';
    }
    if(document.getElementById("sign").value === "" || document.getElementById("sign").value === null){
	    errorList += 'You have to enter sign<br />';
	}
    if (document.getElementById("anotherNumber").value === "" || document.getElementById("anotherNumber").value === null) {
        errorList += 'You have to enter anotherNumber<br />';
    }
    if (errorList) {
        document.getElementById(field).innerHTML = errorList;
        return false;
    }
    return true;
}
