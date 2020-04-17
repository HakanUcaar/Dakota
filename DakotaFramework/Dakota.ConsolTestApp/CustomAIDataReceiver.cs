using System;
using System.Linq;
using Dakota.Machine;
using System.IO.Ports;
using Dakota.Receiver;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Dakota.ConsolTestApp
{
    public class CustomAIDataReceiver : AbstractReceiver
    {
        bool _Continue;
        public CustomAIDataReceiver(IMachine Machine) : base(Machine)
        {
        }

        public override void Connect()
        {
            Console.WriteLine(this.Machine.Name + " bağlandı");
            _Continue = true;
            RandomDataGenerateReceive();
        }
        public override void DisConnect()
        {
            _Continue = false;
        }

        public void RandomDataGenerateReceive()
        {
            var data = "";
            if (_Continue)
            {
                Task.Run(() =>
                {
                    int Counter = RandomNumber.Between(0, 50);
                    Thread.Sleep(RandomNumber.Between(0, 1000));
                    data = "-AIData " + Counter;
                    var Movement = this.Machine.MovementList.Where(o => data.IndexOf(o.RecieverTag) != -1).FirstOrDefault();
                    if (Movement != null)
                    {
                        Movement.Value = data;
                    }
                    RandomDataGenerateReceive();
                });
            }            
        }
    }

    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = maximumValue - minimumValue + 1;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minimumValue + randomValueInRange);
        }
    }
}
