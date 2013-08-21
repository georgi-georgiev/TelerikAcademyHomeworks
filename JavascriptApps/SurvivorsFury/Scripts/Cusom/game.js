$(function () {

    var healthBar = $("#healthbar");

    var playerAnim = {
        stand: new gf.animation({
            url: "../../assets/player.png",
            offset: 0,
            width: 75,
            numberOfFrames: 4,
            rate: 150
        }),
        walk: new gf.animation({
            url: "../../assets/player.png",
            offset: 300,
            width: 75,
            numberOfFrames: 10,
            rate: 90
        }),
        jump: new gf.animation({
            url: "../../assets/player.png",
            offset: 1050,
            width: 75,
            numberOfFrames: 2,
            rate: 120
        }),
        attack: new gf.animation({
            url: "../../assets/player.png",
            offset: 1200,
            width: 75,
            numberOfFrames: 3,
            rate: 70
        })
    };
    var slimeAnim = {
        stand: new gf.animation({
            url: "../../assets/slime.png"
        }),
        walk: new gf.animation({
            url: "../../assets/slime.png",
            width: 43,
            numberOfFrames: 2,
            rate: 90
        }),
        dead: new gf.animation({
            url: "../../assets/slime.png",
            offset: 86
        }),

    }

    var nerezAnim = {
        stand: new gf.animation({
            url: "../../assets/nerez.png"
        }),
        walk: new gf.animation({
            url: "../../assets/nerez.png",
            width: 130,
            numberOfFrames: 3,
            rate: 40
        }),
        dead: new gf.animation({
            url: "../../assets/nerez.png",
            offset: 390
        }),

    }

    var kilikandzerAnim = {
        stand: new gf.animation({
            url: "../../assets/kilikandzer.png"
        }),
        walk: new gf.animation({
            url: "../../assets/kilikandzer.png",
            width: 130,
            numberOfFrames: 4,
            rate: 120
        }),
        dead: new gf.animation({
            url: "../../assets/kilikandzer.png",
            offset: 520
        }),

    }

    var flyAnim = {
        stand: new gf.animation({
            url: "../../assets/fly.png"
        }),
        walk: new gf.animation({
            url: "../../assets/fly.png",
            width: 69,
            numberOfFrames: 2,
            rate: 90
        }),
        dead: new gf.animation({
            url: "../../assets/fly.png",
            offset: 138
        }),

    }

    var giftAnim = {
        drop: new gf.animation({
            url: "../../assets/gift.png"
        })
    }

    var tiles = [
        new gf.animation({
            url: "../../assets/tiles.png"
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 70
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 140
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 210
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 280
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 350
        }),
        new gf.animation({
            url: "../../assets/tiles.png",
            offset: 490
        }),
    ];

    var backgroundFrontAnim = new gf.animation({
        url: "../../assets/background_front.png"
    });
    var backgroundBackAnim = new gf.animation({
        url: "../../assets/background_back.png"
    });

    var level = [[5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, ],
                 [5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, ],
                 [5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, ],
                 [5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, ],
                 [5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, ],
                 [5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, ],
                 [5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5]];

    var tilemap, container;

    var player = new (function () {
        this.health = 100;
        var acceleration = 9;
        var speed = 50;
        var status = "jump";
        var horizontalMove = 480;
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
            gf.stopGame();
        }

        this.update = function () {
            if (this.health == 0) {
                this.die();
            }
            else {
                var delta = 30;
                speed = Math.min(100, Math.max(-100, speed + acceleration * delta / 100.0));
                var newY = gf.y(this.div) + speed * delta / 100.0;
                var newX = gf.x(this.div) + horizontalMove;
                var newW = gf.width(this.div);
                var newH = gf.height(this.div);

                var collisions = gf.tilemapCollide(tilemap, { x: newX, y: newY, width: newW, height: newH });
                var i = 0;

                while (i < collisions.length > 0) {
                    var collision = collisions[i];
                    i++;
                    var collisionBox = {
                        x1: gf.x(collision),
                        y1: gf.y(collision),
                        x2: gf.x(collision) + gf.width(collision),
                        y2: gf.y(collision) + gf.height(collision)
                    };

                    var x = gf.intersect(newX, newX + newW, collisionBox.x1, collisionBox.x2);
                    var y = gf.intersect(newY, newY + newH, collisionBox.y1, collisionBox.y2);

                    var diffx = (x[0] === newX) ? x[0] - x[1] : x[1] - x[0];
                    var diffy = (y[0] === newY) ? y[0] - y[1] : y[1] - y[0];
                    if (Math.abs(diffx) > Math.abs(diffy)) {
                        // displace along the y axis
                        newY -= diffy;
                        speed = 0;
                        if (status == "jump" && diffy > 0) {
                            status = "stand";
                            gf.setAnimation(this.div, playerAnim.stand);
                        }
                    } else {
                        // displace along the x axis
                        newX -= diffx;
                    }
                    //collisions = gf.tilemapCollide(tilemap, {x: newX, y: newY, width: newW, height: newH});
                }
                gf.x(this.div, newX);
                gf.y(this.div, newY);
                horizontalMove = 0;
                this.x = newX;
            }
        };

        this.left = function () {
            switch (status) {
                case "stand":
                case "attacked":
                    gf.setAnimation(this.div, playerAnim.walk, true);
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
            gf.transform(this.div, { flipH: true });
        };

        this.right = function () {
            switch (status) {
                case "stand":
                case "attacked":
                    gf.setAnimation(this.div, playerAnim.walk, true);
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
            gf.transform(this.div, { flipH: false });
        };

        var doneAttack = function () {
            status = "attacked"
        }

        this.attack = function () {
            if (status != "attack") {
                gf.setAnimation(this.div, playerAnim.attack);
                status = "attack";
                setTimeout(doneAttack, 235);
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
                    gf.setAnimation(this.div, playerAnim.jump);
                    break;
            }
        };

        this.idle = function () {
            switch (status) {
                case "walk":
                case "attacked":
                    status = "stand";
                    gf.setAnimation(this.div, playerAnim.stand);
                    break;
            }
        };
    });

    var destroyInProgress = false;

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

            gf.transform(div, { flipH: true });
            gf.setAnimation(div, anim.walk);
        };

        this.update = function () {
            if (this.dead) {
                this.dies();
            } else if (this.standing) {
                this.stand();
            } else {
                var position = gf.x(this.div);
                if (position < this.x1) {
                    this.direction = 1;
                    gf.transform(this.div, { flipH: true });
                }
                if (position > this.x2) {
                    this.direction = -1;
                    gf.transform(this.div, { flipH: false });
                }
                gf.x(this.div, gf.x(this.div) + this.direction * this.speed);
            }
        }

        this.kill = function () {
            this.dead = true;
            gf.setAnimation(this.div, this.anim.dead);
        }

        this.dies = function () {

        }

        this.stand = function () { }
    };

    var Nerez = function () { }
    Nerez.prototype = new Slime();
    Nerez.prototype.init = function (div, x1, x2, anim) {

        this.div = div;
        this.x1 = x1;
        this.x2 = x2;
        this.anim = anim;
        this.direction = 1;
        this.speed = 12;
        this.dead = false;
        this.standing = false;
        this.dmg = 9;

        gf.transform(div, { flipH: true });
        gf.setAnimation(div, anim.walk);
    };

    var enemies = [];
    var medicKit = undefined;

    var Fly = function () { }
    Fly.prototype = new Slime();

    Fly.prototype.dies = function () {
        gf.y(this.div, gf.y(this.div) + 5);
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

        gf.transform(div, { flipH: true });
        gf.setAnimation(div, anim.walk);
    };

    var Kilikandzer = function () { };
    Kilikandzer.prototype = new Fly;
    Kilikandzer.prototype.init = function (div, x1, x2, anim) {

        this.div = div;
        this.x1 = x1;
        this.x2 = x2;
        this.anim = anim;
        this.direction = 1;
        this.speed = 15;
        this.dead = false;
        this.standing = false;
        this.dmg = 12;

        gf.transform(div, { flipH: true });
        gf.setAnimation(div, anim.walk);
    };

    //Gift
    var Gift = function () {
        this.init = function (div, y2, anim) {
            this.div = div;
            this.y2 = y2;
            this.anim = anim;
            this.speed = 1;
            gf.setAnimation(div, anim.drop);
        };

        var destroy = function () {
            medicKit = undefined;
            $("#gift").remove();
        }

        this.update = function () {
            var giftPos = gf.y(this.div);

            if (giftPos < this.y2) {
                giftPos += 5;
                $("#gift").css("top", giftPos + "px");
                gf.y(this.div, giftPos + this.speed);
            }
        }

        this.take = function () {
            player.heal(100);
            destroy();
        };
    };

    //Timer
    var Timer = function () {

        function get_elapsed_time_string(total_seconds) {
            function pretty_time_string(num) {
                return (num < 10 ? "0" : "") + num;
            }

            //var hours = Math.floor(total_seconds / 3600);
            //total_seconds = total_seconds % 3600;

            var minutes = Math.floor(total_seconds / 60);
            total_seconds = total_seconds % 60;

            var seconds = Math.floor(total_seconds);

            // Pad the minutes and seconds with leading zeros, if required
            //hours = pretty_time_string(hours);
            minutes = pretty_time_string(minutes);
            seconds = pretty_time_string(seconds);

            // Compose the string for display
            //var currentTimeString = hours + ":" + minutes + ":" + seconds;
            var currentTimeString = minutes + ":" + seconds;
            return currentTimeString;
        }

        var elapsed_seconds = 0;
        setInterval(function () {
            elapsed_seconds = elapsed_seconds + 1;
            $('#timer').text(get_elapsed_time_string(elapsed_seconds));
        }, 1000);
    };


    var initialize = function () {
        $("#mygame").append("<div id='container' style='display: none; width: 960px; height: 480px;'>");
        container = $("#container");
        backgroundBack = gf.addSprite(container, "backgroundBack", { width: 960, height: 480 });
        backgroundFront = gf.addSprite(container, "backgroundFront", { width: 960, height: 480 });
        group = gf.addGroup(container, "group");
        tilemap = gf.addTilemap(group, "level", { tileWidth: 70, tileHeight: 70, width: 42, height: 7, map: level, animations: tiles });
        player.div = gf.addSprite(group, "player", { width: 75, height: 93 });

        gf.setAnimation(player.div, playerAnim.jump);
        gf.setAnimation(backgroundBack, backgroundBackAnim);
        gf.setAnimation(backgroundFront, backgroundFrontAnim);

        $("#startButton").remove();
        container.css("display", "block");
        $("#container").append('<div id="healthbar-frame"><div id="healthbar"></div></div>');
        $("#container").append("<div id='timer' style='position: absolute; left:0; top:0;'></div>");
        $("#container").append('<div id="user-message"></div>');

        setInterval(function () {
            $("#gift").remove();
            medicKit = new Gift();
            var randomPos = Math.floor((Math.random() * 1190) + 75);
            medicKit.init(
                gf.addSprite(group, "gift", { width: 64, height: 64, x: randomPos, y: 50 }),
                362,
                giftAnim
            );
        }, 15000);

        userMessage("Shinobi survival Level 1");
        document.getElementById("level-music-" + currentTrack++).play();

        setInterval(function () {
            currentLevel++;

            if (currentLevel % 2 != 0) {
                $.each($('audio'), function () {
                    this.pause();
                });
                document.getElementById("level-music-" + currentTrack++).play();
            }

            userMessage("Level " + currentLevel + " begins now!");

            if (maxFramesCount > 25) {
                maxFramesCount -= 10;
            }

            var temp = enemies;
            enemies = [];

            var len = temp.length;

            for (var i = 0; i < len; i++) {
                $(temp[i].div).remove();
            }
        }, 30000);
    }

    var userMessage = function (message) {
        $("#user-message").append(message);

        setTimeout(function () {
            $("#user-message").html('');
        }, 4000);
    }

    var currentLevel = 1;
    var currentTrack = 1;
    var maxFramesCount = 200;
    var currenetFramesCount = 0;

    var gameLoop = function () {

        var idle = true;

        if (gf.keyboard[37]) { //left arrow
            player.left();
            idle = false;
        }

        if (gf.keyboard[38]) { //up arrow
            player.jump();
            idle = false;
        }

        if (gf.keyboard[39]) { //right arrow
            player.right();
            idle = false;
        }

        if (gf.keyboard[32]) { //space

            if (player.attack()) {
                idle = false;
                document.getElementById("sword-swing").play();

                var enemiesCount = enemies.length;
                for (var i = 0; i < enemiesCount; i++) {
                    var enemy = enemies[i];
                    if (enemy.standing) {
                        if ((player.direction == "right" && gf.x(enemy.div) > player.x)
                            || player.direction == "left" && gf.x(enemy.div) < player.x) {
                            enemy.kill();
                        }
                    }
                }
            }
        }

        if (idle) {
            player.idle();
        }

        player.update();

        if (medicKit != undefined) {
            medicKit.update();
            if (gf.spriteCollide(player.div, medicKit.div)) {
                medicKit.take();
                $("#healthbar").css("width", "" + (360 * (player.health / 100))) + "px";
            }
        }

        var enemiesCount = enemies.length;
        for (var i = 0; i < enemiesCount; i++) {
            enemies[i].update();

            if (!enemies[i].dead) {

                if (gf.spriteCollide(player.div, enemies[i].div)) {

                    var enemy = enemies[i];
                    enemy.standing = true;

                    setTimeout(function () {
                        if (!enemy.dead && enemy.attack() && enemy.standing) {
                            player.takeDamage(enemy.dmg);
                            $("#healthbar").css("width", "" + (360 * (player.health / 100))) + "px";
                            document.getElementById("get-hurt1").play();
                        }
                    }, 200);

                }
                else {
                    enemies[i].standing = false;
                }
            }
        }

        currenetFramesCount++;

        if (currenetFramesCount >= maxFramesCount) {
            currenetFramesCount = 0;

            var slimeLeft = new Slime();
            slimeLeft.init(
                gf.addSprite(group, "slime1", { width: 43, height: 28, x: 0, y: 392 }),
                70, 1190,
                slimeAnim
            );
            enemies.push(slimeLeft);

            var slimeRight = new Slime();
            slimeRight.init(
                gf.addSprite(group, "slime1", { width: 43, height: 28, x: 1260, y: 392 }),
                70, 1190,
                slimeAnim
            );
            enemies.push(slimeRight);

            if (currentLevel > 1) {
                var flyLeft = new Fly();
                var randomPos = Math.floor((Math.random() * 250) + 100);
                flyLeft.init(
                    gf.addSprite(group, "fly1", { width: 69, height: 31, x: 0, y: randomPos }),
                    70, 1190,
                    flyAnim
                );
                enemies.push(flyLeft);
            }

            if (currentLevel > 3) {
                var randomPos = Math.floor((Math.random() * 250) + 100);
                var flyRight = new Fly();
                flyRight.init(
                    gf.addSprite(group, "fly1", { width: 69, height: 31, x: 1260, y: randomPos }),
                    70, 1190,
                    flyAnim
                );
                enemies.push(flyRight);
            }

            if (currentLevel > 4) {
                var nerezLeft = new Nerez();
                nerezLeft.init(
                    gf.addSprite(group, "nerez", { width: 130, height: 100, x: 0, y: 320 }),
                    70, 1190,
                    nerezAnim
                );
                enemies.push(nerezLeft);
            }

            if (currentLevel > 5) {
                var nerezRight = new Nerez();
                nerezRight.init(
                    gf.addSprite(group, "nerez", { width: 130, height: 100, x: 1260, y: 320 }),
                    70, 1190,
                    nerezAnim
                );
                enemies.push(nerezRight);
            }

            if (currentLevel > 6) {
                var kilikandzerLeft = new Kilikandzer();
                kilikandzerLeft.init(
                    gf.addSprite(group, "kilikandzer", { width: 130, height: 100, x: 0, y: 200 }),
                    70, 1190,
                    kilikandzerAnim);
                enemies.push(kilikandzerLeft);
            }

            if (currentLevel > 7) {
                var kilikandzerRight = new Kilikandzer();
                kilikandzerRight.init(
                    gf.addSprite(group, "kilikandzer", { width: 130, height: 100, x: 1260, y: 200 }),
                    70, 1190,
                    kilikandzerAnim);
                enemies.push(kilikandzerRight);
            }
        }

        var playerPos = gf.x(player.div);

        if (playerPos > 480) {

            gf.x(group, 480 - playerPos);


            $("#backgroundFront").css("background-position", "" + ((480 * 0.66) - (playerPos * 0.66)) + "px 0px");
            $("#backgroundBack").css("background-position", "" + ((480 * 0.33) - (playerPos * 0.33)) + "px 0px");
        }
    };
    gf.addCallback(gameLoop, 30);

    $("#startButton").click(function () {
        gf.startGame(initialize);
        Timer();
    });
});