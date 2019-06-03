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
                // .Net Framework 4.5 以上であればこのアクセスが可能
                var _ = ex.HResult;

                try
                {
                    var hResult = ex.GetHResult();
                    Console.WriteLine($"Exception HResult : {hResult:X8}");
                }
                catch (NullReferenceException)
                {
                    // .Net Framework 3.5 で作られたライブラリの場合でも .Net Framework 4.5 以上で作られたプロジェクトから呼び出すと
                    // 参照されるランタイムが .Net Framework 4.5 以上になるため Exception の定義も .Net Framework 3.5 とは変わり
                    // GetHResult() の実装では NullReferenceException が発生する
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
