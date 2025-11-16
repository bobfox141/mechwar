
namespace MechWar {

class PlayerMech : Mech {

        private int pilot;  // pilot skill modifier
    private int movement;   // movement ratio
    private int attackmod;  // attack modifier
    private int defensemod; // defense modifier

    public PlayerMech(nm, hp, dam, ar, sh, pi, mr, atm, defm)
    {
        base(nm, hp, dam, ar, sh);
        pilot = pi;
        movement = mr;
        attackmod = atm;
        defensemod = defm;
  }

        public Data loadplayermech() {
            private  fs = require("fs");
            const yaml = require("js-yaml");
            try
            {
                const fileContents = fs.readFileSync("mech.yaml", "utf8");
                Data data = yaml.load(fileContents);
                Console.Write(data);
            }
            catch (e)
            {
                console.error(e);
            }
            return data;
        }

        public PlayerMech createplayermech() {
            Console.Write("Creating Player mech.");
            PlayerMech p = new PlayerMech("Rogue", 100, 20, 20, 15, 85, 1.5, 2);
            return p;
        }
    public void  playermove(pmech, cmech, a)
    {
        Console.Write("function Playermove: Type of Attack Parameter: ");
        Console.WriteLine(typeof a);
        a = pmech.attack(a);
        a = cmech.defend(a);
    }

}


}