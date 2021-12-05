using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlavyTask
{
    public class Elements<T>
    {
        public readonly T item;
        public Elements<T> next;
        private IEnumerable<int> list;
        public Elements<T> firstElement;

        public Elements(IEnumerable<int> list)
        {
            this.list = list;
        }

        public Elements(T item)
        {
            this.item = item;
        }
        /*public int CreateCircularList(IEnumerable<T> ie)
       {
         Elements<T> firstElement = null;
           Elements<T> previousElement = null;
           foreach (var item in ie)
           {
               var newElement = new Elements<T>(item);
               if (firstElement == null)
               {
                   firstElement = newElement;
               }
               else
               {
                   previousElement.next = newElement;
               }
               previousElement = newElement;
           }
           previousElement.next = firstElement;
           return firstElement;
    }*/
    /*   public static T RemoveEvenPeople<T>(IEnumerable<T> ie)
         {
           var elementsCount = ie.Count();
             if (elementsCount == 0)
                 throw new Exception("Empty List");

             var firstElement = CreateCircularList(ie);
             var isdelete = false;
             var currentItem = firstElement;
             Elements<T> previousElement = null;
             while (elementsCount > 1)
             {
                 if (isdelete)
                 {
                     previousElement.next = currentItem.next;
                     elementsCount--;
                 }
                 else
                 {
                     previousElement = currentItem;
                 }
                 currentItem = currentItem.next;
                 isdelete = !isdelete;
             }
             return currentItem.item;
        */}
    }

