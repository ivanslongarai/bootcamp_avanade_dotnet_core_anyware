using System;

namespace ProgramStructure.Examples
{
    public class Stack
    {

        Position first;

        public Object StackUp(Object item)
        {
            first = new Position(first, item);
            Object result = first.item;
            return result;
        }

        public Object Unstack()
        {
            if (first == null)
            {
                throw new InvalidOperationException();
            }
            Object result = first.item;
            first = first.next;
            return result;
        }

        class Position {
            public Position next;
            public Object item;

            public Position (Position next, Object item) {
                this.next = next;
                this.item = item;
            }
        }
        
    }
}