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
    class OperationManager_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase("買い物に行く")]
        [TestCase("書類をまとめる")]
        [TestCase("ドライブに行く")]
        public void TODOの追加処理を選択すると追加完了メッセージが返ってくる(string addTodoString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var CM = new CsvManager();
            var expectedString = CM.ReturnMessageIsAddingComplete();
            var requestString = OM.WhenNumber1InputProcess(addTodoString);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase("aaa")]
        public void 最初のTODOの取得処理を呼び出すと最初のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var requestString = OM.InputedNumberProcessingSelect(2);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase("ggg")]
        public void 最後のTODOの取得処理を呼び出すと最後のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var requestString = OM.InputedNumberProcessingSelect(3);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODO一覧の取得処理を呼び出すと完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodolistManager();
            var expectedString = TM.ReturnMessageIsOutputAllTodo();
            var requestString = OM.InputedNumberProcessingSelect(4);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void 最初のTODOの削除処理を呼び出すと完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodolistManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var requestString = OM.InputedNumberProcessingSelect(5);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void 最後のTODOの削除処理を呼び出すと完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodolistManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var requestString = OM.InputedNumberProcessingSelect(6);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODOの全削除処理を呼び出すと完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodolistManager();
            var expectedString = TM.ReturnMessageIsRemoveAllTodo();
            var requestString = OM.InputedNumberProcessingSelect(7);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase(4, 2)]
        public void TODOの入れ替え処理を呼び出すと完了メッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodolistManager();
            var expectedString = TM.ReturnMessageIsSwapTodo();
            var requestString = OM.WhenNumber8InputProcess(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, requestString);
        }
    }
}
