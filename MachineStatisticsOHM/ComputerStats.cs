using OpenHardwareMonitor.Hardware;
using System;

namespace MachineStatisticsOHM
{
    public class ComputerStats
    {
        public string CpuTemp { get; private set; }
        public string CpuLoad { get; private set; }
        public string GpuTemp { get; private set; }
        public string GpuLoad { get; private set; }

        public void GetComputerStats()
        {
            Computer comp = new Computer()
            {
                CPUEnabled = true,
                GPUEnabled = true
            };
            comp.Open();

            foreach (var hardware in comp.Hardware)
            {
                if(hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            CpuTemp = sensor.Value.ToString();
                        }

                        if (sensor.SensorType == SensorType.Load)
                        {
                            CpuLoad = sensor.Value.ToString();
                        }
                    }
                }

                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            GpuTemp = sensor.Value.ToString();
                        }

                        if (sensor.SensorType == SensorType.Load)
                        {
                            GpuLoad = sensor.Value.ToString();
                        }
                    }
                }

                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            GpuTemp = sensor.Value.ToString();
                        }

                        if (sensor.SensorType == SensorType.Load)
                        {
                            GpuLoad = sensor.Value.ToString();
                        }
                    }
                }
            }
        }
    }
}
