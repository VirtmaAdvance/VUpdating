using System.Reflection;

namespace VUpdating
{
	public class VUpdate
	{
		/// <summary>
		/// Gets the path of this class library's DLL file.
		/// </summary>
		public static string? VUpdateDLLPath => Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().Location).Path));



		public VUpdate()
		{

		}

		public static bool CheckForUpdates(params string[] urls)
		{
			foreach(string url in urls)
			{

			}
		}


	}
}
