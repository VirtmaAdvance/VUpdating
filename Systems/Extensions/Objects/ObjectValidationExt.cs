namespace VUpdating.Systems.Extensions.Objects
{
	internal static class ObjectValidationExt
	{
		/// <summary>
		/// Determines if the <paramref name="value"/> is <see langword="null"/>.
		/// </summary>
		/// <param name="value">Any mixed value.</param>
		/// <returns>a <see cref="bool"/> representation of the result.</returns>
		public static bool IsNull(this object? value) => value is null;
		/// <inheritdoc cref="IsNull(object?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is not <see langword="null"/>.
		/// </summary>
		public static bool NotNull(this object? value) => value is not null;

	}
}
