using Newtonsoft.Json;
using System;
using System.Net;

namespace ConsoleApp1
{
    class ekidata_TEST
    {
        static void Main(string[] args)
        {
            Console.Write("都道府県コードを入力してください:");
            var code = int.Parse(Console.ReadLine());
            todofuken.pro1(code);
            Console.WriteLine();

            Console.Write("路線コードを入力してください:");
            var code1 = int.Parse(Console.ReadLine());
            rosen.pro2(code1);
            Console.WriteLine();

            Console.Write("駅コードを入力してください:");
            var code2 = int.Parse(Console.ReadLine());
            station.pro3(code2);
            Console.WriteLine();
        }
    }
}
