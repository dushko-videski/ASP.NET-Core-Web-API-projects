using System;

namespace Services
{
    [Serializable]
    public class ToDoException : Exception
    {

        public ToDoException(string message)
            : base(message)
        {
        }


    }
}