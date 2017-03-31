(function(d, s, id) {
    var fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    var js = d.createElement(s);
    js.id = id;
    js.src =
        "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.8&appId=@Authentication.Value.Facebook.AppId";
    fjs.parentNode.insertBefore(js, fjs);
}(document, "script", "facebook-jssdk"));