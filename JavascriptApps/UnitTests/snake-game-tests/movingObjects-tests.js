module("movingObjects initialization tests");
test("movingObjects initialization test", function(){
	var position = {x: 5, y: 10},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 3;
		
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	equal(movingObject.position, position, "check position correct");
	equal(movingObject.size, size, "check size correct");
	equal(movingObject.fcolor, fcolor, "check fcolor correct");
	equal(movingObject.scolor, scolor, "check scolor correct");
	equal(movingObject.speed, speed, "check speed correct");
	equal(movingObject.direction, direction, "check direction correct");
});

module("movingObjects move tests");
test("movingObjects move right", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 2;
		
	var expectedPosition = {x: position.x + speed, y: position.y};
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.move();
	
	equal(movingObject.position.x, expectedPosition.x, "check moved x correct");
	equal(movingObject.position.y, expectedPosition.y, "check for same y correct");
});
test("movingObjects move left", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 0;
		
	var expectedPosition = {x: position.x - speed, y: position.y};
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.move();
	
	equal(movingObject.position.x, expectedPosition.x, "check moved x correct");
	equal(movingObject.position.y, expectedPosition.y, "check for same y correct");
});
test("movingObjects move top", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 1;
		
	var expectedPosition = {x: position.x, y: position.y - speed};
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.move();
	
	equal(movingObject.position.x, expectedPosition.x, "check for same x correct");
	equal(movingObject.position.y, expectedPosition.y, "check moved y correct");
});
test("movingObjects move bottom", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 3;
		
	var expectedPosition = {x: position.x, y: position.y + speed};
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.move();
	
	
	
	equal(movingObject.position.x, expectedPosition.x, "check for same x correct");
	equal(movingObject.position.y, expectedPosition.y, "check moved y correct");
});

module("movingObjects changeDirections tests");
test("movingObjects changeDirection from left to right", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 0;
	
	var expectedDirection = direction;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(2);
	
	equal(movingObject.direction, expectedDirection, "check for same direction correct");
});
test("movingObjects changeDirection from right to left", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 2;
	
	var expectedDirection = direction;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(0);
	
	equal(movingObject.direction, expectedDirection, "check for same direction correct");
});
test("movingObjects changeDirection from top to bottom", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 1;
	
	var expectedDirection = direction;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(3);
	
	equal(movingObject.direction, expectedDirection, "check for same direction correct");
});
test("movingObjects changeDirection from bottom to top", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 3;
	
	var expectedDirection = direction;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(1);
	
	equal(movingObject.direction, expectedDirection, "check for same direction correct");
});
test("movingObjects changeDirection from left to top", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 0;
	
	var expectedDirection = 1;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(1);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from left to bottom", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 0;
	
	var expectedDirection = 3;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(3);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from right to top", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 2;
	
	var expectedDirection = 1;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(1);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from right to bottom", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 2;
	
	var expectedDirection = 3;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(3);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from top to left", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 1;
	
	var expectedDirection = 0;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(0);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from top to right", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 1;
	
	var expectedDirection = 2;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(2);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from bottom to left", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 3;
	
	var expectedDirection = 0;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(0);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});
test("movingObjects changeDirection from bottom to right", function(){
	var position = {x: 35, y: 40},
		size = 4,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 15,
		direction = 3;
	
	var expectedDirection = 2;
	
	var movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	movingObject.changeDirection(2);
	
	equal(movingObject.direction, expectedDirection, "check changed direction correct");
});