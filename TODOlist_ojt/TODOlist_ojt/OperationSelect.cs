using System;


namespace TODOlist_ojt
{
    /// <summary>
    /// /コンソールから入力を受け付けるクラス
    /// </summary>
    public class OperationSelect
    {
        OperationManager OM = new OperationManager();
        /// <summary>
        /// 機能の操作番号を入力する
        /// </summary>
        public void inputOperationNumber()
        {
             var showString = "";
            while (IsSameString(showString))
            {
                ShowFunctionList();
                Console.Write("操作番号を入力：");
                var inputNumber = InputElementsExceptionCheck();
                if(inputNumber != 10)
                    inputNumber = CheckNumberAvailableRange(inputNumber);
                showString = IdentifyInputNumberFixDoProcess(inputNumber);
                if (showString != null)
                    Console.WriteLine(showString);
            }
        }
        //文字列が同一かチェックする
        public bool IsSameString(string receivedString)
        {
            var expectedString = ReturnMessageIsProgramEnd();
            return receivedString != expectedString ? true : false;
        }

        //※入力の例外処理のテスト方法?
        /// <summary>
        /// 入力された要素のチェックを行う
        /// 例外が発生した場合は代わりに10を返す
        /// </summary>
        public int InputElementsExceptionCheck()
        {
            try
            {
                var inputNumber = int.Parse(Console.ReadLine());
                return inputNumber;
            }
            catch (FormatException error)
            {
                Console.WriteLine("[!] " + error.Message);
                return 10;
            }
        }
       /// <summary>
       /// 入力された数値が存在する機能番号と一致するかのチェックを行う
       /// 範囲外なら9を返す
       /// </summary>
        public int CheckNumberAvailableRange(int inputNumber)
        {
            return 0 <= inputNumber && inputNumber <= 8 ? inputNumber : 9;
        }
        /// <summary>
        /// 入力された数値を識別してそれに対応する処理を呼び出す
        /// </summary>
        public string IdentifyInputNumberFixDoProcess(int operationNumber)
        {
            switch (operationNumber)
            {
                case 0:
                    return ReturnMessageIsProgramEnd();
                case 1:
                    var todoLine = InputAddTodo();
                    return OM.WhenNumber1InputProcess(todoLine);
                case 8:
                    OM.whenNumber8OutoutProcess();
                    var replacingTodoNumber = InputReplacingTodoNumber();
                    if (replacingTodoNumber == 11)
                        return ReturnNull();
                    var replacementtargetTodoNumber = InputReplacementTargetTodoNumber();
                    if (replacementtargetTodoNumber == 11)
                        return ReturnNull();
                    return OM.WhenNumber8InputProcess(replacingTodoNumber, replacementtargetTodoNumber);
                case 9:
                    return ReturnMessageIsNumberOutsideRange();
                case 10:
                    return ReturnNull();
                default:
                    return OM.InputedNumberProcessingSelect(operationNumber);
            }
        }
        /// <summary>
        /// 追加するTODOを入力する
        /// </summary>
        public string InputAddTodo()
        {
            Console.Write("追加するTODOを入力：");
            var todoLine = Console.ReadLine();
            return todoLine;
        }
        /// <summary>
        /// 入れ替えるTODO番号を入力する
        /// </summary>
        public int InputReplacingTodoNumber()
        {
            Console.Write("入れ替えたいTODO番号を入力：");
            var todoNumber = InputSwapNUmberExceptionCheck();
            return todoNumber;
        }
        /// <summary>
        /// 入れ替え先のTODO番号を入力する
        /// </summary>
        public int InputReplacementTargetTodoNumber()
        {
            Console.Write("入れ替え先のTODO番号を入力：");
            var todoNumber = InputSwapNUmberExceptionCheck();
            return todoNumber;
        }
        /// <summary>
        /// 入力されたTODO入れ替えの番号のチェックを行う
        /// 例外が発生した場合は代わりに11を返す
        /// </summary>
        public int InputSwapNUmberExceptionCheck()
        {
            try
            {
                var inputNumber = int.Parse(Console.ReadLine());
                return inputNumber;
            }
            catch (FormatException error)
            {
                Console.WriteLine("[!] " + error.Message);
                return 11;
            }
        }
        /// <summary>
        /// 数値が範囲外だった場合に返すエラーメッセージ
        /// </summary>
        public string ReturnMessageIsNumberOutsideRange()
        {
            return "[!] 正しい機能番号を入力してください。";
        }
        /// <summary>
        /// nullを返す
        /// </summary>
        public string ReturnNull()
        {
            return null;
        }
        /// <summary>
        /// プログラムを終了する場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsProgramEnd()
        {
            return "<< 終了します >>";
        }
        /// <summary>
        /// 機能の一覧表を表示する
        /// </summary>
        public void ShowFunctionList()
        {
            Console.WriteLine();
            Console.WriteLine("+-----------------------------------機能一覧-----------------------------------+");
            Console.WriteLine("| 1：TODOの追加　 　 2：最初に追加したTODOの表示　3：最後に追加したTODOの表示  |");
            Console.WriteLine("| 4：TODO一覧の表示　5：最初に追加したTODOの削除　6：最後に追加したTODOの削除  |");
            Console.WriteLine("| 7：TODOの全削除　　8：TODOの入れ替え            0：終了                      |");
            Console.WriteLine("+------------------------------------------------------------------------------+");
        }
    }
}