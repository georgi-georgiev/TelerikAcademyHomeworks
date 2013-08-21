var Slime = function () {

    var attacked = false;

    this.attack = function () {
        if (!attacked) {
            attacked = true;
            setTimeout(function () {
                attacked = false;
            }, 500);

            return true;
        }

        return false;
    }

    this.init = function (div, x1, x2, anim) {
        this.div = div;
        this.x1 = x1;
        this.x2 = x2;
        this.anim = anim;
        this.direction = 1;
        this.speed = 3;
        this.dead = false;
        this.standing = false;
        this.dmg = 3;
        this.y = 0;
    };

    this.update = function () {
        if (this.dead) {
            this.dies();
        } else if (this.standing) {
            this.stand();
        }
    }

    this.kill = function () {
        this.dead = true;
    }
};
var Fly = function () { }
Fly.prototype = new Slime();

Fly.prototype.dies = function () {
    this.y= + 5;
}

Fly.prototype.init = function (div, x1, x2, anim) {

    this.div = div;
    this.x1 = x1;
    this.x2 = x2;
    this.anim = anim;
    this.direction = 1;
    this.speed = 7;
    this.dead = false;
    this.standing = false;
    this.dmg = 5;
};

var player = function () {
    this.health = 100;
    this.acceleration = 9;
    this.speed = 50;
    this.status = "jump";
    this.horizontalMove = 480;
    this.direction = "right";

    this.takeDamage = function (amount) {
        this.health -= amount;

        if (this.health < 0) {
            this.health = 0;
        }
    }

    this.heal = function (amount) {
        this.health += amount;

        if (this.health > 100) {
            this.health = 100;
        }
    }

    this.die = function () {
        return true;
    }

    this.left = function () {
        switch (status) {
            case "stand":
            case "attacked":
                status = "walk";
                horizontalMove -= 10;
                break;
            case "jump":
                horizontalMove -= 12;
                break;
            case "walk":
                horizontalMove -= 10;
                break;
        }
        this.direction = "left";
    };

    this.right = function () {
        switch (status) {
            case "stand":
            case "attacked":
                status = "walk";
                horizontalMove += 10;
                break;
            case "jump":
                horizontalMove += 12;
                break;
            case "walk":
                horizontalMove += 10;
                break;
        }
        this.direction = "right";
    };

    var doneAttack = function () {
        status = "attacked"
    }

    this.attack = function () {
        if (status != "attack") {
            status = "attack";
            return true;
        }

        return false;
    }

    this.jump = function () {
        switch (status) {
            case "stand":
            case "walk":
            case "attacked":
                status = "jump";
                speed = -60;
                break;
        }
    };

    this.idle = function () {
        switch (status) {
            case "walk":
            case "attacked":
                status = "stand";
                break;
        }
    };
};