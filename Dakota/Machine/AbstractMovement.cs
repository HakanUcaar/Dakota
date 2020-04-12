namespace Dakota.Machine
{
    public abstract class AbstractMovement : IMovement
    {
        object _Value;
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
                    OnReceiveData(this,_Value);
                }
            }
        }

        public AbstractMovement(string RecieverTag)
        {
            this.RecieverTag = RecieverTag;
        }

        public delegate void OnReceiveDataHandler(IMovement Sender, object Data);
        public event OnReceiveDataHandler OnReceiveData;
    }
}
