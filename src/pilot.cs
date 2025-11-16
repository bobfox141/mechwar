using System;



namespace MechWar
{
    public class Pilot
    {
        private string name;
        private int skill;
        private int tough;


        public string Name { get => name; set => name = value; }
        public int Skill { get => skill; set => skill = value; }
        public int Tough { get => tough; set => tough = value; }



        public Pilot(string nm, int sk, int tg)
        {
            name = nm;
            skill = sk;
            tough = tg;

        }




    }
}