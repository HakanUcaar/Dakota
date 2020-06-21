using Dakota.Machine;

namespace Dakota.Receiver
{
    public interface IReceiver
    {
        IMachine Machine { get; set; }
        bool Connect();
        void DisConnect();
    }
}
