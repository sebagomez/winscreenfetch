using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Management;
using Microsoft.Win32;

namespace WinScreenfetch
{
	internal class Settings
	{
		public string ComputerName { get; set; }
		public string UserName { get; set; }
		public string OS { get; set; }
		public string Uptime { get; set; }
		public string Manufacturer { get; set; }
		public string Shell { get; set; }
		public string CPU { get; set; }
		public string RAM { get; set; }

		public Settings()
		{
			ComputerName = Environment.MachineName;
			UserName = Environment.UserName;
			OS = GetOSName();
			Uptime = GetUptime();
			Shell = Environment.GetEnvironmentVariable("ComSpec");
			SetCPUAndMemory();
		}

		private string GetOSName()
		{
			using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
				return $"{reg.GetValue("ProductName")} Version {reg.GetValue("ReleaseId")} (OS Build {reg.GetValue("CurrentBuildNumber")}.{reg.GetValue("UBR")})";
		}

		private void SetCPUAndMemory()
		{
			using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
			win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
				win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
			{
				long memory = 0;
				foreach (ManagementObject mem in win32Memory.Get())
					memory += long.Parse(mem["Capacity"].ToString());

				RAM = $"{(memory / (1024 * 1024))}MiB";

				foreach (ManagementObject obj in win32Proc.Get())
				{
					CPU = obj["Name"].ToString();
					break;
				}

				foreach (ManagementObject comp in win32CompSys.Get())
				{
					Manufacturer = $"{comp["Manufacturer"]} {comp["SystemFamily"]} {comp["Model"]}";
					break;
				}
			}
		}

		public string GetUptime()
		{
			int ticks = Environment.TickCount;
			int days = ticks / (1000 * 60 * 60 * 24);
			if (days > 0)
				ticks = ticks % (1000 * 60 * 60 * 24);

			int hours = ticks / (1000 * 60 * 60);
			if (days > 0)
				ticks = ticks % (1000 * 60 * 60);

			int mins = ticks / (1000 * 60);

			string uptime = $"{mins}m";
			if (days > 0)
				uptime = $"{days}d {hours}h {mins}m";
			else if (hours > 0)
				uptime = $"{hours}h {mins}m";

			return uptime;
		}

		List<Data> m_data;
		public List<Data> GetWithLabels()
		{
			if (m_data == null)
			{
				m_data = new List<Data>()
				{
					{ new Data { Value=$"{UserName}@{ComputerName}" } },
					{ new Data { Label="OS", Value=OS} },
					{ new Data { Label="Manufacturer", Value=Manufacturer} },
					{ new Data { Label="Uptime", Value=Uptime} },
					{ new Data { Label="Shell", Value=Shell} },
					{ new Data { Label="CPU", Value=CPU} },
					{ new Data { Label="RAM", Value=RAM} }
				};
			}

			return m_data;
		}

		public class Data
		{
			public string Label { get; set; }
			public string Value { get; set; }
		}
	}
}
