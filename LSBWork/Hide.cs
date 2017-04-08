using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSBWork
{
    class Hide
    {
        private List<string> save_data_in = new List<string>();
        private List<string> save_infor_hide = new List<string>();
        ManagerFile managerfile = new ManagerFile();

        public void Start(string filename_in, string filename_out,string filename_infor_hide, int index_header_finish)
        {
            string size = null;   
            save_data_in = managerfile.InFile(filename_in,null);
            save_infor_hide = managerfile.InFile(filename_infor_hide, size);// = managerfile.InFile(filename_infor_hide,size);
            size = managerfile.size;
            //Console.WriteLine("sizearr: " + save_infor_hide.Count);
            save_infor_hide = managerfile.sizeTobinary(size, save_infor_hide, 9);
            hide(index_header_finish);
            managerfile.OutFile(filename_out, save_data_in);
            foreach(string binary in save_infor_hide)
            {
                Console.WriteLine("arraylist:" + binary);
            }
           
        }


        private void hide(int index_header_finish)
        {
            int count = index_header_finish;
            //Console.WriteLine("index_header_finish: ", index_header_finish);
            foreach (string binary in save_infor_hide)
            {
                foreach (char child in binary)
                {
                    string tempo = save_data_in[count].ToString();
                    tempo = tempo.Remove(tempo.Length - 1);
                    tempo += child;
                    save_data_in[count] = tempo;
                    count++;
                }
            }
           
        }
        
    }
}
