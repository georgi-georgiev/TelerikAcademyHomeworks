using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(0, i));

                engine.AddObject(indBlock);
            }

            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(i, 0));

                engine.AddObject(indBlock);
            }

            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));

                engine.AddObject(indBlock);
            }

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theBall);

            //Ball theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theMeteoriteBall);

            Ball theUnsBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theUnsBall);

            UnpassableBlock theUnpasBlock = new UnpassableBlock(new MatrixCoords(WorldRows - 19, WorldCols - 21));
            engine.AddObject(theUnpasBlock);

            GiftBlock theGiftBlock = new GiftBlock(new MatrixCoords(5, 7));
            engine.AddObject(theGiftBlock);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            int sleep = 300;

            Engine gameEngine = new Engine(renderer, keyboard, sleep);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            ShootingEngine gameShootingEngine = new ShootingEngine(renderer, keyboard, 200);

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameShootingEngine.ShootRacket();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
