using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    private Transform TileText;

    void Awake ()
    {
        TileText = transform.Find("ValueText");
    }

    void ApplyStyleFromHolder (int style_index, Vector2 tile_size_delta)
    {
        transform.GetComponent<Image>().color = TileStyleHolder.Instance.TileStyles[style_index].TileColor;
        transform.GetComponent<RectTransform>().sizeDelta = tile_size_delta;
        TileText.GetComponent<Text>().text = TileStyleHolder.Instance.TileStyles[style_index].number.ToString();
        TileText.GetComponent<Text>().color = TileStyleHolder.Instance.TileStyles[style_index].TextColor;
    }

    public void ApplyStyle (int tile_value, Vector2 tile_size_delta)
    {
        int style_index = 0;
        switch (tile_value)
        {
            case 4:
                style_index = 1;
                break;
            case 8:
                style_index = 2;
                break;
            case 16:
                style_index = 3;
                break;
            case 32:
                style_index = 4;
                break;
            case 64:
                style_index = 5;
                break;
            case 128:
                style_index = 6;
                break;
            case 256:
                style_index = 7;
                break;
            case 512:
                style_index = 8;
                break;
            case 1024:
                style_index = 9;
                break;
            case 2048:
                style_index = 10;
                break;
        }
        ApplyStyleFromHolder(style_index, tile_size_delta);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
