using System;
using System.Collections.Generic;
using System.Threading;

namespace TugasAMS
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            CodingCamp codingCamp49 = new CodingCamp("MCC-REG-49-NET", "Coding Camp 49");
            Participant participants1 = new Participant(123, "Asiap", codingCamp49);

            codingCamp49.Participants.Add(participants1);

            //List Object Partisipan
            List<Participant> participants = new List<Participant>();
            participants.Add(new Participant("MCC-REG-49-NET", 123, "Asiap"));

            //Membuat list of Object CodingCamp
            List<CodingCamp> codingCamps = new List<CodingCamp>();
            codingCamps.Add(new CodingCamp("MCC-REG-49-NET", "Coding Camp 49"));
            codingCamps.Add(codingCamp49);

            
            // Membuat Declarasi dan Assigment Variabel
            bool isRun = false;
            int option;

            //Melakukan looping secara tersu menerus di aplikasi
            while (!isRun)
            {
                Dashboard();
                option = GetOption();
                switch (option)
                {
                    case 1:
                        AddCodingCamp(codingCamps);
                        break;
                    case 2:
                        DeleteCodingCamp(codingCamps);
                        break;
                    case 3:
                        ShowData(codingCamps);
                        Console.ReadKey();
                        break;
                    case 4:
                        Addparticipant(codingCamps);
                        break;
                    case 5:
                        DeleteParticipant(codingCamps);
                        break;

                }
                

                Console.Clear();

            }

            Console.ReadLine();
        }

        //Menambahkan object codingcamp
        static void AddCodingCamp(List<CodingCamp> codingCamps)
        {
            Console.Write("Masukan ID : ");
            string id = Console.ReadLine();
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();
            codingCamps.Add(new CodingCamp(id, name));

            Console.WriteLine("====> data berhasil ditambahkan <====");
            Console.ReadKey();
        }

        //Menghapus data object codingcamp berdasarkan no yang di inputkan
        static void DeleteCodingCamp(List<CodingCamp> codingCamps)
        {
            int no = 1;
            foreach (var code in codingCamps)
            {
                Console.WriteLine($"No. {no}");
                Console.WriteLine($" ID : {code.Id}");
                Console.WriteLine($" Name : {code.Name}");
                no++;
            }

            Console.WriteLine("Pilih Nomer yang ingin dihapus : ");
            try
            {
                int option = GetOption();

                codingCamps.RemoveAt(option - 1);
                Console.WriteLine("===> Data Berhasil dihapus <===");
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Dashboard();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("===> Maaf Daata tidak ada <===");

                Console.WriteLine();
                DeleteCodingCamp(codingCamps);
            }
        }

        //Menampilkan data coding camp beserta dengan peserta
        static void ShowData(List<CodingCamp> codingCamp)
        {
            
            Console.WriteLine();
            Console.WriteLine("===> List Coding Camp <===");

            foreach (var code in codingCamp)
            {
                code.showData();
                if(code.Participants.Count <= 0)
                {
                    Console.WriteLine("\t-------------------");
                    Console.WriteLine("\tBelum Ada Partcipan");
                    Console.WriteLine("\t-------------------");
                }
                Console.WriteLine();
            }
        }

        //Menambahkan participan dengan mengambil/memilih id codingcamp
        static void Addparticipant(List<CodingCamp> codingCamp)
        {
            int no = 1;
            foreach (var code in codingCamp)
            {
                Console.WriteLine($"No. {no}");
                Console.WriteLine($" ID : {code.Id}");
                Console.WriteLine($" ID : {code.Name}");
                no++;
            }
            try
            {
                Console.WriteLine();
                Console.Write("Pilih Kelas : ");
                int option = Convert.ToInt32(Console.ReadLine());
           
                
                var coba = codingCamp.ToArray();
                string idKelas = coba[option - 1].Id;
            
             
                Console.Write("Masukan Nik : ");
                try
                {
                    int nik = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukan Nama : ");
                    string name = Console.ReadLine();
                    Participant addParticipant = new Participant(nik, name, codingCamp[option-1]);
                    codingCamp[option - 1].Participants.Add(addParticipant);

                    Console.WriteLine();
                    Console.WriteLine("===> Data Partisipan Sudah di tambahkan");
                    Console.ReadKey();
                }
                catch(FormatException  )
                {
                    Console.Clear();
                    Dashboard();
                    Console.WriteLine();
                    Console.WriteLine("===> Maaf Anda Memasukkan Format yang salah <====");
                    Console.WriteLine("===> Gunakan Angka Untuk Form Input NIK");
                    Addparticipant(codingCamp);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Dashboard();
                Console.WriteLine();
                Console.WriteLine("===> Maaf data yang anda pilih tidak ada <====");
                Addparticipant(codingCamp);
            }
        }

        //Menghapus data partsipan pada codingcamp
        static void DeleteParticipant(List<CodingCamp> codingCamp)
        {
            int no = 1;
            int nop = 1;
            try
            {
                Console.WriteLine();
                foreach (var code in codingCamp)
                {
                    Console.WriteLine($" No. {no}");
                    Console.WriteLine($" ID : {code.Id}");
                    Console.WriteLine($" Name : {code.Name}");
                    no++;
                    foreach (var item in code.Participants)
                    {
                        Console.WriteLine("\t-------------------");
                        Console.WriteLine($"\tNo. {nop}");
                        Console.WriteLine($"\tNIK : {item.Nik}");
                        Console.WriteLine($"\tName : {item.Name}");
                        Console.WriteLine("\t-------------------");
                        nop++;
                    }
                    if (code.Participants.Count <=0)
                    {
                        Console.WriteLine("\t-------------------");
                        Console.WriteLine("\tBelum Ada Partcipan");
                        Console.WriteLine("\t-------------------");
                    }
                    nop = 1;
                }

                Console.Write("Pilih Kelas dari Participant : ");
                int codeClass = Convert.ToInt32(Console.ReadLine());
                Console.Write("Pilih No Data Participan : ");
                int noP = Convert.ToInt32(Console.ReadLine());

                codingCamp[codeClass - 1].Participants.RemoveAt(noP - 1);

                Console.WriteLine("===> Data Partisipan Berhasil Dihapus <===");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Clear();
                Dashboard();
                Console.WriteLine();
                Console.WriteLine("===> Format yang anda masukkan salah atau Data tidak ada <===");
                DeleteParticipant(codingCamp);
            }
            
        }

        //mendapat opsi dari user
        static int GetOption()
        {
               
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }catch(FormatException)
            {
                Console.WriteLine("Hanya Boleh Menginputkan Angka");
                Thread.Sleep(2000);
                Console.Clear();
                Dashboard();
                return GetOption();
                
            }
        }

        //Menampilkan dasboard apps
        static void Dashboard()
        {
            Console.WriteLine("===> Menu <===");
            Console.WriteLine("1. Add Coding Camp");
            Console.WriteLine("2. Delete Coding Camp");
            Console.WriteLine("3. Show Coding Camp");
            Console.WriteLine("4. Add Participant");
            Console.WriteLine("5. Delete Participant");
            Console.WriteLine();
            Console.Write("Option (1 - 5): ");
            
        }
    }
}
