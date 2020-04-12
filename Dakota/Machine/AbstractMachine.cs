using System;
using System.Collections.Generic;

namespace Dakota.Machine
{
    public abstract class AbstractMachine : IMachine
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<IMovement> MovementList { get; set; }

        public AbstractMachine()
        {
            this.MovementList = new List<IMovement>();
        }
        public AbstractMachine(string ID,string Name)
        {
            this.MovementList = new List<IMovement>();
            this.ID = ID;
            this.Name = Name;
        }

        public IMovement NewMovement(IMovement Movement)
        {
            MovementList.Add(Movement);
            return Movement;
        }
        public IMovement NewMovement<T>() where T : IMovement
        {
            var NewMove = Activator.CreateInstance<T>();
            MovementList.Add(NewMove);
            return NewMove;
        }
    }
}
