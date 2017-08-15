using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist_ojt
{
    /// <summary>
    /// CSVファイルに対する操作を行うクラス
    /// </summary>
    public class CsvManager
    {
        private string csvFileName = @"C:\Users\y.miyazawa\Documents\tododata.csv";

        /// <summary>
        /// CSVファイルが無ければCSVファイルを生成する
        /// </summary>
        public void CheckCsvFileCreate()
        {
            if (!IsExistsCsv())
                CreateCsvFile();
        }
        /// <summary>
        /// CSVファイルの有無を確認する
        /// </summary>
        public bool IsExistsCsv()
        {
            return File.Exists(csvFileName) ? true : false;
        }

        /// <summary>
        /// CSVファイルの生成を行う
        /// </summary>
        public void CreateCsvFile()
        {
            using (var todofile = File.Create(csvFileName))
            {
            }
        }
        /// <summary>
        /// リストにCSVファイルの内容を読み込む
        /// </summary>
        public List<string> ReadCsvFile()
        {
            var readTodoList = new List<string>();
            using (var loadCsvFile = new StreamReader(csvFileName))
            {
                var readLines = loadCsvFile.ReadToEnd().Split(new[] { "\r\n" }, StringSplitOptions.None);
                foreach (var loadLine in readLines)
                    readTodoList.Add(loadLine);
            }
            return readTodoList;
        }
        /// <summary>
        /// CSVからリストへの読み込み処理を行う
        /// 読み込み時にCSVファイルの例外チェックを行い
        /// 読み込みに成功した場合はCSVファイルのデータを格納したリストを返す
        /// 読み込みに失敗した場合は例外メッセージを出力し空のリストを返す
        /// </summary>
        public List<string> LoadingProcessingToCsv()
        {
            var verifiedTodoList = new List<string>();
            try
            {
                return verifiedTodoList = ReadCsvFile();
            }
            catch (Exception error)
            {
                Console.WriteLine(ReturnMessageIsExceptionError(error));
                return verifiedTodoList;
            }
        }
        
        /// <summary>
        /// CSVデータを読み込み仮TODOリストを作成して返す
        /// </summary>
        public List<string> WriteCsvFileLoadedIntoCreatedTemporaryList()
        {
            CheckCsvFileCreate();
            var temporaryTodoList = LoadingProcessingToCsv();
            return temporaryTodoList;
        }
        /// <summary>
        /// CSVファイルにリスト内容を書き込む
        /// </summary>
        public string WriteTodoListToCsvFile(List<string> writeTodoList)
        {
            var temporaryTodoList = new List<string>(writeTodoList);
            using (var writeCsvFile = new StreamWriter(csvFileName))
            {
                foreach (var writeLine in temporaryTodoList)
                    writeCsvFile.WriteLine(writeLine);
            }
            return ReturnMessageIsAddingComplete();
        }
        /// <summary>
        /// リストからCSVへの書き込み処理を行う
        /// </summary>
        public string WriteProcessingToCsvFile(List<string> updatedTodoList)
        {
            var temporaryTodoList = new List<string>(updatedTodoList);
            try
            {
                return WriteTodoListToCsvFile(temporaryTodoList);
            }
            catch (Exception error)
            {
                return ReturnMessageIsExceptionError(error);
            }
        }
        /// <summary>
        /// 例外が発生した場合のメッセージを返す
        /// </summary>
        public string ReturnMessageIsExceptionError(Exception error)
        {
            return "[!] " + error.Message;
        }
        /// <summary>
        /// CSVへの追加が完了した場合のメッセージを返す
        /// </summary>
        /// <returns></returns>
        public string ReturnMessageIsAddingComplete()
        {
            return "<< 追加しました。 >>";
        }
    }
}
