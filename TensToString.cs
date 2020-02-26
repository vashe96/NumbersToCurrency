using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToCurrency
{
    /*
     * Клас, який містить два методи переведення десятків в слова 
     * (по одному для англійської та української версії)
     * з можливістю дописування аналогічних методів для інших мов
     */
    class TensToString
    {
        public static string TenToStringEng(string Number)
        {
            string Tens = "";
            int number = Int32.Parse(Number);

            switch (number)
            {
                case 10:
                    Tens = "ten";
                    break;
                case 11:
                    Tens = "eleven";
                    break;
                case 12:
                    Tens = "twelve";
                    break;
                case 13:
                    Tens = "thirteen";
                    break;
                case 14:
                    Tens = "fourteen";
                    break;
                case 15:
                    Tens = "fifteen";
                    break;
                case 16:
                    Tens = "sixteen";
                    break;
                case 17:
                    Tens = "seventeen";
                    break;
                case 18:
                    Tens = "eighteen";
                    break;
                case 19:
                    Tens = "nineteen";
                    break;
                case 20:
                    Tens = "twenty";
                    break;
                case 30:
                    Tens = "thirty";
                    break;
                case 40:
                    Tens = "fourty";
                    break;
                case 50:
                    Tens = "fifty";
                    break;
                case 60:
                    Tens = "sixty";
                    break;
                case 70:
                    Tens = "seventy";
                    break;
                case 80:
                    Tens = "eighty";
                    break;
                case 90:
                    Tens = "ninety";
                    break;
                default:
                    if(number > 0)
                    {
                        //десятки містять одиниці, тому стрічку з результатом створюємо за допомогою 
                        //розбиття заданої стрічки на підстрічки та
                        //конкатенції результатів методу десятків до слів та методу одиниць до слів
                        
                        Tens = TenToStringEng(Number.Substring(0, 1) + "0") + " " + OnesToString.OneToStringEng(Number.Substring(1)); 
                    }
                    break;
                    
            }
            return Tens;
        }

        public static string TenToStringUkr(string Number)
        {
            string Tens = "";
            int number = Int32.Parse(Number);

            switch (number)
            {
                case 10:
                    Tens = "десять";
                    break;
                case 11:
                    Tens = "одинадцять";
                    break;
                case 12:
                    Tens = "дванадцять";
                    break;
                case 13:
                    Tens = "тринадцять";
                    break;
                case 14:
                    Tens = "чотирнадцять";
                    break;
                case 15:
                    Tens = "п'ятнадцять";
                    break;
                case 16:
                    Tens = "шiстнадцять";
                    break;
                case 17:
                    Tens = "ciмнадцять";
                    break;
                case 18:
                    Tens = "вiсiмнадцять";
                    break;
                case 19:
                    Tens = "дев'ятнадцять";
                    break;
                case 20:
                    Tens = "двадцять";
                    break;
                case 30:
                    Tens = "тридцять";
                    break;
                case 40:
                    Tens = "сорок";
                    break;
                case 50:
                    Tens = "п'ятдесят";
                    break;
                case 60:
                    Tens = "шiстдесят";
                    break;
                case 70:
                    Tens = "сiмдесят";
                    break;
                case 80:
                    Tens = "вiсiмдесят";
                    break;
                case 90:
                    Tens = "дев'яносто";
                    break;
                default:
                    if (number > 0)
                    {
                        //десятки містять одиниці, тому стрічку з результатом створюємо за допомогою 
                        //розбиття заданої стрічки на підстрічки та
                        //конкатенції результатів методу десятків до слів та методу одиниць до слів

                        Tens = TenToStringUkr(Number.Substring(0, 1) + "0") + " " + OnesToString.OneToStringUkr(Number.Substring(1));
                    }
                    break;

            }
            return Tens;
        
        }

    }
}
