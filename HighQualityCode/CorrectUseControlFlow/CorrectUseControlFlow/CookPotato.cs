namespace CorrectUseControlFlow
{
    using System;
    using System.Linq;

    class CookPotato
    {
        Potato potato;
        //... 
        if (potato != null)
        {
           if(!potato.HasNotBeenPeeled && !potato.IsRotten)
            {
	            Cook(potato);
            }
        }

        if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
        {
           VisitCell(x,y);
        }
    }
}
