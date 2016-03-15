using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileStyle
{
    public int number;
    public Color32 TileColor;
    public Color32 TextColor;
}

public class TileStyleHolder : MonoBehaviour {

    public static TileStyleHolder Instance;

    public TileStyle[] TileStyles;

    void Awake()
    {
        Instance = this;
    }
}
