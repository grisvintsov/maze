using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashmaze
{
    public class cell_type
    {
        public int coordX { get; set; }
        public int coordY { get; set; }
    }
    class ent : cell_type
    {
        int c_ent = 1;  //@ 
    }
    class way : cell_type
    {
        int c_way = 2;  //namespace
    }
    class wall : cell_type
    {
        int c_wall = 3; //#
    }
    class exit : cell_type
    {
        int c_exit = 4; //%
    }
    class dp : cell_type
    {
        int c_dead = 4; //%
    }
}
