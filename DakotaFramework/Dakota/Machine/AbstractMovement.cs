namespace Dakota.Machine
{
    public abstract class AbstractMovement : IMovement
    {
        object _Value;
        IMachine Machine;

        public string Name { get; set; }
        public string RecieverTag { get; set; }
        public object Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                if (_Value != null && OnReceiveData != null)
                {
                    OnReceiveData(Machine, _Value);
                }
            }
        }

        public AbstractMovement(IMachine Machine, string RecieverTag)
        {
            this.Machine = Machine;
            this.RecieverTag = RecieverTag;
        }
        public AbstractMovement(string RecieverTag)
        {
            this.RecieverTag = RecieverTag;
        }

        public delegate void OnReceiveDataHandler(IMachine Sender, object Data);
        public event OnReceiveDataHandler OnReceiveData;
    }
}
