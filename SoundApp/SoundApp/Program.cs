using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.IO;

namespace SoundApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            bool continueC = true;

            Thread thread = new Thread(new ThreadStart(BackgroundSound));

            thread.IsBackground = true;

            thread.Start();

			using (StreamWriter stream = new StreamWriter("KakYgodno.txt"))
			{
				stream.Write("asdasdasdsdds");
			}

			Console.WriteLine("Введите все что угодно(если хотите закончить то введите в новой строке \"exit\" и нажмите Enter):");

            while (continueC)
            {
				string lastWord = Console.ReadLine();				
				if (lastWord == "exit")
                {
                    continueC = false;
                }
				else
					text += lastWord;				
            }

			SaveFile(text);

			Console.Read();
        }

        private static void BackgroundSound()
        {
            var soundPlayer = new SoundPlayer("ScarboroughFair.wav");
            soundPlayer.Play();            
        }

        private static void SaveFile(string str)
        {
            using (StreamWriter stream = new StreamWriter("KakYgodno.txt",true, System.Text.Encoding.Default))
            {
                stream.WriteLine (str);       				
            }
        }
    }
}
