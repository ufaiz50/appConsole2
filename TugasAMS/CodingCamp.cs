using System;
using System.Collections.Generic;
using System.Text;

namespace TugasAMS
{
    class CodingCamp
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Participant> Participants { get; set; }
        
        public CodingCamp()
        {
        }

        public CodingCamp(string id, string name)
        {
            Id = id;
            Name = name;
            Participants = new List<Participant>();
        }

        public void showData()
        {
            
            Console.WriteLine($"ID   : {Id}");
            Console.WriteLine($"Name : {Name}");
            foreach (var p in Participants)
            {
                Console.WriteLine( "\t------------");
                Console.WriteLine($"\tNIK : {p.Nik}");
                Console.WriteLine($"\tNIK : {p.Name}");
                Console.WriteLine( "\t-------------");
            }
            
        }
    }
}
