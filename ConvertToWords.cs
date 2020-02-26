using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToCurrency
{    
    class ConvertToWords
    {
       /*
        * Клас, який містить два методи фіналізації рядків
        * (по одному для англійської та української версії)
        * з можливістю дописування аналогічних методів для інших мов
        */
        public static string ConvertToWordEng(string Number) // Метод, який розбиває число на ціле і дробове число,
                                                             // виконує операції над кожною частиною
                                                             // і записує в фінальну стрічку з результатом
        {
            if (Number[0] == '-')
                return "Please write positive number";
            string Value = "", Total = Number, Points = "", andStr = "", PointStr = "", Cents = "", endStr = "";

            try
            {
                bool hasDecimal = false;
                bool hasWhole = false;
                
                int decimalPlace = Number.IndexOf("."); // сепаратор для англійської мови - крапка

                if (decimalPlace > 0)
                {
                    Total = Number.Substring(0, decimalPlace);
                    if (Int32.Parse(Total) >= 1)
                        hasWhole = true;
                    Points = Number.Substring(decimalPlace + 1);

                    if (Total[Total.Length - 1] == '1') //додатковий блок для однини - множини долара
                        endStr = "dollar";                    
                    else
                        endStr = "dollars";

                    if (Int32.Parse(Points) > 0)
                    {
                        hasDecimal = true;
                        andStr = "and";
                        if (Points[1] == '1')
                            Cents = "cent";
                        else
                            Cents = "cents";
                        PointStr = ConvertDecimalsEng(Points);
                    }
                    else
                        hasDecimal = false;
                }
                else
                {
                    if (Number[Number.Length - 1] == '1') //додатковий блок для однини - множини долара
                        endStr = "dollar";
                    else
                        endStr = "dollars";
                }

                
                if (hasDecimal && hasWhole) // Різний формат результату в залежності від наявності цілої і десяткової частини
                    Value = string.Format("{0} {1} {2}{3} {4}", Convert.ConvertNumberEng(Total).Trim(), endStr, andStr, PointStr, Cents);
                else if (hasDecimal && !hasWhole)
                    Value = string.Format("{0} {1}", PointStr, Cents);
                else
                    Value = string.Format("{0} {1}", Convert.ConvertNumberEng(Total).Trim(), endStr, andStr, PointStr, Cents);
            }
            catch { }
            return Value;
        }

        public static string ConvertDecimalsEng(string number) // Допоміжний метод для конвертації дробової частини в запис центів
        {
            string Result = "", Digit = "", EngCents = "";
            Digit = number.ToString();
            EngCents = TensToString.TenToStringEng(Digit);
            Result += " " + EngCents;

            return Result;
        }

        public static string ConvertToWordUkr(string Number) // Метод, який розбиває число на ціле і дробове число,
        {                                                    // виконує операції над кожною частиною
                                                             // і записує в фінальну стрічку з результатом
            if (Number[0] == '-') 
                return "Будь ласка, введiть додатнє число";
            string Value = "", Total = Number, Points = "", andStr = "", PointStr = "", endStr = "", Cents = "";
           
            try
            {
                bool hasDecimal = false;
                bool hasWhole = false;

                int decimalPlace = Number.IndexOf(","); // сепаратор для української мови - кома                

                if (decimalPlace > 0)
                {
                    Total = Number.Substring(0, decimalPlace);
                    if (Int32.Parse(Total) >= 1)
                        hasWhole = true;
                    Points = Number.Substring(decimalPlace + 1);

                    if (Total[Total.Length - 1] == '2' || // додатковий блок if-else для правильного запису гривень
                        Total[Total.Length - 1] == '3' ||
                        Total[Total.Length - 1] == '4')
                        endStr = "гривнi";
                    else if (Total[Total.Length - 1] == '1')
                        endStr = "гривня";
                    else
                        endStr = "гривень";

                    if (Int32.Parse(Points) > 0)
                    {
                        hasDecimal = true;
                        andStr = "i";

                        if (Points[1] == '2' || Points[1] == '3' || Points[1] == '4')  // додатковий блок if-else для правильного запису копійок
                            Cents = "копiйки";
                        else if (Points[1] == '1')
                            Cents = "копiйка";
                        else
                            Cents = "копiйок";

                        PointStr = ConvertDecimalsUkr(Points);
                    }
                    else
                        hasDecimal = false;
                }

                else
                {
                    if (Number[Number.Length - 1] == '2' || // додатковий блок if-else для правильного запису гривень
                       Number[Number.Length - 1] == '3' ||
                       Number[Number.Length - 1] == '4')
                        endStr = "гривнi";
                    else if (Number[Number.Length - 1] == '1')
                        endStr = "гривня";
                    else
                        endStr = "гривень";
                }

                if (hasDecimal && hasWhole) // Різний формат результату в залежності від наявності цілої і десяткової частини
                    Value = string.Format("{0} {1} {2}{3} {4}", Convert.ConvertNumberUkr(Total).Trim(), endStr, andStr, PointStr, Cents);
                else if (hasDecimal && !hasWhole)
                    Value = string.Format("{0} {1}", PointStr, Cents);
                else
                    Value = string.Format("{0} {1}", Convert.ConvertNumberUkr(Total).Trim(), endStr, andStr, PointStr, Cents);
            }
            catch { }
            return Value;
        }

        public static string ConvertDecimalsUkr(string number) // Допоміжний метод для конвертації дробової частини в запис копійок
        {
            string Result = "", Digit = "", UkrCents = "";           
            Digit = number.ToString();
            UkrCents = TensToString.TenToStringUkr(Digit);               
            Result += " " + UkrCents;
            

            return Result;
        }
    }
}
