using System;
using ClassAndObjectsOnProjects.Heritage;
using ClassAndObjectsOnProjects.Methods;

namespace ClassAndObjectsOnProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Dot dot1 = new Dot(10, 20); 
            dot1.CalculateDistance3(); // This is the only Calculate Method acessible from Program Class ...

            Dot3D dot2 = new Dot3D(dot1.x, dot1.y, 20);
            dot2.CalculateDistance3();
            Dot3D.Calculate(); // Static Method ... Belongs to the Class, not instance...

           Ref.Inverter();
           Out.Divide();
        }
    }
}
