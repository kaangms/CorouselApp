using CorouselApp.Busines.Concrete;
using CorouselApp.Business.Concrete;
using System;
using System.Collections.Generic;

namespace CorouselApp
{
    class Program
    {
       
        static void Main(string[] args)
        {

            GetDailyGain();
            Console.ReadLine();
        }

        private static void GetDailyGain()
        {
           var outputManager = new OutputManager();
           var dailyGain= outputManager.MathInputData().Data;

            Console.WriteLine($"Bu Günlük Kazanç Miktarı {dailyGain}-TL");
        }
        








        #region Non-OOP

        //private static List<int> GetRkN()
        //{
        //    List<int> rkN = new List<int>();
        //    CreateRknCheck(rkN);
        //    return rkN;
        //}
        //private static string InputRkN()
        //{
        //    Console.WriteLine("Lütfen Ekrana boşluk bırakarak 'AtlıKarıncanın Günlük Çalışma Sayısı(R),Oturak Adedini(k) ve Gelen Grup miktarını giriniz?");
        //    var RkN = Console.ReadLine().ToString();
        //    return RkN;
        //}
        //private static void CreateRknCheck(List<int> rkN)
        //{

        //    bool checkInput = true;
        //    int r, k, n = 0;
        //    while (checkInput)
        //    {
        //        var rkNElements = InputRkN().Split(' ');
        //        if (rkNElements.Length == 3)
        //        {

        //            bool InputValueControl =
        //                (int.TryParse(rkNElements[0], out r) &
        //                 int.TryParse(rkNElements[1], out k) &
        //                    int.TryParse(rkNElements[2], out n));
        //            if (InputValueControl)
        //            {
        //                rkN.Add(r);
        //                rkN.Add(k);
        //                rkN.Add(n);
        //                checkInput = false;
        //            }
        //        }
        //        Console.WriteLine("Hatalı Giriş yaptınız!");
        //    }
        //    CreateRiderGroups(n);
        //}

        //private static Dictionary<int, string> InputRiderGroups(int n)
        //{

        //    Console.WriteLine($"Lütfen ekrana boşluk bırakarak {n} adet grubun kişi miktarını giriniz?");
        //    var riderGroups = Console.ReadLine().ToString();
        //    var dictionary = new Dictionary<int, string>();
        //    dictionary.Add(n, riderGroups);

        //    return dictionary;
        //}
        //private static void CreateRiderGroups(int n)
        //{

        //    bool checkInput = true;

        //    while (checkInput)
        //    {
        //        var riderGroups = InputRiderGroups(n)[n].Split(' ');
        //        if (riderGroups.Length == n)
        //        {
        //            foreach (var riderGroup in riderGroups)
        //            {

        //            }


        //            //if (InputValueControl)
        //            //{

        //            //    checkInput = false;
        //            //}
        //        }
        //    }
        //    InputRiderGroups(n);
        //}
        #endregion
    }
}
