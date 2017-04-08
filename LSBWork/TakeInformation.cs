using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSBWork
{
    class TakeInformation
    {
        ManagerFile managerfile = new ManagerFile();
        List<string> save_data_in = new List<string>();
        List<string> save_data_out = new List<string>();

        public void Start(string filename_in, string filename_out,int index_header_finish,int limit_size)
        {
            save_data_in = managerfile.InFile(filename_in, null);
            takeInforHide(index_header_finish, limit_size);
            managerfile.OutFile(filename_out, save_data_out);
        }

        private void takeInforHide(int index_header_finish,int limit_size)
        {

            int size_file_hide = getSizeFileHide(index_header_finish, limit_size);
            int vt_start_infor = index_header_finish + limit_size * 8;
            StringBuilder binary = new StringBuilder();
            for (int i= vt_start_infor; i< vt_start_infor+ size_file_hide * 8; i++)
            {
                string tempo = save_data_in[i].ToString();
                binary.Append(tempo[7]);
            }
           // StringBuilder builder = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.ToString().Substring(i, 8);
               // Console.WriteLine("section: " + section);
                save_data_out.Add(section);
            }
           

        }


        private int getSizeFileHide(int index_header_finish,int limit_size)
        {
            StringBuilder binary = new StringBuilder();
            for (int i = 0; i < limit_size * 8; i++)
            {
                string tempo = save_data_in[index_header_finish + i].ToString();
                //Console.WriteLine(tempo);
                binary.Append(tempo[7]);

            }
            Console.WriteLine(binary);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.ToString().Substring(i, 8);
                Console.WriteLine("section: " + section);
                int ascii = 0;
                try
                {
                    ascii = Convert.ToInt32(section, 2);
                }
                catch
                {
                    throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
                }
                builder.Append((char)ascii);
            }

            Console.WriteLine("size file information:" + int.Parse(builder.ToString()));
            return int.Parse(builder.ToString());
        }
    }
}
