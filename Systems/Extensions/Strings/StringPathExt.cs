using VUpdating.Systems.Extensions.Iteration;

namespace VUpdating.Systems.Extensions.Strings
{
	internal static class StringPathExt
	{

		public static bool Exists(this string path) => Path.Exists(path);

		public static bool IsFile(this string path) => File.Exists(path);

		public static bool IsDirectory(this string path) => Directory.Exists(path);

		public static string RealPath(this string path) => path.Exists() ? Path.GetFullPath(path) : path;

		public static string? GetExtension(this string path) => Path.GetExtension(path)?.ToLower();

		public static void Write(this string path, byte[] data) => File.WriteAllBytes(path, data);

		public static void Write(this string path, string data) => File.WriteAllText(path, data);

		public static void Append(this string path, byte[] data)
		{
			var ins = File.OpenWrite(path);
			ins.Position = ins.Length;
			data.ForEach(q => ins.WriteByte(q));
		}

		public static byte[] ReadBytes(this string path) => File.ReadAllBytes(path);
		/// <summary>
		/// Updates the contents of the <paramref name="sourcePath"/> with the contents of the <paramref name="replacementPath"/>.
		/// </summary>
		/// <param name="sourcePath">The path to the file to update the contents of.</param>
		/// <param name="replacementPath">The path of the file to obtain the replacement contents.</param>
		public static void Update(this string sourcePath, string replacementPath)
		{
			if (!replacementPath.IsFile())
				throw new FileNotFoundException();
			sourcePath.Write(replacementPath.ReadBytes());
		}

	}
}
