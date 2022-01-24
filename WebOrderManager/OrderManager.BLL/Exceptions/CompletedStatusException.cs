namespace OrderManager.BLL.Exceptions
{

    [System.Serializable]
    public class CompletedStatusException : Exception
    {
        public CompletedStatusException() { }
        public CompletedStatusException(string message) : base(message) { }
        public CompletedStatusException(string message, Exception inner) : base(message, inner) { }
        protected CompletedStatusException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
