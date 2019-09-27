﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DictionnaryGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String fileContent;
        String filePath;

        private void button1_Click(object sender, EventArgs e)
        {
            fileContent = string.Empty;
            filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    textBox2.Text = filePath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox2.Text))
                try
                {
                    var fileStream = File.OpenRead(filePath);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        toolStripStatusLabel1.Text = "Loading file";
                        //fileContent = reader.ReadToEnd();
                        //fileContent = RemoveSpecialCharacters(fileContent);
                        toolStripStatusLabel1.Text = "File loaded !";
                        String line;
                        while ((line = reader.ReadLine()) !=null ){
                            textBox1.AppendText(line);
                        }
                    }
                }
                catch
                {

                }
            else
            {
                toolStripStatusLabel1.Text = "File path not set!";
            }

        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ\n\r]+", "", RegexOptions.Compiled);
        }

        static void permute(String input)
        {
            int n = input.Length;

            // Number of permutations is 2^n 
            int max = 1 << n;

            // Converting string 
            // to lower case 
            input = input.ToLower();

            // Using all subsequences  
            // and permuting them 
            for (int i = 0; i < max; i++)
            {
                char[] combination = input.ToCharArray();

                // If j-th bit is set, we  
                // convert it to upper case 
                for (int j = 0; j < n; j++)
                {
                    if (((i >> j) & 1) == 1)
                        combination[j] = (char)(combination[j] - 32);
                }

                // Printing current combination 
                Console.Write(combination);
                Console.Write(" ");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
