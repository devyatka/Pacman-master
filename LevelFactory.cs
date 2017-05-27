using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacmam;

namespace Pacman
{
    public static class LevelFactory
    {
        public static List<Level> Levels;

        static LevelFactory()
        {
            Levels = new List<Level> {GetEasyLevel(),GetMediumLevel(), GetHardLevel(), GetFatalLevel()};
        }

        private static Level GetEasyLevel()
        {
            var name = "EasyMode";
            Func<Level,ICreature[,]> mapInit = x =>{
                var map = new ICreature[Level.MapWidth, Level.MapHeight];
                for (var i = 0; i < Level.MapWidth; i++)
                    for (var j = 0; j < Level.MapHeight; j++)
                        map[i, j] = new Coin();
                for (var i = 1; i < Level.MapWidth - 1; i++)
                    map[i, 1] = new Wall();
                for (var i = 3; i < Level.MapWidth - 3; i++)
                    map[i, 3] = new Wall();
                for (var i = 5; i < Level.MapWidth - 5; i++)
                    map[i, 5] = new Wall();

                map[Level.MapWidth / 2, Level.MapHeight / 2] = new Player(x);
                map[Level.MapWidth / 2, 11] = new Monster(x);
                return map;
            };
           
            return new Level(name, mapInit);
        }

        private static Level GetMediumLevel()
        {
            var name = "SecondCourse";
            Func<Level, ICreature[,]> mapInit = x =>
            {
                var map = new ICreature[Level.MapWidth, Level.MapHeight];

                map[Level.MapWidth / 2, Level.MapHeight / 2] = new Player(x);
                map[1,10] = new Monster(x);
                map[10, 10] = new Monster(x);
                map[19, 10] = new Monster(x);
                map[28, 10] = new Monster(x);
                for (var i = 0; i < Level.MapWidth; i++)
                {
                    for (var j = 0; j < 7; j++)
                        map[i, j] = new Coin();
                    for (var j = 11; j < Level.MapHeight; j++)
                        map[i, j] = new Coin();
                }
                return map;
            };
            return new Level(name, mapInit);
        }

        private static Level GetFatalLevel()
        {
            var name = "RepkaAttacks";
            Func<Level, ICreature[,]> mapInit = x =>
            {
                var map = new ICreature[Level.MapWidth, Level.MapHeight];
                map[3, Level.MapHeight - 1] = new Player(x);
                map[0, Level.MapHeight-1] = new Monster(x);
                for (var i = 0; i < Level.MapWidth; i++)
                    map[i, 0] = new Coin();
                for (var i = 0; i < Level.MapWidth - 1; i++)
                    map[i, 1] = new Wall();
                for (var i = 0; i < Level.MapWidth - 1; i++)
                    map[i, Level.MapHeight - 2] = new Wall();
                for (var i = 1; i < Level.MapWidth; i++)
                    map[i, Level.MapHeight - 4] = new Wall();
                for (var i = 0; i < 5; i++)
                    map[i, Level.MapHeight - 6] = new Wall();
                for (var j = 8; j < 11; j++)
                    map[6, j] = new Wall();
                for (var i = 1; i < 7; i++)
                    map[i, 7] = new Wall();
                for (var i = 0; i < 9; i++)
                    map[i, 5] = new Wall();
                for (var j = 6; j < 10; j++)
                    map[8, j] = new Wall();
                for (var j = 2; j < 11; j++)
                {
                    if (j == 7)
                        continue;
                    map[10, j] = new Wall();
                }
                for(var i = 1; i < 29; i++)
                    map[i, 3] = new Wall();
                for(var j = 5; j < 10; j++)
                    map[12,j] = new Wall();
                for (var i = 13; i < 29; i++)
                {
                    map[i, 5] = new Wall();
                    map[i, 9] = new Wall();
                    map[i, 6] = new Coin();
                    map[i, 8] = new Coin();
                }
                map[13,7] = new Coin();
                map[9,2] = new Coin();
                map[11,2] = new Coin();
                map[9, 4] = new Coin();
                map[9,10] = new Coin();
                map[7,10] = new Coin();
                map[7, 6] = new Coin();
                map[0,6] = new Coin();
                map[29,14] = new Coin();

                return map;
            };
            return new Level(name, mapInit);
        }

        private static Level GetHardLevel()
        {
            var name = "Bachelor";
            Func<Level, ICreature[,]> mapInit = x =>
            {
                var map = new ICreature[Level.MapWidth, Level.MapHeight];
                map[1,1] = new Player(x);
                var randomIndex = new Random();
                for (var i = 0; i < 100; i++)
                    map[randomIndex.Next(3, Level.MapWidth - 1), randomIndex.Next(3, Level.MapHeight - 1)] = new Coin();
                for (var i = 0; i < 5; i++)
                    map[randomIndex.Next(3, Level.MapWidth-1), randomIndex.Next(3, Level.MapHeight-1)] = new Monster(x);         
                return map;
            };
            return new Level(name, mapInit);
        }
        
    }
}
