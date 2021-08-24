namespace ClassAndObjectsOnProjects.Heritage
{
    public class Dot
    {
        public int x, y;


        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        protected void CalculateDistance() 
        {
            // do something ...
        }

        private void CalculateDistance2()
        {
            // do something ...
        }

        public virtual void CalculateDistance3()
        {
            // do something ...
        }


    }
}