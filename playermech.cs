
namespace MechWar {

class PlayerMech extends Mech {
  constructor(nm, hp, dam, ar, sh, pi, mr, atm, defm) {
    super(nm, hp, dam, ar, sh);
    this.pilot = pi;
    this.movement = mr;
    this.attackmod = atm;
    this.defensemod = defm;
  }
}


}