using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSBWork
{
    class Controler
    {
       
            Hide en = new Hide();
            TakeInformation de = new TakeInformation();
           // Animation ani = new Animation();

            [STAThread]
            public void Start()
            {
                Console.WriteLine("GIAU TIN vs LAY TIN TU FILE DA GIAU = LSB(8bit)");
                Console.WriteLine("1: GIAU TIN");
                Console.WriteLine("2: LAY TIN");
                Console.Write("\nNhap: ");
                int input_value = int.Parse(Console.ReadLine());
                switch (input_value)
                {
                    case 1:
                        Console.WriteLine("Chon file can giau tin");
                        string filename_input = OpenDialog();
                        Console.Write("\nChon noi luu file da giau tin:");
                        string filename_output = SaveDialog();
                        Console.Write("\nChon file tin can giau: ");
                        string filename_info_hide = OpenDialog();
                        Console.Write("Nhap index_data_of_file: ");
                        int index= int.Parse(Console.ReadLine());                        
                        Console.Write("\nLoading ....");
                        // t1.Start();
                        en.Start(filename_input, filename_output,filename_info_hide, index);
                       // t1.Abort();

                        break;
                    case 2:
                        Console.Write("\nChon file can lay tin");
                        string filename_inputt = OpenDialog();
                        Console.Write("\nChon noi luu file tin lay ra");
                        string filename_outputt = SaveDialog();
                        Console.Write("\nNhap index_data_of_file: ");
                        int indexx = (int.Parse(Console.ReadLine()));
                        Console.Write("\nLoading ....");
                        de.Start(filename_inputt, filename_outputt,indexx,9);
                        break;
                    default:
                        Console.WriteLine("Khong dung chuc nang");
                        break;
                }
            }


        private byte[] PassToByte(string password)
        {
            // UnicodeEncoding UE = new UnicodeEncoding();
            //Encoding utf16 = Encoding.Unicode;
            Encoding utf8 = Encoding.UTF8;
            byte[] key = utf8.GetBytes(password);
            Console.WriteLine("length password: " + key.Length);
            foreach(var child in key)
            {
                Console.WriteLine(child);
            }
            return key;
        }
            private string OpenDialog()
            {
                string path = null;
                OpenFileDialog OpenDialog = new OpenFileDialog();
                OpenDialog.Filter = "All Files (*.*)|*.*";
                OpenDialog.FilterIndex = 1;
                if (OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    path = OpenDialog.InitialDirectory + OpenDialog.FileName;
                    Console.WriteLine(path);
                }
                return path;
            }
            private string SaveDialog()
            {
                string path = null;
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "All Files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveDialog.InitialDirectory + saveDialog.FileName;
                    Console.WriteLine(path);
                }
                return path;

            }
        
    }
}
