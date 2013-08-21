
test("test intersect", function () {
    var intersect = gf.intersect(50, 100, 150, 200);
    var i1 = Math.min(Math.max(50, 150), 100);
    var i2 = Math.max(Math.min(100, 200), 50);
    ok(intersect == [i1, i2], "Passed!");
});


test("test intersect2", function () {
    var intersect = gf.intersect(50, 100, 150, 200);
    var i1 = Math.min(Math.max(50, 150), 100);
    var i2 = Math.max(Math.min(100, 200), 50);
    ok(intersect == [i1, i2], "Passed!");
});