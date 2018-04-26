using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryToText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (PathBox.Text.Length > 1)
            {
                string path = string.Format(@"{0}", PathBox.Text);
                string[] parts = path.Split('\\');
                int software_index = -1;

                for (int p = 0; p < parts.Length; p++)
                {
                    if (parts[p] == "SOFTWARE")
                    {
                        software_index = p;
                        break; 
                    }
                }                

                if (software_index == -1)
                {
                    MessageBox.Show("Invalid Path.");
                    return;
                }

                string p_str = "";
                string[] u_path_parts = parts.Skip(software_index + 1).Take(parts.Length - software_index).ToArray();
                foreach (string p in u_path_parts)
                {
                    p_str += string.Format("\\{0}", p);
                }
                
                path = string.Format(@"SOFTWARE{0}", p_str);

                RegistryReadResult value_results = GetSoftwareRegistryValue(path);
                
                if (value_results != null)
                {
                    WriteValuesToFile(value_results);
                }
            }
            else
            {
                MessageBox.Show("No path entered."); 
            }
            
        }

        private RegistryReadResult GetSoftwareRegistryValue(string path)
        {            

            Registry.LocalMachine.OpenSubKey("SOFTWARE");
            RegistryKey mKey; 

            try
            {                
                mKey = Registry.LocalMachine.OpenSubKey(path, false);                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid registry path");
                return null;
            }

            if (mKey != null)
            {
                string[] key_names = mKey.GetValueNames();
                string[] values = new string[key_names.Length];                
                
                for (int k = 0; k < key_names.Length; k++)
                {
                    object value = mKey.GetValue(key_names[k]);
                    string value_str = value.ToString();
                    Console.WriteLine("Getting value for " + key_names[k] + ", value is: " + value_str);
                    values[k] = value_str;
                }

                Console.WriteLine("Path: " + path); 
                RegistryReadResult result = new RegistryReadResult(path, key_names, values);
                return result; 
            }
            else
            {
                Console.WriteLine("Mkey was null. Path: " + path);
                MessageBox.Show("No values found.");
                return null;
            }        
        }

        private void WriteValuesToFile(RegistryReadResult result)
        {
            string[] lines = new string[result.values.Length];            
            for (int l = 0; l < lines.Length; l++)
            {                
                lines[l] = string.Format("Key: {0} ---> Value: {1}", result.keys[l], result.values[1]);
            }
            
            string dir = System.IO.Directory.GetCurrentDirectory();
            string filename = "reg_values.txt";
            string out_file_path = dir + "\\" + filename;
            System.IO.File.WriteAllLines(out_file_path, lines);            

            OpenNotePadToRegFile(out_file_path);
        }       

        private void OpenNotePadToRegFile(string out_file_path)
        {
            System.Diagnostics.Process.Start("notepad.exe", out_file_path);
        }
    }
   
    public class RegistryReadResult
    {
        public string path = "";
        public string[] keys = null;
        public string[] values = null;

        public RegistryReadResult(string path, string[] keys, string[] values)
        {
            this.path = path;
            this.keys = keys;
            this.values = values; 
        }
    }
}
