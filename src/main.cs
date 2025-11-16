// #!/usr/bin/env node
// # file: main.js
// # the main loop for the game. this is a battle between two giant robot,
// # a player created one and a computer generated one
// # the instance determines lots of things, but mostly
// # who wins.

// lets create an attack class here.. an attack is a separate concept with its
// own attributes






public Struct<Data> loadcomputermech() {
  const fs = require("fs");
  const yaml = require("js-yaml");

  try {
    const fileContents = fs.readFileSync("computer.yaml", "utf8");
    const data = yaml.load(fileContents);
    Console.Write(data);
  } catch (e) {
    console.error(e);
  }
  return data;
}





function computermove(cmech, pmech, a) {
  process.stdout.write("function ComputerMove: Type of Attack Parameter: ");
  Console.Write(typeof a);
  a = cmech.attack(a); // calls the attack function of the mech, then returns the attack
  a = pmech.defend(a);
}

// returns true or false based on whether there is a winner or not.
// winning conditions a mech hp = 0 or it has no mobility.. i.e.
// no legs
function endofbattle(p, c) {
  return true;
}

function testrandom() {
  let numbers = [];
  Console.Write("Print out 100 random numbers. \n");
  let count = 0;
  while (count < 100) {
    count++;
    numbers.push(rollD20());
  }
}

namespace MechWar {
    class Program
    {
        static void Main(string[] args) {
            let winner = false;
            Console.Write("Welcome to MechWar, a simple mech shooting game. You load your");
            Console.Write(
              "Mech, and the computer loads it's mech and you have it out in the arena."
            );
            Console.Write(
              "A simple AI will pilot your mech, and a similar AI will pilot the computer's"
            );
            Console.Write(
              "machine. It loads your mech from your mech.yaml file and puts it against the"
            );
            Console.Write("computers computer.yaml file, generated before battle! ");
            // test the random number gen
            // testrandom();
            Console.Write();

            // load the data files

            // create the mechs and add the data
            var p = createplayermech();
            var c = createcomputermech();

            // so the idea is to repeat combat turns till someone wins.
            while (!winner) {
                Console.Write("Rolling for intialtive. Tie goes to the great sky wizard.");

                if (initiative()) {
                    Console.Write("Player has initiative and moves first.");
                    var a = new Attack();
                    playermove(p, c, a);
                    computermove(c, p, a);
                } else {
                    Console.Write("Computer has initiative and moves first.");
                    var a = new Attack();
                    computermove(c, p, a);
                    playermove(p, c, a);
                }
                winner = endofbattle();
            }
        }

    }
}
