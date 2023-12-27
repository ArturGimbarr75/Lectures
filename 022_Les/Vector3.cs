// 1_1
using System.Collections;

struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3()
        => X = Y = Z = 0;

    public Vector3(float x, float y)
        => (X, Y, Z) = (x, y, 0);

    public Vector3(float x, float y, float z)
        => (X, Y, Z) = (x, y, z);

    public byte[] ToByteArray()
    {
        List<byte> bytes = new(12);
        bytes.AddRange(BitConverter.GetBytes(X));
        bytes.AddRange(BitConverter.GetBytes(Y));
        bytes.AddRange(BitConverter.GetBytes(Z));
        return bytes.ToArray();
    }

    public static Vector3 FromByteArray(byte[] bitArray)
    {
		if (bitArray.Length != 12)
			throw new ArgumentException("Array length must be 12");
        
        return new Vector3( BitConverter.ToSingle(bitArray, 0),
                            BitConverter.ToSingle(bitArray, 4),
                			BitConverter.ToSingle(bitArray, 8));
	}

    public override string ToString()
		=> $"({X}, {Y}, {Z})";
}