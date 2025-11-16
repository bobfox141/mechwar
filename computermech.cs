// file: computermech.cs
// author: sgarbeil

namespace MechWar
{ 

    class ComputerMech : Mech
    {
            private int pilot;
        private int responserate;
        private int attackmod;
        private int defensemod;

      public ComputerMech(nm, hp, dam, ar, sh, pi, rr, atm, defm)
      {
            base(nm, hp, dam, ar, sh);
        pilot = pi;
        responserate = rr;
        attackmod = atm;
        defensemod = defm;
      }

        // simple create mech from scratch
        public ComputerMech createcomputermech()
        {
        Console.Write("Creating AI mech.");
        ComputerMech c = new ComputerMech("Timberwolf", 100, 20, 20, 15, 85, 2, 1.5);
        return c;
        }
}
}
