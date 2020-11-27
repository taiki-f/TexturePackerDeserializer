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
            m_argParam = new ArgParam();
            m_argFuncList = new List<IArgument<ArgParam>>();

            // 引数ごとの処理を追加
            m_argFuncList.Add(new ArgHelp());           // ヘルプ確認
            m_argFuncList.Add(new ArgVersion());        // バージョン確認
            m_argFuncList.Add(new ArgInputFile());      // 入力ファイル情報
            m_argFuncList.Add(new ArgOutputMode());     // 出力モード
            m_argFuncList.Add(new ArgOutputFile());     // 出力ファイル情報
            m_argFuncList.Add(new ArgOutputFormat());   // 出力フォーマット

            // 引数ごとの処理を実行
            string funcParam;
            foreach (var func in m_argFuncList)
            {
                funcParam = String.Empty;
                foreach (var arg in args)
                {
                    var p = arg.Split('=');
                    if (p[ARG_DEF_TYPE].Equals(func.GetParamType()))
                    {
                        if (1 == p.Length)
                        {
                            // パラメーターなしの処理なので疑似パラメーターを格納
                            funcParam = "NONE";
                        }
                        else
                        {
                            // 一致する引数があればパラメーターを格納
                            funcParam = p[ARG_DEF_PARAM];
                        }
                        break;
                    }
                }

                if (String.IsNullOrWhiteSpace(funcParam))
                {
                    // 必須処理なら強制終了
                }
                else
                {
                    // 引数の種類に該当する処理を実行
                    func.Execute(m_argParam, funcParam);
                    if (m_argParam.forceAppExit)
                    {
                        // 引数判定を終了する
                        break;
                    }
                }
            }

            // アプリが強制終了の場合
            if (m_argParam.forceAppExit && !String.IsNullOrWhiteSpace(m_argParam.exitMessage))
            {
                Console.WriteLine(m_argParam.exitMessage);
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
