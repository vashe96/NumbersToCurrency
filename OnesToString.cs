using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToCurrency
{
    /*
     * Клас, який містить два методи переведення одиниць в слова 
     * (по одному для англійської та української версії)
     * з можливістю дописування аналогічних методів для інших мов
     */
    class OnesToString 
    {
        public static string OneToStringEng(string Number)
        {
            string Ones = "";
            int number = Int32.Parse(Number);

            switch (number)
            {
                case 0:
                    Ones = "";
                    break;
                case 1:
                    Ones = "one";
                    break;
                case 2:
                    Ones = "two";
                    break;
                case 3:
                    Ones = "three";
                    break;
                case 4:
                    Ones = "four";
                    break;
                case 5:
                    Ones = "five";
                    break;
                case 6:
                    Ones = "six";
                    break;
                case 7:
                    Ones = "seven";
                    break;
                case 8:
                    Ones = "eight";
                    break;
                case 9:
                    Ones = "nine";
                    break;
            }
            return Ones;
        }

        public static string OneToStringUkr(string Number)
        {
            string Ones = "";
            int number = Int32.Parse(Number);

            switch (number)
            {
                case 0:
                    Ones = "";
                    break;
                case 1:
                    Ones = "одна";
                    break;
                case 2:
                    Ones = "двi";
                    break;
                case 3:
                    Ones = "три";
                    break;
                case 4:
                    Ones = "чотири";
                    break;
                case 5:
                    Ones = "п'ять";
                    break;
                case 6:
                    Ones = "шiсть";
                    break;
                case 7:
                    Ones = "ciм";
                    break;
                case 8:
                    Ones = "вiсiм";
                    break;
                case 9:
                    Ones = "дев'ять";
                    break;
            }
            return Ones;
        }
    }
}
