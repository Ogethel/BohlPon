using System;
using UnityEngine;

namespace ALS
{
	[Serializable]
	public struct SerializableGUID
	{
		[SerializeField] private ulong part1;
		[SerializeField] private ulong part2;

		public SerializableGUID(Guid guid)
		{
			byte[] bytes = guid.ToByteArray();
			part1 = BitConverter.ToUInt64(bytes, 0);
			part2 = BitConverter.ToUInt64(bytes, 8);
		}

		public Guid ToGuid()
		{
			byte[] bytes = new byte[16];
			Array.Copy(BitConverter.GetBytes(part1), 0, bytes, 0, 8);
			Array.Copy(BitConverter.GetBytes(part2), 0, bytes, 8, 8);
			return new Guid(bytes);
		}

		public override string ToString() => ToGuid().ToString();
	}
}
