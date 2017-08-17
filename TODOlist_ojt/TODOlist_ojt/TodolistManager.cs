using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOlist_ojt
{
    /// <summary>
    /// TODOリストに対する操作を行うクラス
    /// </summary>
    public class TodolistManager
    {
        CsvManager CM = new CsvManager();
        public List<string> todoList = new List<string>();

        /// <summary>
        /// CSVデータの内容をリストに取得する
        /// </summary>
        public void LoadCsvFiletoTodoList()
        {
            todoList = CM.WriteCsvFileLoadedIntoCreatedTemporaryList();
            todoList.RemoveAll(s => s == "");
        }
        /// <summary>
        /// TODOリストの内容の空かどうか判定
        /// </summary>
        public bool IsTodoListContentEmpty(List<string> todoList)
        {
            return !todoList.Any() ? true : false;
        }
        /// <summary>
        /// リストにTODOを追加する
        /// </summary>
        public string AddTodoContentToTodoListProcess(string addTodoContents)
        {
            LoadCsvFiletoTodoList();
            todoList.RemoveAll(s => s == "");
            todoList.Add(addTodoContents); 
            return CM.WriteProcessingToCsvFile(todoList);
        }

        /// <summary>
        /// 最初のTODOを取得する
        /// </summary>
        public string AcquisitionFirstTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            return todoList[0];
        }
        /// <summary>
        /// 最後のTODOを取得する
        /// </summary>
        public string AcquisitionLastTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            return todoList[todoList.Count - 1];
        }
        /// <summary>
        /// TODOリストの内容を出力する
        /// </summary>
        public void OutputTodoListContent()
        {
            LoadCsvFiletoTodoList();
            var todoNumber = 1;
            Console.WriteLine("---------TODO一覧---------");
            foreach (string outputLine in todoList)
            {
                Console.WriteLine("{0}.{1}", todoNumber, outputLine);
                todoNumber++;
            }
            Console.WriteLine("--------------------------");
        }

        /// <summary>
        /// 全てのTODOを出力する処理
        /// </summary>
        public string OutputAllTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            OutputTodoListContent();
            return ReturnMessageIsOutputAllTodo();
        }

        /// <summary>
        /// 最初のTODOを削除する
        /// </summary>
        public string RemoveFirstTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            var firstContent = 0;
            todoList.RemoveAt(firstContent);
            todoList.RemoveAll(s => s == "");
            CM.WriteProcessingToCsvFile(todoList);
            return ReturnMessageIsRemoveTodo();
        }
        /// <summary>
        /// 最後のTODOを削除する
        /// </summary>
        public string RemoveLastTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            var lastContent = todoList.Count - 1;
            todoList.RemoveAt(lastContent);
            todoList.RemoveAll(s => s == "");
            CM.WriteProcessingToCsvFile(todoList);
            return ReturnMessageIsRemoveTodo();
        }
        /// <summary>
        /// 全てのTODOを削除する
        /// </summary>
        public string RemoveAllTodo()
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();
            todoList.Clear();
            CM.WriteProcessingToCsvFile(todoList);
            return ReturnMessageIsRemoveAllTodo();
        }
        /// <summary>
        /// TODOを入れ替える処理
        /// </summary>
        public string SwapTodo(int replacingPosition, int taegetPosition)
        {
            LoadCsvFiletoTodoList();
            if (IsTodoListContentEmpty(todoList))
                return ReturnMessageIsListempty();

            if (IsCheckListElementsCountTwoLessThan())
                return ReturnMessageIsTodolistElementsCountIsOne();

            if (IsCheckReplacePosition(replacingPosition) || 
                IsCheckReplacePosition(taegetPosition))
                return ReturnMessageIsNumberRangeOutsideTodo();

            if (IsCheckEqualValueSpecified(replacingPosition, taegetPosition))
                return ReturnMessageIsEqualValueSpecified();

            SwapSelectedTwoTodoOrder(replacingPosition, taegetPosition);
                CM.WriteProcessingToCsvFile(todoList);
                return ReturnMessageIsSwapTodo();
        }
        /// <summary>
        /// TODOリストの要素数が２未満かチェックする
        /// </summary>
        public bool IsCheckListElementsCountTwoLessThan()
        {
            return todoList.Count < 2 ? true : false;
        }
        /// <summary>
        /// 選択された要素番号がTODOリストの要素数を超えていないかチェックを行う
        /// </summary>
        public bool IsCheckReplacePosition(int checkPosition)
        {
            return checkPosition <= 0 || todoList.Count < checkPosition ? true : false;
        }
        /// <summary>
        /// 選択された要素番号が同一の値かチェックする
        /// </summary>
        private bool IsCheckEqualValueSpecified(int replacingPosition, int taegetPosition)
        {
            return replacingPosition == taegetPosition ? true : false;
        }
        /// <summary>
        /// 選択された二つのTODOの順番を入れ替える
        /// </summary>
        public void SwapSelectedTwoTodoOrder(int replacing, int taeget)
        {
            var replacingPosition = replacing - 1;
            var taegetPosition = taeget - 1;
            var temporaryTodoList = new List<string>(todoList);
            todoList.Clear();
            for(int i=0; i < temporaryTodoList.Count; i++)
            {
                if (i == replacingPosition)
                    todoList.Add(temporaryTodoList[taegetPosition]);
                if (i == taegetPosition)
                    todoList.Add(temporaryTodoList[replacingPosition]);
                if(i != taegetPosition && i != replacingPosition)
                    todoList.Add(temporaryTodoList[i]);
            }
        }
        /// <summary>
        /// リストが空の場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsListempty()
        {
            return "[！] リストにTODOデータが存在しません。";
        }
        /// <summary>
        /// 選択された要素番号が同一だった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsEqualValueSpecified()
        {
            return "[！] 入れ替え元と入れ替え先が同一です。";
        }

        /// <summary>
        /// TODOの削除を行った場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsRemoveTodo()
        {
            return "<< 削除しました >>";
        }
        /// <summary>
        /// TODOの一覧表示を行った場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsOutputAllTodo()
        {
            return "<< 一覧を表示しました >>";
        }

        /// <summary>
        /// リストのTODOをすべて削除した場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsRemoveAllTodo()
        {
            return "<< TODOをすべて削除しました >>";
        }
        /// <summary>
        /// TODOを入れ替えた場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsSwapTodo()
        {
            return "<< TODOを入れ替えました >>";
        }
        /// <summary>
        /// 選択した数値がリストの範囲外だった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsNumberRangeOutsideTodo()
        {
            return "[！] 選択した数値がリストの範囲外です。";
        }
        /// <summary>
        /// TODOの要素数が一個だった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsTodolistElementsCountIsOne()
        {
            return "[！] TODOが一件しかありません。";
        }
    }
}
