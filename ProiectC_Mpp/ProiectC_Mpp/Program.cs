using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using ProiectC_Mpp.model;
using ProiectC_Mpp.repository.DB;

namespace ProiectC_Mpp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            //Console.WriteLine ("Hello World!");
           // XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));

            Console.WriteLine("Sorting Participanti Repository DB ...");
            ParticipantDbRepository repo = new ParticipantDbRepository();

            Console.WriteLine("Participantii din db");
            foreach (Participant t in repo.findAll())
            {
                Console.WriteLine(t);
            }
            Participant part = repo.findOne(4);
            repo.delete(4);
            part.CapacMotor = 300;
            repo.save(part);

            Console.WriteLine("Participantii din db dupa stergere/adaugare");
            foreach (Participant t in repo.findAll())
            {
                Console.WriteLine(t);
            }

            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm); 
            
            Console.ReadLine();

        }
    }
}
