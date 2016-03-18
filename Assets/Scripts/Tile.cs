using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    private Transform TileText;
    private Transform TileImage;

    void Awake ()
    {
        TileText = transform.Find("ValueText");
        TileImage = transform.Find("BackImage");
    }

    void ApplyStyleFromHolder (int index)
    {
        TileText.GetComponent<Text>().text = TileStyleHolder.Instance.TileStyles[index].number.ToString();
        TileText.GetComponent<Text>().color = TileStyleHolder.Instance.TileStyles[index].TextColor;
        TileImage.GetComponent<Image>().color = TileStyleHolder.Instance.TileStyles[index].TileColor;
        TileText.gameObject.SetActive(true);
        TileImage.gameObject.SetActive(true);
    }

    public void ApplyStyle (int num)
    {
        switch (num)
        {
            case 2:
                ApplyStyleFromHolder(0);
                break;
            case 4:
                ApplyStyleFromHolder(1);
                break;
            case 8:
                ApplyStyleFromHolder(2);
                break;
            case 16:
                ApplyStyleFromHolder(3);
                break;
            case 32:
                ApplyStyleFromHolder(4);
                break;
            case 64:
                ApplyStyleFromHolder(5);
                break;
            case 128:
                ApplyStyleFromHolder(6);
                break;
            case 256:
                ApplyStyleFromHolder(7);
                break;
            case 512:
                ApplyStyleFromHolder(8);
                break;
            case 1024:
                ApplyStyleFromHolder(9);
                break;
            case 2048:
                ApplyStyleFromHolder(10);
                break;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
