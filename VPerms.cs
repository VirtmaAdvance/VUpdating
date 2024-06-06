using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace VUpdating
{
	internal class VPerms
	{
		/// <summary>
		/// Gets the current OS platform.
		/// </summary>
		public static OSPlatform CurrentPlatform
		{
			get
			{
				if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
					return OSPlatform.Windows;
				if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
					return OSPlatform.Linux;
				if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
					return OSPlatform.OSX;
				return OSPlatform.Create(RuntimeInformation.OSDescription);
			}
		}
		/// <summary>
		/// Determines if the current assembly was granted elevated permissions.
		/// </summary>
		public static bool IsElevated => HasPermissions();



		private static bool HasPermissions()
		{
			if(CurrentPlatform==OSPlatform.Windows)
				return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (CurrentPlatform == OSPlatform.Linux || CurrentPlatform==OSPlatform.OSX)
				return Environment.UserName == "root";
			return false;
		}
		/// <summary>
		/// Requests higher elevation for the executing assembly and launches a new instance with elevated permissions.
		/// </summary>
		/// <param name="arguments">The arguments to pass to the new instance of the assembly.</param>
		/// <returns>a <see cref="bool"/> value where true indicates the current assembly is already elevated, and false indicating that the current assembly does not have elevated permissions and a new instance with elevated permissions was requested.</returns>
		public static bool Elevate(string arguments="")
		{
			if(!IsElevated)
			{
				ProcessStartInfo info = new ProcessStartInfo();
				info.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
				info.Verb = "runas";
				info.Arguments = arguments;
				try
				{
					Process.Start(info);
					return false;
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				return false;
			}
			return true;
		}


	}
}
