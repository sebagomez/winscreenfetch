using System;
using System.Diagnostics;

namespace WinScreenfetch
{
	class Program
	{
		static ConsoleColor logoColor = ConsoleColor.Blue;
		static ConsoleColor labelColor = ConsoleColor.Cyan;
		static Settings settings = new Settings();
		static ConsoleColor prev = Console.ForegroundColor;

		static void Main(string[] args)
		{

			try
			{

				Console.WriteLine();

				BigLogo();

			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Aaaaaagh, this should have never happened!");
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ForegroundColor = prev;
				if (Debugger.IsAttached)
					Console.ReadLine();
			}
		}

		private static void BigLogo()
		{
			Console.ForegroundColor = logoColor;
			Console.Write("                                         ```...--://+oo`");
			Console.ForegroundColor = labelColor;
			Console.WriteLine($"    {settings.UserName}@{settings.ComputerName}");
			Console.ForegroundColor = logoColor;
			Console.Write("                           ```...--://+oooossyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    OS: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.OS);
			Console.ForegroundColor = logoColor;
			Console.Write("             ```...--:/+- .osssyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    Manufacturer: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.Manufacturer);
			Console.ForegroundColor = logoColor;
			Console.Write("   ..--:/++ooosssyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    Uptime: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.Uptime);
			Console.ForegroundColor = logoColor;
			Console.Write("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    Shell: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.Shell);
			Console.ForegroundColor = logoColor;
			Console.Write("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    CPU: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.CPU);
			Console.ForegroundColor = logoColor;
			Console.Write("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.ForegroundColor = labelColor;
			Console.Write("    RAM: ");
			Console.ForegroundColor = prev;
			Console.WriteLine(settings.RAM);
			Console.ForegroundColor = logoColor;
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("  `yyyyyyyyyyyyyyyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("   ..--:/++ooosssyyyyyyy: -yyyyyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("             ```...--:/+- .oossyyyyyyyyyyyyyyyyyyyyyyyy`");
			Console.WriteLine("                           ```...--:/++ooosssyyyyyyyyyy`");
			Console.WriteLine("                                         ```...--::/+oo`");
		}
	}
}
