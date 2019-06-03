using System;
using System.Reflection;

namespace Sample.Core
{
    public static class ExceptionExtensions
    {
        public static int GetHResult(this Exception ex)
        {
            var propertyInfo = ex.GetType()
                .GetProperty("HResult",
                    BindingFlags.Instance
                    | BindingFlags.GetProperty
                    | BindingFlags.NonPublic
                // ここで BindingFlags.Public を加えない場合
                // .Net Framework 4.5 以上のプロジェクトから呼び出されると NullReferenceException が発生する
                    // | BindingFlags.Public
                );

            if(propertyInfo == null)
                throw new NullReferenceException();

            return (int) propertyInfo.GetValue(ex, null);
        }

    }
}
