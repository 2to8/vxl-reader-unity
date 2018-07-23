using System.Collections;
using System.IO;
using UnityEngine;
using Voxel.Core; //да-да, это скилзы :)

public class Loader : MonoBehaviour {

	int width, depth, height;

	private const string MapName = "Hallway.vxl";
	private const string MapsDirectoryPath = "Maps";

	void Start () {
		Map map = new VxlReader().LoadMap(System.IO.File.ReadAllBytes(GetMapPath(MapName)));
		if (map != null){
			Debug.Log("DONE!");
		}
	}

	private string GetMapPath(string filename)
    {
    	return Path.Combine(new string[]{Application.dataPath, MapsDirectoryPath, filename});
    }
}
