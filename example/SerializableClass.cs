using System;
using UnityEngine;

namespace SwitchboardExample
{
	[Serializable]
	public class SerializableClass
	{
		public enum TestEnum { One, Two, Three }

		public bool Bool;
		public byte Byte;
		public sbyte Sbyte;
		public short Short;
		public ushort Ushort;
		public int Int;
		public uint Uint;
		public long Long;
		public ulong Ulong;
		public float Float;
		public double Double;
		public char Char;
		public string String;

		public UnityEngine.Object Object;

		public TestEnum MyEnum;
		public LayerMask LayerMask;

		public Color Color;
		public Gradient Gradient;
		public AnimationCurve AnimationCurve;

		public Vector2 Vector2;
		public Vector2Int Vector2Int;
		public Vector3 Vector3;
		public Vector3Int Vector3Int;
		public Vector4 Vector4;
		public Rect Rect;
		public RectInt RectInt;
		public Bounds Bounds;
		public BoundsInt BoundsInt;
	}
}
