namespace HW15Library
{
    public class UserException : Exception
    {
        public UserException(string value)
        {
            Console.WriteLine(value);
        }
    }
}