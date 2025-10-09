// file: computermech.cs


class ComputerMech extends Mech {
  constructor(nm, hp, dam, ar, sh, pi, rr, atm, defm) {
    super(nm, hp, dam, ar, sh);
    this.pilot = pi;
    this.responserate = rr;
    this.attackmod = atm;
    this.defensemod = defm;
  }
}
