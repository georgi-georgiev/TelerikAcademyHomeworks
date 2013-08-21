window.fbAsyncInit = function () {
    FB.init({
        appId: '207212666093569', // App ID
        channelUrl: '//http://localhost:50989/channel.html', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

$("#show-friends").click(function () { getFriends() });
function getFriends() {
    FB.api('/me/friends', function (response) {
        var friendsHolder = $('#firends-holder');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
            //Enlarge image
			var friendName = response.data[i].name;
			var friendImg = document.createElement("img");
			friendImg.src = friendPictureUrl;
			friendImg.title = friendName;
			friendImg.width = "100px";
			friendImg.addEventListener("mouseover", function(e){
				e.target.width = "200px";
			}, false);
			friendImg.addEventListener("mouseout", function(e){
				e.target.width = "100px";
			}, false);
			friendsHolder.append(friendname);
            friendsHolder.append(friendImg);
        }
    });
}
