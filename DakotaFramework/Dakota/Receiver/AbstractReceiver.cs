using Dakota.Machine;

namespace Dakota.Receiver
{
    public abstract class AbstractReceiver : IReceiver
    {
        public IMachine Machine { get; set; }

        public AbstractReceiver()
        {

        }
        public AbstractReceiver(IMachine Machine)
        {
            this.Machine = Machine;
        }

        public abstract void Connect();
        public abstract void DisConnect();
    }
}
