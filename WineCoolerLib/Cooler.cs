using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace WineCoolerLib
{
    public class Cooler
    {
        public int CoolerId { get; set; }

        public int CapacityOfBottles { get; set; }
        public int Temp { get; set; }
        public int BottlesInStorage  { get; set; }


        public bool CoolerIsFull()
        {
            if (BottlesInStorage < 1 || BottlesInStorage > CapacityOfBottles)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (BottlesInStorage == CapacityOfBottles)
            {
                return true;
            }

            return false;
        }
  

        public int AddWine()
        {
            if (CapacityOfBottles > BottlesInStorage)
            {
                BottlesInStorage++;
                return BottlesInStorage;
            }

            return BottlesInStorage;
        }

 
        public Cooler(int coolerId, int capacityOfBottles, int temp, int bottlesInStorage)
        {
            CoolerId = coolerId;
            CapacityOfBottles = capacityOfBottles;
            Temp = temp;
            BottlesInStorage = bottlesInStorage;   
        }

        public Cooler()
        {
                
        }

    }
}
