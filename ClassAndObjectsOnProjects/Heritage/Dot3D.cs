namespace ClassAndObjectsOnProjects.Heritage
{
    public class Dot3D : Dot {

        public int z;
        
        public Dot3D(int x, int y, int z) : base(x, y)
        {
          this.z = z;
          CalculateDistance();
          // CalculateDistance2(); Dot3D has not access to this method... It's private on the base class...
        }

        public static void Calculate() {
            // do something ...
        }

        public override void CalculateDistance3()
        {
            base.CalculateDistance3();
            // do something ...
        }

    }
}