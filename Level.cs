using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class Level
    {
        public Keys KeyPressed { get; set; }
        public string Name;
        public ICreature[,] Map { get; set; }
        public static readonly int MapWidth = 30;
        public static readonly int MapHeight = 15;
        public readonly int NumberOfCoins;
        private readonly Func<Level,ICreature[,]> init;

        public Level(string name, Func<Level,ICreature[,]> init)
        {
            this.init = init;
            Map = init(this);
            Name = name;
            NumberOfCoins = CountCoins(Map);
        }

        public static int CountCoins(ICreature[,] map)
        {
            var count = 0;
            for (var i = 0; i < Level.MapWidth; i++)
                for (var j = 0; j < Level.MapHeight; j++)
                    if (map[i, j] is Coin)
                        count++;
            return count;
        }

        public void Reset()
        {
            Map = init(this);
        }
    }
}
