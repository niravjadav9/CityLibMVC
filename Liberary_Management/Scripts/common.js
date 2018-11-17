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