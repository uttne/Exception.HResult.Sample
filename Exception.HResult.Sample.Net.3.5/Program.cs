using System;
using Sample.Core;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new InvalidOperationException("例外を発生させる");
            }
            catch (Exception ex)
            {
                // このアクセスは .Net Framework 4.5 より前をターゲットにするとできない
                // var hResult = ex.HResult

                
                var hResult = ex.GetHResult();
                Console.WriteLine($"Exception HResult : {hResult:X8}");
            }

            Console.ReadKey();
        }
    }
}
