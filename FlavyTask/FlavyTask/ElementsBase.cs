namespace FlavyTask
{
    public class ElementsBase
    {
        public Elements<T> firstElement;
        public T CreateCircularList<T>(IEnumerable<T> ie)
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
        }
    }
}