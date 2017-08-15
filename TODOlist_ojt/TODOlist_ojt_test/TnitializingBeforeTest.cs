using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TODOlist_ojt;

namespace TODOlist_ojt_test
{
    /// <summary>
    /// テスト開始前の初期処理を行うクラス
    /// </summary>
    public class TnitializingBeforeTest
    {
        /// <summary>
        /// 各テストの開始前処理（要素数７）：
        /// CSVファイルに指定データを上書きして初期化を行う
        /// </summary>
        public void TestStartingBeforeOperation_ElemetsCountIs_7()
        {
            var nitializationData = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg" };
            try
            {
                WriteCsvFile(nitializationData);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        /// <summary>
        /// 各テストの開始前処理（要素数１）：
        /// CSVファイルに指定データを上書きして初期化を行う
        /// </summary>
        public void TestStartingBeforeOperation_ElemetsCountIs_1()
        {
            var nitializationData = new List<string> { "aaa" };
            try
            {
                WriteCsvFile(nitializationData);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        /// <summary>
        /// CSVファイルにリスト内容を書き込む
        /// </summary>
        private void WriteCsvFile(List<string> writeTodoList)
        {
            var temporaryTodoList = new List<string>(writeTodoList);
            using (var csvTodoList = new StreamWriter(@"C:\Users\y.miyazawa\Documents\tododata.csv"))
            {
                foreach (var line in temporaryTodoList)
                    csvTodoList.WriteLine(line);
            }
        }
    }
}
