(function () {
    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");
	//HEAD
	ctx.beginPath();
    ctx.arc(100, 230, 40, 0, 2*Math.PI, false);
    ctx.fillStyle = "#90cad7";
    ctx.fill();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#1b4d58";
    ctx.stroke();
    ctx.closePath();
	
	ctx.save();
    ctx.scale(1, 0.2);
    ctx.beginPath();
    ctx.arc(100, 970, 50, 0, 2*Math.PI, false);
    ctx.fillStyle = "#396693";
    ctx.fill();
    ctx.restore();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#272523";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(1, 0.5);
    ctx.beginPath();
    ctx.arc(100, 370, 20, 0, 2*Math.PI, false);
    ctx.fillStyle = "#396693";
    ctx.fill();
    ctx.restore();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#272523";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(1, 0.5);
    ctx.beginPath();
	ctx.rect(80,300,40,70);
    ctx.fillStyle = "#396693";
	ctx.fill();
	ctx.lineWidth = 2;
	ctx.strokeStyle = "#272523";
	ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(1, 0.5);
    ctx.beginPath();
    ctx.arc(100, 300, 20, 0, 2*Math.PI, false);
    ctx.fillStyle = "#396693";
    ctx.fill();
    ctx.restore();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#272523";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(1, 0.7);
    ctx.beginPath();
    ctx.arc(80, 310, 10, 0, 2*Math.PI, false);
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#1c4d58";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(0.7, 1);
    ctx.beginPath();
    ctx.arc(108, 217, 5, 0, 2*Math.PI, false);
	ctx.fillStyle = "#1c4d58";
    ctx.fill();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(1, 0.7);
    ctx.beginPath();
    ctx.arc(120, 310, 10, 0, 2*Math.PI, false);
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#1c4d58";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.scale(0.7, 1);
    ctx.beginPath();
    ctx.arc(165, 217, 5, 0, 2*Math.PI, false);
	ctx.fillStyle = "#1c4d58";
    ctx.fill();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
    ctx.beginPath();
	ctx.moveTo(100,220);
    ctx.lineTo(85,240);
	ctx.moveTo(85,240);
    ctx.lineTo(100,240);
	ctx.strokeStyle = "#1c4d58";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	ctx.save();
	ctx.setTransform(1, 0.1, 0, 0.8, 1, 1);
	ctx.scale(1, 0.4);
    ctx.beginPath();
    ctx.arc(95, 760, 20, 0, 2*Math.PI, false);
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#1c4d58";
    ctx.stroke();
    ctx.restore();
    ctx.closePath();
	
	//BYSYCLE
	ctx.beginPath();
    ctx.arc(100, 430, 40, 0, 2*Math.PI, false);
    ctx.fillStyle = "#90cad7";
    ctx.fill();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
    ctx.arc(250, 430, 40, 0, 2*Math.PI, false);
    ctx.fillStyle = "#90cad7";
    ctx.fill();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
	ctx.moveTo(150,410);
	ctx.lineTo(190,450);
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
    ctx.arc(170, 430, 10, 0, 2*Math.PI, false);
	ctx.fillStyle = "#fff";
    ctx.fill();
    ctx.lineWidth = 2;
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
    ctx.moveTo(100,430);
	ctx.lineTo(150,370);
	ctx.moveTo(150,370);
	ctx.lineTo(240,370);
	ctx.moveTo(240,370);
	ctx.lineTo(170,430);
	ctx.moveTo(170,430);
	ctx.lineTo(100,430);
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
	ctx.moveTo(140,350);
	ctx.lineTo(170,430);
	ctx.moveTo(120,350);
	ctx.lineTo(160,350);
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
	ctx.moveTo(190,350);
	ctx.lineTo(230,330);
	ctx.moveTo(230,330);
	ctx.lineTo(260,300);
	ctx.moveTo(230,330);
	ctx.lineTo(250,430);
    ctx.strokeStyle = "#449ded";
    ctx.stroke();
    ctx.closePath();
	
	//HOUSE
	ctx.beginPath();
    ctx.moveTo(700, 50);
    ctx.lineTo(500, 200);
	ctx.lineTo(900, 200);
	ctx.lineTo(700, 50);
	ctx.fillStyle="#975b5b";
	ctx.fill();
	ctx.strokeStyle = "#000";
	ctx.lineWidth = 3;
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
    ctx.moveTo(780, 160);
    ctx.lineTo(780, 80);
	ctx.lineTo(810, 80);
	ctx.lineTo(810, 160);
	ctx.fillStyle="#975b5b";
	ctx.fill();
	ctx.strokeStyle = "#000";
	ctx.lineWidth = 3;
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
	ctx.scale(1, 0.6);
    ctx.arc(795, 130, 15, 0, 2*Math.PI, false);
	ctx.fillStyle = "#975b5b";
    ctx.fill();
    ctx.lineWidth = 3;
    ctx.strokeStyle = "#000";
    ctx.stroke();
    ctx.closePath();
	
	//WALL
	
	ctx.beginPath();
	ctx.rect(500,334,400,500);
	ctx.fillStyle="#975b5b";
	ctx.fill();
	ctx.strokeStyle = "#000";
	ctx.lineWidth = 3;
    ctx.stroke();
    ctx.closePath();
	
	//WINDOWS
	ctx.beginPath();
	
	ctx.rect(520,400,50,50);
	ctx.rect(575,400,50,50);
	ctx.rect(520,456,50,50);
	ctx.rect(575,456,50,50);
	
	ctx.rect(835,400,50,50);
	ctx.rect(780,400,50,50);
	ctx.rect(835,456,50,50);
	ctx.rect(780,456,50,50);
	
	ctx.rect(835,600,50,50);
	ctx.rect(780,600,50,50);
	ctx.rect(835,656,50,50);
	ctx.rect(780,656,50,50);
	
	ctx.fillStyle="#000";
	ctx.fill();
    ctx.stroke();
    ctx.closePath();
	
	//DOOR
	
	ctx.beginPath();
    ctx.scale(1, 0.9);
    ctx.arc(573, 760, 40, Math.PI + 0.1, Math.PI * 2 - 0.1, false);
    ctx.restore();
    ctx.moveTo(533, 755);
    ctx.lineTo(533, 925);
    ctx.moveTo(613, 755);
    ctx.lineTo(613, 925);
    ctx.moveTo(573, 720);
    ctx.lineTo(573, 925);
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
    ctx.arc(560, 830, 5, 0, 2*Math.PI, false);
    ctx.stroke();
    ctx.closePath();
	
	ctx.beginPath();
	ctx.arc(585, 830, 5, 0, 2*Math.PI, false);
	ctx.stroke();
    ctx.closePath();
	
}());