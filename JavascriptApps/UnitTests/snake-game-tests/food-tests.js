module("food initialization tests");
test("foot initialization test", function(){
	var position = {x: 5, y: 10}, size = 4;
		
	var food = new snakeGame.Food(position, size);
	equal(food.position.x, position.x, "check position x correct");
	equal(food.position.y, position.y, "check position y correct");
	equal(food.size, size, "check size correct");
});