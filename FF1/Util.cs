namespace FF1
{
	class Util
    {
		public const uint BaseAddress = 0;
		public const uint BlockSize = 0xECC;

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}
	}
}
