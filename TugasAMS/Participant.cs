using System;
using System.Collections.Generic;
using System.Text;

namespace TugasAMS
{
    class Participant
    {
        public string IdCodeCamp { get; set; }
        public int Nik { get; set; }
        public string Name { get; set; }

        public CodingCamp codingCamp{get; set;}

        public Participant()
        {
        }

        public Participant(int nik, string name)
        {
            Nik = nik;
            Name = name;
        }

        public Participant(int nik, string name, CodingCamp codingCamp)
        {
            Nik = nik;
            Name = name;
            this.codingCamp = codingCamp;
        }

        public Participant(string idCodeCamp, int nik, string name)
        {
            IdCodeCamp = idCodeCamp;
            Nik = nik;
            Name = name;
        }

        public void showData()
        {
            
            Console.WriteLine("\t------------------");
            Console.WriteLine($"\tNIK : {Nik}");
            Console.WriteLine($"\tNIK : {Name}");
            Console.WriteLine("\t------------------");
        }
    }
}
