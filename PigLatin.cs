using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PigLatinGUI
{
    public partial class PigLatin : Form
    {
        public PigLatin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pigLatinOutput.Text = convertToPigLatin(englishInput.Text);
        }

        private string convertToPigLatin(string input)
        {

            bool goodInput = true;
            StringBuilder output = new StringBuilder();
            string outputString = "";

                string[] inputWords;

                    inputWords = input.Split(' ');

                    foreach (var word in inputWords)
                    {
                        if (!Regex.IsMatch(word, @"^[\p{L}]+$"))
                        {
                            outputString = "Please enter a phrase with latin characters only";
                            goodInput = false;
                            break;
                        }
                        else
                        {
                            goodInput = true;
                        }
                    }


                if (goodInput)
                {
                    for (int i = 0; i < inputWords.Length; i++)
                    {
                        if (inputWords[i].Length <= 2)
                        {
                            output.Append(inputWords[i] + " ");
                        }
                        else if ("aeiouAEIOU,.'".IndexOf(inputWords[i][0]) >= 0)
                        {
                            output.Append(inputWords[i] + "way ");
                        }
                        else
                        {
                            if (Char.IsUpper(inputWords[i][0]))
                            {
                                output.Append(Char.ToUpper(inputWords[i][1]));
                            }
                            else
                            {
                                output.Append(inputWords[i][1]);
                            }

                            output.Append(inputWords[i].Substring(2, inputWords[i].Length - 2))
                                  .Append(Char.ToLower(inputWords[i][0]))
                                  .Append("ay ");
                        }

                    }
                    
                    outputString = output.ToString();

                }
                return outputString;
            }

        private void englishInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click((object)sender, (EventArgs)e);
            }
        }
        }
    }
