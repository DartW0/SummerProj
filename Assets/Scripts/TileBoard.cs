using UnityEngine;
using System.Collections.Generic;

public class TileBoard : MonoBehaviour {

    public int board_size = 2;

    GameObject[,] slots_array;
    GameObject[,] tiles_array;
    List<Vector2> empty_slots_indexes = new List<Vector2>();
    int start_tile_value = 2;
    
    void InitBoardTiles ()
    {
        slots_array = new GameObject[board_size, board_size];
        tiles_array = new GameObject[board_size, board_size];
        for (int i=0; i< board_size; i++)
        {
            for (int j = 0; j < board_size; j++)
            {
                slots_array[i, j] = (GameObject)Instantiate(Resources.Load("Prefabs/Slot"));
                slots_array[i, j].name = "Slot" + i.ToString() + j.ToString();
                slots_array[i, j].transform.SetParent(transform);
                empty_slots_indexes.Add(new Vector2(i,j));
            }
        }
    }

    void CreateRandomTiles (int _tiles_quantity)
    {
        int tiles_quantity = _tiles_quantity;
        if (tiles_quantity > empty_slots_indexes.Count)
        {
            tiles_quantity = empty_slots_indexes.Count;
        }
        for (int i = 0; i < tiles_quantity; i++)
        {
            int random_tile_index = Random.Range(0, empty_slots_indexes.Count);
            int row_num = (int)empty_slots_indexes[random_tile_index].x;
            int col_num = (int)empty_slots_indexes[random_tile_index].y;
            empty_slots_indexes.RemoveAt(random_tile_index);

            tiles_array[row_num, col_num] = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));
            tiles_array[row_num, col_num].name = "Tile" + row_num.ToString() + col_num.ToString();
            tiles_array[row_num, col_num].transform.SetParent(transform.parent.Find("TilesContainer"));
            Vector2 slot_size_delta = slots_array[row_num, col_num].transform.GetComponent<RectTransform>().sizeDelta;
            tiles_array[row_num, col_num].GetComponent<Tile>().ApplyStyle(start_tile_value, slot_size_delta);
            tiles_array[row_num, col_num].transform.position = slots_array[row_num, col_num].transform.position;
        }
    }

	// Use this for initialization
	void Start () {
        InitBoardTiles();
        //CreateRandomTiles(2);
        Invoke("Test", 0.1f);
    }
	
    void Test ()
    {
        CreateRandomTiles(2);
    }

	// Update is called once per frame
	void Update () {

    }
}
