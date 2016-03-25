using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    private Transform TileText;
    private int tile_value;
    
    public int Value
    {
        get
        {
            return tile_value;
        }
        set
        {
            tile_value = value;
            ApplyStyle(tile_value);
        }
    }

    void Awake ()
    {
        TileText = transform.Find("ValueText");
    }

    public void ApplyStyle (int tile_value)
    {
        int style_index = (int)Mathf.Log(tile_value, 2) - 1;
        ApplyStyleFromHolder(style_index);
    }

    void ApplyStyleFromHolder(int style_index)
    {
        transform.GetComponent<Image>().color = TileStyleHolder.Instance.TileStyles[style_index].TileColor;
        TileText.GetComponent<Text>().text = TileStyleHolder.Instance.TileStyles[style_index].number.ToString();
        TileText.GetComponent<Text>().color = TileStyleHolder.Instance.TileStyles[style_index].TextColor;
    }

    public void ApplySize(Vector2 tile_size_delta)
    {
        transform.GetComponent<RectTransform>().sizeDelta = tile_size_delta;
    }
}
