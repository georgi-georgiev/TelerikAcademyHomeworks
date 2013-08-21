using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingEngine : Engine
    {
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface, int sleep)
            : base(renderer, userInterface, sleep)
        {
        }

        public void ShootRacket()
        {

        }
    }
}
