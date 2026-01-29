using DAMS.Client.Models;
using System.Windows.Controls;

namespace DAMS.Client.Services
{
    public class WeatherStationService
    {
        private readonly ModbusRtuService _modbus;
        private const byte SlaveId = 1;

        public WeatherStationService(ModbusRtuService modbus)
        {
            _modbus = modbus;
        }


        private float ReadFloat(ushort startRegister)
        {
            ushort [] regs = _modbus.ReadHoldingRegisters(SlaveId, startRegister, 2);
         
        //    System.Diagnostics.Debug.WriteLine($"Reg0 DEC: {regs[0]}  HEX: {regs[0]:X4}");
         //  System.Diagnostics.Debug.WriteLine($"Reg1 DEC: {regs[1]}  HEX: {regs[1]:X4}");

            return ModbusFloatConverter.ToFloatCDAB(regs[0], regs[1]);
        }
        private int ReadInt(ushort startRegister)
        {
            var regs = _modbus.ReadHoldingRegisters(SlaveId, startRegister, 1);
            return regs[0];
        }

        public WeatherStationData ReadAll()
        {
           // System.Diagnostics.Debug.WriteLine(ReadFloat(8));
            return new WeatherStationData
            {
                WindSpeed = ReadFloat(2),
                WindDirection = ReadInt(1),
                AirTemperature = ReadFloat(4),
               AirHumidity = ReadFloat(6),
                AirPressure = ReadFloat(8),
                Rainfall = ReadFloat(12),
               SolarRadiation = ReadFloat(33),
                UVRadiation = ReadFloat(43),
               Timestamp = DateTime.Now
            };
        }
    }
}
