using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToCurrency
{
    class Convert
    {
        /*
         * Клас, який містить два методи дописування розрядів до результату 
         * (по одному для англійської та української версії)
         * з можливістю дописування аналогічних методів для інших мов
         */
        public static string ConvertNumberEng(string Number)
        {           
            string Result = "";
            float FltNumber = float.Parse(Number);
            
            bool isResult = false; //прапорець, який вказує, що перегляд числа завершено

            if (FltNumber > 0)
            {
                int Digits = Number.Length;
                string Group = "";
                int Pos = 0;

                string Whole = "";

                int decimalPlace = Number.IndexOf("."); // допоміжні змінні для виділення цілої частини
                if (decimalPlace > 0)
                    Whole = Number.Substring(0, decimalPlace);
                else
                    Whole = Number;

                switch (Digits) //перебираємо розряди і виконуємо допис слів розрядів
                {
                    case 1:
                        Result = OnesToString.OneToStringEng(Number);
                        isResult = true;
                        break;
                    case 2:
                        Result = TensToString.TenToStringEng(Number);
                        isResult = true;
                        break;
                    case 3:
                        Pos = (Digits % 3) + 1;                       
                        if (Whole.Length >= 3 && Number[Whole.Length - 3] == '1') // додатковий блок if-else для правильного запису чисел англійською
                            Group = " hundred ";
                        else
                            Group = " hundreds ";
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Pos = (Digits % 4) + 1;
                        if (Whole.Length >= 6 && Number[Whole.Length - 6] == '1') // додатковий блок if-else для правильного запису чисел англійською
                            Group = " thousand ";
                        else
                            
                            Group = " thousands ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        Pos = (Digits % 7) + 1;
                        if (Whole.Length >= 9 && Number[Whole.Length - 9] == '1') // додатковий блок if-else для правильного запису чисел англійською
                            Group = " million ";
                        else
                            Group = " millions ";
                        break;
                    case 10:
                    case 11:
                    case 12:
                        Pos = (Digits % 10) + 1;
                        if (Whole.Length >= 12 && Number[Whole.Length - 12] == '1') // додатковий блок if-else для правильного запису чисел англійською
                            Group = " billion ";
                        else
                            Group = " billions ";
                        break;
                    default:
                        isResult = true;
                        break;
                }
                if (!isResult) //для кожного розряду рекурсивно виконуємо допис слова розряду
                {
                    if (Number.Substring(0, Pos) != "0" && Number.Substring(Pos) != "0")
                    {
                        try
                        {
                            Result = ConvertNumberEng(Number.Substring(0, Pos)) + Group + ConvertNumberEng(Number.Substring(Pos));
                        }
                        catch
                        { }
                    }
                    else
                    {
                        Result = ConvertNumberEng(Number.Substring(0, Pos)) + ConvertNumberEng(Number.Substring(Pos));
                    }
                }
                if (Result.Trim().Equals(Group.Trim()))
                    Result = ""; 
            }
            return Result.Trim();
        }

        public static string ConvertNumberUkr(string Number)
        {
            string Result = "";
            float FltNumber = float.Parse(Number);
            bool isResult = false; //прапорець, який вказує, що перегляд числа завершено

            if (FltNumber > 0)
            {
                int Digits = Number.Length;
                string Group = "";
                int Pos = 0;
                string Whole = "";

                int decimalPlace = Number.IndexOf(","); // допоміжні змінні для виділення цілої частини
                if (decimalPlace > 0)
                    Whole = Number.Substring(0, decimalPlace);
                else
                    Whole = Number;

                    switch (Digits) //перебираємо розряди і виконуємо допис слів розрядів
                     {
                    case 1:
                        Result = OnesToString.OneToStringUkr(Number);
                        isResult = true;
                        break;
                    case 2:
                        Result = TensToString.TenToStringUkr(Number);
                        isResult = true;
                        break;
                    case 3:
                        Pos = (Digits % 3) + 1;
                        if (Whole.Length >= 3 && Number[Whole.Length - 3] == '2' || // додатковий блок if-else для правильного запису чисел українською
                            Whole.Length >= 3 && Number[Whole.Length - 3] == '3' || // Whole.Length - x визначає першу цифру порядку
                            Whole.Length >= 3 && Number[Whole.Length - 3] == '4')
                            Group = " сотнi ";
                        else if (Whole.Length >= 3 && Number[Whole.Length - 3] == '1')
                            Group = " сотня ";
                        else
                            Group = " сотень ";

                        break;
                    case 4:
                    case 5:
                    case 6:
                        Pos = (Digits % 4) + 1;
                        if (Whole.Length >= 6 && Number[Whole.Length - 6] == '2' || // додатковий блок if-else для правильного запису чисел українською
                            Whole.Length >= 6 && Number[Whole.Length - 6] == '3' ||
                            Whole.Length >= 6 && Number[Whole.Length - 6] == '4')
                            Group = " тисячi ";
                        else if (Whole.Length >= 6 && Number[Whole.Length - 6] == '1')
                            Group = " тисяча ";
                        else
                            Group = " тисяч ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        Pos = (Digits % 7) + 1;
                        if (Whole.Length >= 9 && Number[Whole.Length - 9] == '2' || // додатковий блок if-else для правильного запису чисел українською
                            Whole.Length >= 9 && Number[Whole.Length - 9] == '3' ||
                            Whole.Length >= 9 && Number[Whole.Length - 9] == '4')
                            Group = " мiльйони ";
                        else if (Whole.Length >= 9 && Number[Whole.Length - 9] == '1')
                            Group = " мiльйон ";
                        else
                            Group = " мiльйонiв ";
                        break;
                    case 10:
                    case 11:
                    case 12:
                        Pos = (Digits % 10) + 1;
                        if (Whole.Length >= 12 && Number[Whole.Length - 12] == '2' || // додатковий блок if-else для правильного запису чисел українською
                            Whole.Length >= 12 && Number[Whole.Length - 12] == '3' ||
                            Whole.Length >= 12 && Number[Whole.Length - 12] == '4')
                            Group = " мiльярди ";
                        else if (Whole.Length >= 12 && Number[Whole.Length - 12] == '1')
                            Group = " мiльярд ";
                        else
                            Group = " мiльярдiв ";
                        break;
                    default:
                        isResult = true;
                        break;
                }
                if (!isResult) //для кожного розряду рекурсивно виконуємо допис слова розряду
                {
                    if (Number.Substring(0, Pos) != "0" && Number.Substring(Pos) != "0")
                    {
                        try
                        {
                            Result = ConvertNumberUkr(Number.Substring(0, Pos)) + Group + ConvertNumberUkr(Number.Substring(Pos));
                        }
                        catch
                        { }
                    }
                    else
                    {
                        Result = ConvertNumberUkr(Number.Substring(0, Pos)) + ConvertNumberUkr(Number.Substring(Pos));
                    }
                }
                if (Result.Trim().Equals(Group.Trim()))
                    Result = "";
            }
            return Result.Trim();
        }
    }
}
