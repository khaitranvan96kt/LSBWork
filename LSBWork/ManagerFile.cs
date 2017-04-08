using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LSBWork
{
    class ManagerFile
    {
        public string size = null;
        public List<string> InFile(string filename_in,string size)
        {
            List<string> save_data_in = new List<string>();
            int count = 0;            
                size = (new System.IO.FileInfo(filename_in).Length).ToString();
                using (BinaryReader binaryReader = new BinaryReader(new FileStream(filename_in, FileMode.Open, FileAccess.Read)))
                {
                    //Console.WriteLine("\nsizeFileIn: " + size);
                    //Console.WriteLine(save_data_in.Count);       
                    Console.Write("\n");
                    try
                    {
                        while (true) //(data = fin.ReadByte()) !=(-1)
                        {
                            byte decimall = binaryReader.ReadByte();
                            string binary = Convert.ToString(decimall, 2).PadLeft(8, '0');
                            //Console.WriteLine(decimall);
                            save_data_in.Add(binary);
                            count++;
                        }
                    }
                    catch (IOException mess)
                    {
                        Console.WriteLine("have erro",mess.Message);
                    }         
                    
                }
                                       
                this.size = size;
            return save_data_in;
        }
        public void OutFile(string filename_out , List<string> save_data_in)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(filename_out, FileMode.Create, FileAccess.Write)))
            {
               
                foreach (string s_data in save_data_in)
                {
                    byte binary_data = (byte)Convert.ToInt32(s_data, 2);
                    binaryWriter.Write(binary_data);
                }
            }
        }
        public List<string> sizeTobinary(string size, List<string> save_data_in,int limit_size)
        {
            Console.WriteLine("sizearraylist: " + save_data_in.Count);
            List<string> tempo_save_binary = new List<string>();
            size = size.PadLeft(limit_size, '0');
            Console.WriteLine(size);
            Encoding utf8 = Encoding.UTF8;
            byte[] key = utf8.GetBytes(size);
            foreach (var child in key)
            {
                //Console.WriteLine(child);
                string binary = Convert.ToString((byte)child, 2).PadLeft(8, '0');
                tempo_save_binary.Add(binary);
               // Console.WriteLine(binary);
            }
            //save_data_in.InsertRange(0, tempo_save_binary);
            tempo_save_binary.AddRange(save_data_in);
            return tempo_save_binary;
        }
    }
}
