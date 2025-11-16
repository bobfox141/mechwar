#!/

namespace MechWar
{

    class Mech
    {

        private string name;
        private int hitpoints;
        private int damage; // this is the base damage range [1.. dam]
        private int armor;
        private int pilot; // pilot skill factor 
        private int shields;
        private bool eject;
        private bool head;
        private bool arm;
        private bool reactor;
        private bool torso;
        private bool leg;
        private bool mobility;
        private bool attacks;
        private bool shutdown;

        public string Name { get => name; set => name = value; }
        public int Hitpoints { get => hitpoints; set => hitpoints = value; }




        // creates the base Mecha, with good systems and supplied values
        public Mech(nm, hp, dam, ar, sh, pi)
        {
            name = nm;
            hitpoints = hp;
            damage = dam; // this is the base damage range [1.. dam]
            armor = ar;
            shields = sh;
            eject = true;
            head = true;
            arm = true;
            reactor = true;
            torso = true;
            leg = true;
            pilot = pi; // pilot skill factor
            mobility = true;
            attacks = true;
            shutdown = false;
        }


        // basic to hit calculation
        public Attack attack(Attack a)
        {
            process.stdout.write("Type of Attack Parameter: ");
            console.log(typeof a);
            let roll = this.rollD20();
            // attack tree.
            a.critical = false; // this is supposed to set the critical property to
            a.badmiss = false;
            a.damage = 0;
            a.damagebonus = 2;
            a.hit = false; // start out false

            if (roll > 18)
            {
                process.stdout.write(
                  "Critical Hit! Double damage plus possible penetration effects Calculating.... "
                );
                a.critical = true;
                a.badmiss = false;
                a.hit = true;
                a.damage = this.damage * a.damagebonus; // critical hit, max damage + critical bonus
            }
            else if (roll > 10)
            {
                // direct hit full damage * pilot skill
                process.stdout.write("Direct Hit! Calculating damage... ");
                a.critical = false;
                a.badmiss = false;
                a.hit = true;
                a.damage = this.damage + (this.damage * this.pilot) / 100.0;
            }
            else if (roll > 7)
            {
                // glancing hit affected by skill of pilot
                process.stdout.write(
                  "Hit. Lesser Damage reduced by spreading over the area... "
                );
                a.critical = false;
                a.badmiss = false;
                a.damage = this.damage + (this.damage * this.pilot) / 200.0;
                a.hit = true;
            }
            else if (roll > 2)
            {
                // complete miss
                console.log("Miss. No damage, no energy transferred.");
                a.critical = false;
                a.badmiss = false;
                a.damage = 0;
                a.hit = false;
                return false;
            }
            else
            {
                console.log("Bad Miss.");
                a.critical = false;
                a.badmiss = true;
                a.damage = this.damage + (this.damage * this.pilot) / 200.0; // bad miss damage is reflected on the firing mech.
            }
            return a;
        }

        // defend routine
        pubic Attack defend(Attack a)
        {
            let critical = a.critcal;
            let badmiss = a.badmiss;
            let damage = a.damage;
            let damagebonus = a.damagebonus;
            let hit = a.hit;
            let roll = this.rollD20();
            // if there is damage
            if (damage > 0)
            {
                console.log("Attack hits, damage applied, rolling to defend...");
                if (roll > 18)
                {
                    if (critical)
                    {
                        console.log(
                          "Critical Defend, Critical Attack blocked, normal damage applies."
                        );
                        this.hp -= damage;

                        let systemroll = rollD20();
                        if (systemroll == 0)
                        {
                            console.log(
                              "Direct hit to reactor. Your mech shutdown, all lifesupport is down."
                            );
                            if (this.eject)
                            {
                                console.log("Ejecting!!!");
                            }
                            else
                            {
                                console.log(
                                  "Ejection failed, lifesupport failed, emergency beacon activated."
                                );
                            }
                            this.reactor = false;
                            this.shutdown = true;
                            this.hp = 0;
                            return true; // special case mech is done.
                        }
                        else if (systemroll > 15)
                        {
                            this.head = false;
                            this.hp -= damage + 0.2 * this.hp;
                        }
                        else if (systemroll > 10)
                        {
                            this.arm = false;
                            this.hp -= damage + 0.2 * this.hp;
                        }
                        else if (systemroll > 5)
                        {
                            this.leg = false;
                            this.hp -= damage + 0.2 * this.hp;
                        }
                        else if (systemroll > 0)
                        {
                            this.torso = false;
                            this.hp -= damage + 0.3 * this.hp;
                        }
                    }
                    else
                    {
                        console.log("Critical Defend, all damage blocked!");
                        damage = 0;
                    }
                    if (this.hp < 1)
                    {
                        console.log("Defender systems shutdown, status critical, ejecting!");
                        this.shutdown = true;
                    }
                    return true;
                }
                else if (roll > 10)
                {
                    console.log("Skilled Defender. Damage reduced by skill.");
                    damage = (damage * this.pilot) / 100.0; //
                    this.hp -= damage;
                }
                else if (roll > 7)
                {
                    console.log("Defense negates a portion of the damage.");
                    damage = (damage * this.pilot) / 200.0; //
                    this.hp -= damage;
                }
                else if (roll > 2)
                {
                    this.hp -= damage;
                }
                else
                {
                    console.log("Bad Defend. Attack damage is multiplied by 1.5");
                    damage = damage * 1.5;
                    this.hp -= damage;
                }
            }
            return a;
        }
    }

}