namespace ClassAndObjectsOnProjects.Methods
{
    public class Out
    {
        static void Divide(int x, int y, out int result, out int leftover) {
            result = x / y;
            leftover = x % y;
        }

        public static void Divide(){
            Divide(10, 3, out int result, out int rest);
            System.Console.WriteLine("{0} {1}", result, rest); // it will write "3 1"
        }
        
        
    }
}