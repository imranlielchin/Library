namespace BookProject.Helpers
{
    public static  class PrimiteHelper
    {
        public static string ReadString(string caption,bool allowIsNullOrEmpty=false)
        {
            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = oldColor;

            income=Console.ReadLine();

            if(allowIsNullOrEmpty==false && string.IsNullOrWhiteSpace(income))
            {
                goto l1;
            }

            return income;
        }

        public static int ReadInt(string caption, int min=0,int max=0)
        {
            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            if (min == max && max == 0)
            {
                Console.WriteLine($"{caption}:");
            }
            else
            {
                Console.Write($"{caption} [{min},{max}]");
            }
            Console.ForegroundColor = oldColor;

            income = Console.ReadLine();

            if (!int.TryParse(income,out int value) ||(min!=0 && max!=0 && (value<min || value>max)))
            {
                goto l1;
            }
            return value;
        }

        internal static object ReadEnum<T>(string v)
        {
            throw new NotImplementedException();
        }
    }
}
