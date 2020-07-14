using BunnyGraduation.bunny;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyGraduation {
    class Colony {
        private const int ADULT_AGE = 2;
        private const int OLD_AGE = 11;
        private const int MUTANT_OLD_AGE = 50;

        private List<Bunny> colony;

        public Colony() {
            colony = new List<Bunny>();
        }

        public Colony(List<Bunny> colony) {
            this.colony = colony;
        }

        public void killOld() {
            for(int i = 0; i < colony.Count; i++) {
                Bunny bunny = colony[i];

                if (!bunny.isMutant() && bunny.getAge() >= OLD_AGE || bunny.isMutant() && bunny.getAge() >= MUTANT_OLD_AGE) {
                    removeBunny(bunny);

                    if(i != 0) {
                        i--;
                    }
                }
            }
        }

        public void breed() {
            List<Bunny> male = new List<Bunny>();
            List<Bunny> female = new List<Bunny>();

            foreach (Bunny bunny in colony) {
                if (!bunny.isMutant()) {
                    if (bunny.getAge() >= ADULT_AGE && bunny.getGender() == "Male") {
                        male.Add(bunny);
                    } else if (bunny.getAge() >= ADULT_AGE && bunny.getGender() == "Female") {
                        female.Add(bunny);
                    }
                }
            }

            for (int i = 0; i < male.Count; i++) {
                for (int j = 0; j < female.Count; j++) {
                    addBunny(createChild(female[j]));
                }
            }
        }

        public void infect() {
            List<Bunny> mutant = new List<Bunny>();

            foreach(Bunny bunny in colony) {
                if (bunny.isMutant()) {
                    mutant.Add(bunny);
                }
            }

            for(int i = 0; i < mutant.Count; i++) {
                foreach(Bunny bunny in colony) {
                    if (!bunny.isMutant()) {
                        Console.WriteLine("Bunny " + bunny.getName() + " was infected!");
                        bunny.setMutant(true);
                    }
                }
            }
        }

        public void incrementAge() {
            foreach(Bunny bunny in colony) {
                bunny.setAge(bunny.getAge() + 1);
            }
        }

        public Boolean isOver() {
            int mutantCount = 0;

            foreach(Bunny bunny in colony)
                if (bunny.isMutant())
                    mutantCount++;

            int maleCount = 0;
            int femaleCount = 0;

            foreach (Bunny bunny in colony) {
                if(bunny.getGender() == "Male") {
                    maleCount++;
                } else if(bunny.getGender() == "Female") {
                    femaleCount++;
                }
            }

            return mutantCount == colony.Count || maleCount == colony.Count || femaleCount == colony.Count;
        }

        public void addBunny(Bunny bunny) {
            if (bunny.isMutant()) {
                Console.WriteLine("Radioactive Mutant Vampire Bunny " + bunny.getName() + " was born!");
            } else {
                Console.WriteLine("Bunny " + bunny.getName() + " was born!");
            }

            colony.Add(bunny);
        }

        public void removeBunny(Bunny bunny) {
            if (colony.Contains(bunny)) {
                if (bunny.isMutant()) {
                    Console.WriteLine("Radioactive Mutant Vampire Bunny " + bunny.getName() + " died!");
                } else {
                    Console.WriteLine("Bunny " + bunny.getName() + " died!");
                }

                colony.Remove(bunny);
            }
        }

        public List<Bunny> getColony() {
            return colony;
        }

        private Bunny createChild(Bunny mother) {
            Bunny bunny = new Bunny();
            bunny.setAge(0);
            bunny.setColor(mother.getColor());
            return bunny;
        }
    }
}
