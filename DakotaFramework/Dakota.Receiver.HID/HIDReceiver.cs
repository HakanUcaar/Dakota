using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HidSharp;
using Dakota.Machine;
using System.Threading;
using HidSharp.Reports;

namespace Dakota.Receiver.HID
{
    public class HIDReceiver : AbstractReceiver
    {
        bool _Continue;
        private HidDevice Device;

        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public string DevicePath { get; set; }

        public HIDReceiver(IMachine Machine) : base(Machine)
        {
            
        }

        public override void Connect()
        {
            try
            {
                var list = DeviceList.Local;

                
                if (DeviceList.Local.TryGetHidDevice(out Device, VendorId, ProductId))
                {
                    _Continue = true;
                    ReceiveData();
                }                
            }
            catch (Exception e)
            {
                _Continue = false;
            }
        }

        public override void DisConnect()
        {
            if (Device != null)
            {
                _Continue = false;
            }
        }

        void ReceiveData()
        {
         
            var ReportDescriptor = Device.GetReportDescriptor();
            HidStream hidStream;
            if (Device.TryOpen(out hidStream))
            {
                Console.WriteLine("Opened device.");
                hidStream.ReadTimeout = Timeout.Infinite;

                using (hidStream)
                {
                    var deviceItem = ReportDescriptor.DeviceItems.FirstOrDefault();
                    var inputReportBuffer = new byte[Device.GetMaxInputReportLength()];
                    var inputReceiver = ReportDescriptor.CreateHidDeviceInputReceiver();
                    var inputParser = deviceItem.CreateDeviceItemInputParser();

                    inputReceiver.Received += (sender, e) =>
                    {
                        if (_Continue)
                        {
                            Report report;
                            while (inputReceiver.TryRead(inputReportBuffer, 0, out report))
                            {
                                if (inputParser.TryParseReport(inputReportBuffer, 0, report))
                                {
                                     WriteDeviceItemInputParserResult(inputParser);
                                }
                            }
                        }
                    };
                    inputReceiver.Start(hidStream);

                    Thread.Sleep(200000);
                }
            };
        }

        private async void WriteDeviceItemInputParserResult(HidSharp.Reports.Input.DeviceItemInputParser parser)
        {
            if (parser.HasChanged)
            {
                int valueCount = parser.ValueCount;
                string Value = "";
                for (int valueIndex = 0; valueIndex < valueCount; valueIndex++)
                {
                    var dataValue = parser.GetValue(valueIndex);
                    var Data = dataValue.GetLogicalValue().ToString("X2");
                    if (Value == "")
                    {
                        Value += Data;
                    }
                    else
                    {
                        Value += string.Format(" {0}", Data);
                    }
                    
                }

                await Task.Run(() =>
                {
                    var Movement = this.Machine.MovementList.Where(o => Value.IndexOf(o.RecieverTag) != -1).FirstOrDefault();
                    if (Movement != null)
                    {
                        Movement.Value = Value;
                    }
                });
            }
        }
    }
}
