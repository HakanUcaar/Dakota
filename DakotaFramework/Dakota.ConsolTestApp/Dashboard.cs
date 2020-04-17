using Dakota.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota
{
    public class Dashboard
    {
        private readonly List<IReceiver> Receivers;

        public Dashboard()
        {
            Receivers = new List<IReceiver>();
        }

        public void AddReceiver(IReceiver Receiver)
        {
            Receivers.Add(Receiver);
        }

        public void UpdateDashboard()
        {
            string ShowData = "";
            Console.WriteLine("--------------------------");
            foreach (var item in Receivers)
            {                
                foreach (var MovItem in item.Machine.MovementList)
                {
                    ShowData = item.Machine.Name + " = " + MovItem.Value;
                    Console.WriteLine(ShowData);                    
                }
            }            
        }
    }
}
