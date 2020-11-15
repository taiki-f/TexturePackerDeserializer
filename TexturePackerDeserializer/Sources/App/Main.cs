using System;
using System.Linq;
using System.Collections.Generic;
using AppSystem;
using App.Argument;

namespace App
{
    /// <summary>
    /// メインクラス
    /// </summary>
    class TexturePackerDeserializer
    {
        // 引数の種類
        static readonly int ARG_DEF_TYPE = 0;
        static readonly int ARG_DEF_PARAM = 1;

        // 引数ごとの処理リスト
        static ArgParam m_argParam = new ArgParam();
        static List<IArgument<ArgParam>> m_argFuncList = new List<IArgument<ArgParam>>();

        /// <summary>
        /// メイン関数
        /// </summary>
        /// <param name="args">引数</param>
        static void Main(string[] args)
        {
            // 引数ごとの処理を追加
            m_argParam = new ArgParam();
            m_argFuncList = new List<IArgument<ArgParam>>();
            m_argFuncList.Add(new ArgInputFile());

            // 引数ごとの処理を実行
            foreach (var arg in args)
            {
                // 種類とパラメーターに分割
                string[] p = arg.Split('=');
                if (2 <= p.Length)
                {
                    var func = GetArgFunc(p[ARG_DEF_TYPE]);
                    if (func != null)
                    {
                        // 引数の種類に該当する処理を実行
                        func.Execute(m_argParam, p[ARG_DEF_PARAM]);
                        if (m_argParam.forceAppExit)
                        {
                            // 引数判定を終了する
                            break;
                        }
                    }
                }
            }

            // アプリが強制終了の場合
            if (m_argParam.forceAppExit)
            {
                Console.WriteLine(m_argParam.errorMessage);
                return;
            }
        }

        /// <summary>
        /// 引数の種類に該当する処理を取得する
        /// </summary>
        /// <param name="argType">引数の種類</param>
        /// <returns></returns>
        static IArgument<ArgParam> GetArgFunc(string argType)
        {
            foreach (var exec in m_argFuncList)
            {
                // 該当の
                var func = m_argFuncList.Find(n => n.GetParamType().Equals(argType));
                if (func != null)
                {

                    return func;
                }
            }
            return null;
        }
    }
}
