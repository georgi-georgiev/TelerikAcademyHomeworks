using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            produceObjects.Add(new Bullet(this.topLeft, new MatrixCoords(0,1)));
            return produceObjects;
        }
    }
}
