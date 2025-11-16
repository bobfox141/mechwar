#!/usr/bin/env node

// the standard attack class. This is really simple for now, but it will grow.
// an attack is an instance in itself because it doesn't matter to the target
// what hit it. so every half turn an attack is created and destroyed.
namespace MechWar {

class Attack {

        // fields 

        private bool critical;
        private bool badmiss;   // cut yer leg off!
        private int damage;   
        private bool goodhit;  // a Good hit causes extra damaage 10% of the time
        private int damagebonus;

 
        // properties
    public bool Critical { get; set; }
    public bool Badmiss { get; set; }
        public bool Goodhit { get; set; }
        public int Damage { get; set; }
        public int DamageBonus { get; set; }



        public Attack()
        {
            this.hit = false; // when we create it there may not be a hit..
            this.critical = false;
            this.badmiss = false;
            this.damage = 0; // damage is transferred from attack to defense...
            this.damagebonus = 2;
        }

    }

}

