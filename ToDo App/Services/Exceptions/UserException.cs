using System;

namespace Services
{
    [Serializable]
    public class UserException : Exception
    {

        public UserException(string message)
            : base(message)
        {

        }

    }
}