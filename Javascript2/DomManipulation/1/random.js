function createButton()
{
	document.body.innerHTML="<input type='text' id='numberOfDivs' /><button onclick='getRandom()'>Click to get random div</button>";
}
function getRandom(){
	var numberOfDivs = document.getElementById("numberOfDivs").value;
	document.body.innerHTML = "";
	createButton();
	for(var i=0; i<numberOfDivs;i++)
	{
		var div = document.createElement("div");
		div.style.width = Math.floor((Math.random()*100)+20)+"px";
		div.style.height = Math.floor((Math.random()*100)+20)+"px";
		div.style.background = get_random_color();
		div.style.color = get_random_color();
		div.style.position = "absolute";
		div.style.top = Math.floor((Math.random()*70)+10)+"%";
		div.style.left = Math.floor((Math.random()*90)+1)+"%";
		div.style.borderRadius = Math.floor((Math.random()*100)+1)+"px";
		div.style.borderColor = get_random_color();
		div.style.borderWidth = Math.floor((Math.random()*20)+1)+"px";
		document.body.appendChild(div);
	}
}
function get_random_color() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++ ) {
        color += letters[Math.round(Math.random() * 15)];
    }
    return color;
}