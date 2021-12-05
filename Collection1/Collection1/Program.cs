using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection1
{
    class Program
    {
        static void Main()
        {
            var list = new List<int>(Enumerable.Range(1, N));// personList указывает на первого человека в списке


            var p = list;
            while (p != p.NextPerson) // пока человек не остался один в списке
            {
                #region Этот кусок для корректного вывода списка на экран. Если вывод не нужен, можно убрать
                if (list == p.NextPerson)
                {
                    list = p.NextPerson.NextPerson;
                }
                #endregion

                // <ВсяСоль>
                p = p.NextPerson = p.NextPerson.NextPerson;
                // </ВсяСоль>

                // Если убрать верхний регион, то может возникнуть ситуация, когда personList указывает на 
                // человека, который был удалён из списка. Возникнет бесконечный цикл.

            }
        }




    }
}
