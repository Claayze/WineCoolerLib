using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineCoolerLib;

namespace RestWineCooler.Manager
{
    public class WineCoolersManager
    {
        private static List<Cooler> coolerlist = new List<Cooler>()
        {
            new Cooler(1, 100, 4, 40),
            new Cooler(2, 200, 8, 132),
            new Cooler(3, 50, 2, 5),
            new Cooler(4, 100, 15, 20)
        };

        public List<Cooler> GetAllCoolers()
        {
            return coolerlist;
        }

        public Cooler GetCooler(int id)
        {
            return coolerlist.Find(i => i.CoolerId == id);
        }

        public bool AddCooler(Cooler cooler)
        {
            if (cooler == null)
            {
                return false;
            }
            coolerlist.Add(cooler);
            return true;
        }

        public bool Delete(int id)
        {
            var delete = coolerlist.Find(x => x.CoolerId == id);
            if (delete == null)
            {
                return false;
            }

            coolerlist.Remove(delete);
            return true;
        }
    }
}
