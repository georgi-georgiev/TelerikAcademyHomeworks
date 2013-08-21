namespace CorrectUseControlFlow
{
    using System;
    using System.Linq;

    public class Chef
    {
        public static void Main()
        {
            Bowl bowl = GetBowl();

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);
            bowl.Add(carrot);

            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {   
            //... 
        }

        private Carrot GetCarrot()
        {
            //...
        }

        private void Cut(Vegetable potato)
        {
            //...
        }  
        
        private Potato GetPotato()
        {
            //...
        }
    }
}
