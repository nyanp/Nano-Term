using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace NanoTerm
{
    static class Program
    {
        // アプリケーション固定名
        private static string strAppConstName = "NanoTerm";

        // 多重起動を禁止するミューテックス
        private static Mutex mutexObject;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // ミューテックスを生成する
                mutexObject = new Mutex(false, strAppConstName);
            }
            catch (ApplicationException e)
            {
                // グローバル・ミューテックスによる多重起動禁止
                MessageBox.Show("すでに起動しています。NanoTermを2つ同時には起動できません。", "多重起動エラー");
                return;
            }

            // ミューテックスを取得する
            if (mutexObject.WaitOne(0, false))
            {
                // アプリケーションを実行

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                // ミューテックスを解放する
                mutexObject.ReleaseMutex();
            }
            else
            {
                //  警告を表示して終了
                MessageBox.Show("すでに起動しています。NanoTermを2つ同時には起動できません。", "多重起動エラー");
            }

            // ミューテックスを破棄する
            mutexObject.Close();
        }
    }
}
