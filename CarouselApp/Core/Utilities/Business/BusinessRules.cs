using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorouselApp.Core.Utilities.Business
{
    public class BusinessRules
    {//hata yoksa null döner
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    Console.WriteLine(result.Message);
                    return result;
                }
            }

            return null;
        }
    }
}
