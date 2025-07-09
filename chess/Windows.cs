using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chess
{
    internal class Windows
    {
        int[] size = new int[2];
        int[] origin = new int[2];

        String name;

        public Windows(string name, int x, int y) 
        {
            size[0] = 25;
            size[1] = 10;

            origin[0] = x;
            origin[1] = y;

            this.name = name;
        }

        public void clear() 
        {
            Console.SetCursorPosition(origin[0], origin[1]);
            for (int i = 0; i < size[1]; i++)
            {
                Console.Write(new string(' ', size[0]));
                Console.SetCursorPosition(origin[0], origin[1]+i);
            }
        }
        public void write(string oth)
        {

            Console.SetCursorPosition(origin[0], origin[1]);
            Console.Write(name);

            Console.SetCursorPosition(origin[0], origin[1]+1);
            Console.Write(oth);

        }

      
    }
}
