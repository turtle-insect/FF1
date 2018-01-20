using System;

namespace FF1
{
	class MagicGroup
    {
		public String Name { get; set; }
		public Magic Magic1 { get; }
		public Magic Magic2 { get; }
		public Magic Magic3 { get; }

		public MagicGroup(uint address)
		{
			Magic1 = new Magic(address);
			Magic2 = new Magic(address + 1);
			Magic3 = new Magic(address + 2);
		}
	}
}
