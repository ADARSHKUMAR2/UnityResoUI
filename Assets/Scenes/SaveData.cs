using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SaveData 
{
    public string name;
    public List<MagicCubeData> magicCube;
}

[System.Serializable]
public struct MagicCubeData
{
    public string id;
}


