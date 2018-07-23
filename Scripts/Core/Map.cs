using System.Collections;
using UnityEngine;

namespace AceofSpades.Core {
    public class Map{

	    private readonly int width, height, depth;
	    private readonly uint[] data;

	    public int Width => width;
	    public int Height => height;
	    public int Depth => depth;

	    public const uint EmptyVoxel = 0xffffffff;
		
	    public Map(int width, int height, int depth)
	    {
		    this.width = width;
		    this.height = height;
		    this.depth = depth;
		    data = new uint[checked(width * height * depth)];
		    for (int i = 0; i < data.Length; ++i) data[i] = EmptyVoxel;
	    }

	    public Vector3 Dimensions => new Vector3(width, height, depth);
        
	    int GetIndexForVoxel(int x, int y, int z)
	    {
		    return (x * height + y) * depth + z;
	    }
        
	    int GetIndexForVoxel(Vector3 p)
	    {
		    int rx = Mathf.RoundToInt(p.x);
		    int ry = Mathf.RoundToInt(p.y);
		    int rz = Mathf.RoundToInt(p.z);

		    return ((rx * height + ry) * depth + rz);
	    }
        
	    public bool IsVoxelSolid(int x, int y, int z)
	    {
		    return this[x, y, z] != EmptyVoxel;
	    }
        
	    public bool IsVoxelSolid(Vector3 p)
	    {
		    return this[p] != EmptyVoxel;
	    }

	    public uint this[int x, int y, int z]
	    {
		    get{return data[GetIndexForVoxel(x, y, z)];}
		    set{data[GetIndexForVoxel(x, y, z)] = value;}
	    }

	    public uint this[Vector3 pos]
	    {
		    get{return data[GetIndexForVoxel(pos)];}
		    set{data[GetIndexForVoxel(pos)] = value;}
	    }
    }
}