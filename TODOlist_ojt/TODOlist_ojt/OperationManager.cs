using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist_ojt
{
    /// <summary>
    /// 値を受け取り、その値に対応する処理を呼び出すクラス
    /// </summary>
    public class OperationManager
    {
        TodolistManager TM = new TodolistManager();
        
        /// <summary>
        /// 入力した数値に応じた処理を呼び出す(２～７の場合)
        /// </summary>
        public string InputedNumberProcessingSelect(int inputedNumber)
        {
            switch (inputedNumber)
            {
                case 2:
                    return RequestOutputFirstTodo();
                case 3:
                    return RequestOutputLastTodo();
                case 4:
                    return RequestShowAllTodo();
                case 5:
                    return RequestRemoveFirstTodo();
                case 6:
                    return RequestRemoveLastTodo();
                case 7:
                    return RequestRemoveAllTodo();
                default:
                    return null;
            }
        }
        /// <summary>
        /// 受け取った数値が１の場合の処理（TODOの追加）
        /// </summary>
        public string WhenNumber1InputProcess(string addTodoString)
        {
            return RequestAddTodo(addTodoString);
        }
        /// <summary>
        /// 受け取った数値が８の場合、TODOの一覧を表示する
        /// </summary>
        public void whenNumber8OutoutProcess()
        {
            TM.OutputTodoListContent();
        }
        /// <summary>
        /// 受け取った数値が８の場合の処理（TODOの入れ替え）
        /// </summary>
        public string WhenNumber8InputProcess(int replacingPosition, int targetPosition)
        {
            return RequestSwapTwoTodo(replacingPosition, targetPosition);
        }
        /// <summary>
        /// TODO追加の処理を呼び出す
        /// </summary>
        public string RequestAddTodo(string addTodoString)
        {
            return TM.AddTodoContentToTodoListProcess(addTodoString);
        }
        /// <summary>
        /// 最初に追加したTODOの取得処理を呼び出す
        /// </summary>
        public string RequestOutputFirstTodo()
        {
            return TM.AcquisitionFirstTodoProcess();
        }
        /// <summary>
        /// 最後に追加したTODOの取得処理を呼び出す
        /// </summary>
        public string RequestOutputLastTodo()
        {
            return TM.AcquisitionLastTodoProcess();
        }
        /// <summary>
        /// 全てのTODOの取得処理を呼び出す
        /// </summary>
        public string RequestShowAllTodo()
        {
            return TM.OutputAllTodoProcess();
        }
        /// <summary>
        /// 最初のTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveFirstTodo()
        {
            return TM.RemoveFirstTodoProcess();
        }
        /// <summary>
        /// 最後のTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveLastTodo()
        {
            return TM.RemoveLastTodo();
        }
        /// <summary>
        /// 全てのTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveAllTodo()
        {
            return TM.RemoveAllTodo();
        }
        /// <summary>
        /// TODOの入れ替え処理を呼び出す
        /// </summary>
        public string RequestSwapTwoTodo(int replacingPosition, int targetPosition)
        {
            return TM.SwapTodoProcess(replacingPosition, targetPosition);
        }

        
    }
}
