using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    public class Egg
    {
        public static Random rand = new Random();
        public int Seconds { get; set; }
        public bool Apeared { get; set; }

        public Pet Animal { get; set; }

        public Egg (Pet Animal)
        {
            this.Animal = Animal;
            Seconds = Egg.rand.Next(10, 31);
        }
    }

    public class Pet
    {
        public string Path_Egg { get; set; }
        public string Path_Pet { get; set; }
        public int AgeSeconds { get; set; }
        public int StatsSeconds { get; set; }
        public int Health { get; set; }
        public int Max_Health { get; set; }
        public int Tired { get; set; }
        public int Max_Tired { get; set; }
        public int Hunger { get; set; }
        public int Max_Hunger { get; set; }
        public int Piss { get; set; }
        public int Max_Piss { get; set; }
        public int Age { get; set; }
        public int Max_Age { get; set; }

        public Pet(int Health, int Max_Health, int Tired, int Max_Tired, 
            int Hunger, int Max_Hunger, int Piss, int Max_Piss, int Age, 
            int Max_Age, string Path_Egg, string Path_Pet)
        {
            this.Health = Health;
            this.Max_Health = Max_Health; ;
            this.Tired = Tired;
            this.Max_Tired = Max_Tired;
            this.Hunger = Hunger;
            this.Max_Hunger = Max_Hunger;
            this.Piss = Piss;
            this.Max_Piss = Max_Piss;
            this.Age = Age;
            this.Max_Age = Max_Age;
            this.Path_Egg = Path_Egg;
            this.Path_Pet = Path_Pet;
        }

        public void ChangeStats()
        {
            Hunger -= Egg.rand.Next(0, 10);
            Piss += Egg.rand.Next(0, 10);
            Tired -= Egg.rand.Next(0, 10);

            if (Hunger <= 0)
            {
                Hunger = 0;
            }

            if(Tired <= 0)
            {
                Tired = 0;
            }

            if(Piss >= Max_Piss)
            {
                Piss = Max_Piss;
            }

            Ill();
        }

        public void Eat()
        {
            Hunger += 10;
            if(Hunger >= Max_Hunger)
            {
                Hunger = Max_Hunger;
            }
        }

        public void Sleep()
        {
            Tired += 10;
            if(Tired >= Max_Tired)
            {
                Tired = Max_Tired;
            }
        }

        public void Tualet()
        {
            Piss = 0;
            if(Piss >= (Max_Piss / 2))
            {
                Ill();
            }
            if(Piss <= 0)
            {
                Piss = 0;
            }
        }

        public void Ill()
        {
            if (Hunger <= 10 || Tired <= 10 || Piss == Max_Piss - 20)
            {
                Health -= 10;
            }

            if(Health <= 0)
            {
                Health = 0;
            }

            if(Health == 0)
            {
                Kill();
            }
        }

        public void Play()
        {
            Tired -= 10;

            if(Tired <= 10)
            {
                Ill();
            }

            if(Tired <= 0)
            {
                Tired = 0;
            }

            Health += 10;

            if(Health >= Max_Health)
            {
                Health = Max_Health;
            }
        }

        public void Kill()
        {
            Health = 0;
        }

        public void Birthday()
        {
            Age += 1;
            Max_Health += 10;
            Max_Hunger += 10;
            Max_Tired += 10;
            Max_Piss += 10;

            if(Age == Max_Age)
            {
                Kill();
            }
        }

        public void UpDateTimer()
        {
            AgeSeconds = Egg.rand.Next(10, 15);
            StatsSeconds = Egg.rand.Next(3, 6);
        }
    }
}
