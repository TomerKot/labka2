using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchange1
{
    class exchange1
    {
        static void Main(string[] args)
        {
            double rateUSDtoUAH = 28.54;
            double rateUAHtoUSD = 0.035;

            double rateEURtoUAH = 32.26;
            double rateUAHtoEUR = 0.031;

            double rateEURtoUSD = 1.13;

            double compareSum = 0;
            string changeFromStr, changeToStr;
            string cycleCondition = "";

            Console.WriteLine("Конвертер валют\n");

            Console.Write("Введіть кількість у Вас гривень: ");
            double uahN = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть кількість у Вас доларів: ");
            double usdN = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть кількість у Вас євро: ");
            double eurN = Convert.ToDouble(Console.ReadLine());

            while (cycleCondition != "exit")
            {
                Console.Clear();

                Console.SetCursorPosition(13, 0);
                Console.WriteLine("Поточний курс валют:\n");
                Console.WriteLine($"Продати USD: {rateUSDtoUAH} UAH, "
                    + $"Купити USD: {rateUAHtoUSD} UAH\n"
                    + $"Продати EUR: {rateEURtoUAH} UAH, "
                    + $"Купити EUR: {rateUAHtoEUR} UAH\n");

                Console.SetCursorPosition(13, 4);
                Console.WriteLine($"Обміняти EUR/USD: {rateEURtoUSD}\n");
                Console.WriteLine($"У Вас {uahN} гривень, {usdN} доларів, {eurN} євро\n");

                Console.Write("Яку валюту хочете змінити?\n" +
                    "1-гривні, 2-долари, 3-євро: ");
                changeFromStr = Console.ReadLine();

                if (changeFromStr == "1")
                    compareSum = uahN;
                else if (changeFromStr == "2")
                    compareSum = usdN;
                else if (changeFromStr == "3")
                    compareSum = eurN;
                else
                    continue;

                Console.Write("Введіть суму обміну: ");
                double changeSum = Convert.ToDouble(Console.ReadLine());

                if (changeSum > compareSum || changeSum == 0)
                    continue;

                Console.Write("Яку валюту хочете отримати?\n" +
                    "1-гривні, 2-долари, 3-євро: ");
                changeToStr = Console.ReadLine();

                if (changeToStr == "1")
                {
                    if (changeFromStr == "2")
                    {
                        uahN += changeSum * rateUSDtoUAH;
                        usdN -= changeSum;
                    }
                    else if (changeFromStr == "3")
                    {
                        uahN += changeSum * rateEURtoUAH;
                        eurN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (changeToStr == "2")
                {
                    if (changeFromStr == "1")
                    {
                        usdN += changeSum / rateUAHtoUSD;
                        uahN -= changeSum;
                    }
                    else if (changeFromStr == "3")
                    {
                        usdN += changeSum * rateEURtoUSD;
                        eurN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (changeToStr == "3")
                {
                    if (changeFromStr == "1")
                    {
                        eurN += changeSum / rateUAHtoEUR;
                        uahN -= changeSum;
                    }
                    else if (changeFromStr == "2")
                    {
                        eurN += changeSum / rateEURtoUSD;
                        usdN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Обмін зроблено.\n" +
                    $"У Вас {uahN} гривні, {usdN} доларів, {eurN} євро\n");

                Console.WriteLine("Для продовження натисніть клавішу Enter,\n" +
                    "для виходу із програми введіть exit та натисніть Enter");

                cycleCondition = Console.ReadLine();
            }
        }
    }
}