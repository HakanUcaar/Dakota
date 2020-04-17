using Dakota.Machine;

namespace Dakota.Receiver
{
    public interface IReceiver
    {
        IMachine Machine { get; set; }
        void Connect();
        void DisConnect();
    }
}
