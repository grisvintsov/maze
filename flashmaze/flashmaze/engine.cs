using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashmaze
{
    class engine
    {
        public cell_type[,] mas = new cell_type[10, 10];
        public player deadpool = new player();
        public bool nextlvl;
        public void readtxt()
        {
            using (StreamReader sr = new StreamReader(@"maps\Map01.txt", System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int j = 0; line.Length - 1 >= j; j++)
                    {
                        if (line[j]== '#') mas[j,i]= new wall() {coordX=j*20,coordY=i*20};
                        //if (line[j]== '@') mas[j,i]= new ent() { coordX = j*20, coordY = i * 20 };
                        if (line[j]== ' ') mas[j,i]= new way() { coordX = j * 20, coordY = i * 20 }; 
                        if (line[j] == '%') mas[j, i] = new exit() { coordX = j * 20, coordY = i * 20 };
                        if (line[j] == '@') mas[j, i] = new dp() { coordX = j * 20, coordY = i * 20 };
                    }
                    i++;
                }
            }
            
        }

        public void gamestart()
        {
            nextlvl = false;
            readtxt();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i,j] is ent)
                    {
                        deadpool.p_coordX = mas[i, j].coordX;
                        deadpool.p_coordY = mas[i, j].coordY;
                    }
                }
            }
        }

        public void move_t()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] is dp)
                    {
                        if (mas[i, j - 1] is way)
                        {
                            way way = new way() { coordX = mas[i, j].coordX, coordY = mas[i, j].coordY };
                            mas[i, j] = way;
                            dp dp = new dp() { coordX = mas[i , j-1].coordX, coordY = mas[i, j-1].coordY };
                            mas[i, j - 1] = dp;

                        }
                        if (mas[i, j - 1] is exit)
                        {
                            nextlvl = true;
                        }

                    }

                }
                //deadpool.p_coordY = deadpool.p_coordY - 20;
            }
        }
        public void move_b()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] is dp)
                    {
                        if (mas[i, j+1] is way)
                        {
                            way way = new way() { coordX = mas[i, j].coordX, coordY = mas[i, j].coordY };
                            mas[i, j] = way;
                            dp dp = new dp() { coordX = mas[i, j+1].coordX, coordY = mas[i, j+1].coordY };
                            mas[i, j+1] = dp;
                            return;
                        }
                        if (mas[i, j + 1] is exit)
                        {
                            nextlvl = true;
                        }

                    }

                }
                //deadpool.p_coordY = deadpool.p_coordY + 20;
            }
        }
        public void move_r()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] is dp)
                    {
                        if (mas[i+1, j] is way)
                        {
                            way way = new way() { coordX = mas[i, j].coordX, coordY = mas[i, j].coordY };
                            mas[i, j] = way;
                            dp dp = new dp() { coordX = mas[i + 1, j].coordX, coordY = mas[i + 1, j].coordY };
                            mas[i+1, j] = dp;
                            return; 
                        }
                        if (mas[i+1, j] is exit)
                        {
                            nextlvl = true;
                        }

                    }

                }
            }
            //deadpool.p_coordX = deadpool.p_coordX + 20;
        }
        public void move_l()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] is dp)
                    {
                        if (mas[i - 1, j] is way)
                        {
                            way way = new way() { coordX = mas[i, j].coordX, coordY = mas[i, j].coordY };
                            mas[i, j] = way;
                            dp dp = new dp() { coordX = mas[i - 1, j].coordX, coordY = mas[i - 1, j].coordY };
                            mas[i - 1, j] = dp;

                        }
                        if (mas[i-1, j] is exit)
                        {
                            nextlvl = true;
                        }

                    }

                }
                //deadpool.p_coordX = deadpool.p_coordX - 20;
            }
        }

    }
}
