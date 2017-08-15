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
    class OperationSelect_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        //※入力の例外処理のテスト方法?
        //[TestCase("１")]
        //[TestCase("a")]
        //[TestCase("例外")]
        //public void 機能の選択時に文字列を入力するとエラーメッセージが返ってくる(string unexpectedObject, string expectedString)
        //{

        //    CSVの初期化
        //    startProcess.TestStartingBeforeOperation();
        //    var OS = new OperationSelect();
        //    FormatException error = new FormatException();
        //    var errorMessage = "[!] " + error.Message;
        //}

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(10)]
        [TestCase(24)]
        public void 機能の選択時に範囲外の数値を入力するとエラーメッセージが返ってくる(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OS = new OperationSelect();
            var expectionString = OS.ReturnMessageIsNumberOutsideRange();
            var checkedNumber = OS.CheckNumberAvailableRange(inputNumber);
            var returnString = OS.IdentifyInputNumberFixDoProcess(checkedNumber);
            Assert.AreEqual(expectionString, returnString);
        }
    }
}
