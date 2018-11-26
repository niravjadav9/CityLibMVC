var strSiteURL;

function ajaxPOST(strURL, strData, callbackSuccess, strErrAlertTitle, callbackError, async) {
    if (strErrAlertTitle)
        strModuleTitleAlert = strErrAlertTitle;
    $.ajax({
        type: "POST",
        url: strURL,
        data: strData,
        cache: false,
        async: (async == undefined || async == null) ? true : async,
        dataType: 'json',
        success: callbackSuccess,
        error: callbackError,
        traditional: true
    });
}

function ajaxGet(strURL, strData, callbackSuccess, strErrAlertTitle, callbackError, showLoader) {
    if (strErrAlertTitle)
        strModuleTitleAlert = strErrAlertTitle;
    $.ajax({
        type: "GET",
        url: strURL,
        data: strData,
        cache: false,
        global: (showLoader == undefined && showLoader == null) ? true : ((showLoader != undefined && showLoader != null && showLoader) ? true : false),
        dataType: 'html',
        success: callbackSuccess,
        error: callbackError
    });
}

function WriteCookie(obj) {
    /*
     * object description. obj is array and it will contain two more objects.
     *      obj.reader {readerid: value}
     *      obj.admin { username: value, password: value}
     * */
    var cookieStatus = false;
    if (typeof obj === "undefined" && obj !== null) {
        cookieStatus = false;
    }
    if (typeof obj == "object") {

    console.log(obj);
    }
    cookievalue = JSON.stringify(obj.value) + ";";
    document.cookie = obj.name + "=" + cookievalue;
}

function ReadCookie() {
    var allcookies = document.cookie;

    // Get all the cookies pairs in an array
    cookiearray = allcookies.split(';');
    return cookiearray;
    // Now take key value pair out of this array
    //for (var i = 0; i < cookiearray.length; i++) {
    //    name = cookiearray[i].split('=')[0];
    //    value = JSON.parse(cookiearray[i].split('=')[1]);
    //    console.log("Key is : " + name + " and Value is : " + value);
    //}
}

function parseJsonDate(jsonDateString) {
    var tempDate = new Date(parseInt(jsonDateString.replace('/Date(', '')));
    var month = ["Jan", "Feb", "Mar",
        "Apr", "May", "Jun",
        "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec",];
    return tempDate.getDate() + "/" + month[tempDate.getMonth()] + "/" + tempDate.getFullYear();
}