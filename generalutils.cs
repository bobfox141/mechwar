using System;

namespace MechWar
{

	public class GeneralUtils
	{
       public int rollD20()
        {
            const randomNumber = Math.random();
            const scaledNumber = randomNumber * 20;
            const floorNumber = Math.floor(scaledNumber);
            const result = floorNumber + 1;
            return result;
        }

        public int rollD99()
        {
            const randomNumber = Math.random();
            const scaledNumber = randomNumber * 99;
            const result = Math.floor(scaledNumber);
            return result;
        }

        // this is binary initiative.
        public bool initiative()
        {
            if (rollD20() > 10)
            {
                return true;
            }
            return false;
        }



    }

}