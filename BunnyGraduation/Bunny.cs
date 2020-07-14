using System;

namespace BunnyGraduation.bunny {
    class Bunny {
        private string[] NAMES = { "Oreo", "Phoenix", "Mitten", "Zeus" };
        private string[] GENDERS = { "Male", "Female" };
        private string[] COLORS = { "White", "Brown", "Black", "Spotted" };

        private const int MUTANT_CHANCE = 2;

        private string name;
        private int age;
        private string gender;
        private string color;
        private Boolean mutant;

        public Bunny() {
            name = getRandomName();
            age = getRandomAge();
            gender = getRandomGender();
            color = getRandomColor();
            mutant = getRandomMutant();
        }

        public Bunny(string name, int age, string gender, string color, Boolean mutant) {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.color = color;
            this.mutant = mutant;
        }

        public string getName() {
            return name;
        }

        public int getAge() {
            return age;
        }

        public string getGender() {
            return gender;
        }

        public string getColor() {
            return color;
        }

        public Boolean isMutant() {
            return mutant;
        }

        public string getRandomName() {
            return NAMES[new Random().Next(NAMES.Length)];
        }

        public int getRandomAge() {
            return new Random().Next(11);
        }

        public string getRandomGender() {
            return GENDERS[new Random().Next(GENDERS.Length)];
        }

        public string getRandomColor() {
            return COLORS[new Random().Next(COLORS.Length)];
        }

        public Boolean getRandomMutant() {
            return MUTANT_CHANCE >= new Random().Next(1, 101);
        }

        public void setName(string name) {
            this.name = name;
        }

        public void setAge(int age) {
            this.age = age;
        }

        public void setGender(string gender) {
            this.gender = gender;
        }

        public void setColor(string color) {
            this.color = color;
        }

        public void setMutant(Boolean mutant) {
            this.mutant = mutant;
        }
    }
}
