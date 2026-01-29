using Modbus.Device;
using System.IO.Ports;

namespace DAMS.Client.Services
{
    public class ModbusRtuService
    {
        private readonly SerialPort _serialPort;
        private readonly IModbusSerialMaster _master;

    
          public ModbusRtuService(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits, int readTimeout = 2000)
        {
            if (string.IsNullOrWhiteSpace(portName)) throw new ArgumentException("portName required", nameof(portName));

            _serialPort = new SerialPort(portName)
            {
                BaudRate = baudRate,
                DataBits = dataBits,
                Parity = parity,
                StopBits = stopBits
            };

            _serialPort.Open();
            _master = ModbusSerialMaster.CreateRtu(_serialPort);
            _master.Transport.ReadTimeout = readTimeout;
        }

        public ushort[] ReadHoldingRegisters(byte slaveId, ushort start, ushort count)
        {
            return _master.ReadHoldingRegisters(slaveId, start, count);
        }
    }
}
