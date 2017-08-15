using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TODOlist_ojt;

namespace TODOlist_ojt_test
{
    [TestFixture]
    class CsvManager_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase(true)]
        public void CSVファイルの有無を確認し存在するならtrueを返す(bool expectedValue)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var decision = CM.IsExistsCsv();
            Assert.AreEqual(expectedValue, decision);
        }
        [TestCase(true)]
        public void CSVファイルを読み込こんで成功したら空ではないリストが返ってくる(bool expectedValue)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var testlist = new List<string>();
            testlist = CM.LoadingProcessingToCsv();
            CollectionAssert.AllItemsAreNotNull(testlist);
        }
        [Test]
        public void CSVファイルに書き込んで成功したら成功メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var expectedString = CM.ReturnMessageIsAddingComplete();
            var WriteTodoListTest = new List<string> { "xx", "yy", "zz" };
            var ReturnMessage = CM.WriteProcessingToCsvFile(WriteTodoListTest);
            Assert.AreEqual(expectedString, ReturnMessage);
        }

    }
}
