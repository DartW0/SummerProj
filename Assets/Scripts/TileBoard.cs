using UnityEngine;
using System.Collections.Generic;

public class TileBoard : MonoBehaviour {

    public int board_size = 2;

    GameObject[,] tiles_array;
    int[,] tiles_values_array;
    List<Vector2> empty_tiles_indexes = new List<Vector2>();
    
    void InitBoardTiles ()
    {
        tiles_array = new GameObject[board_size, board_size];
        tiles_values_array = new int[board_size, board_size];
        for (int i=0; i< board_size; i++)
        {
            for (int j = 0; j < board_size; j++)
            {
                tiles_array[i, j] = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));
                tiles_array[i, j].name = "Tile" + i.ToString() + j.ToString();
                tiles_array[i, j].transform.SetParent(gameObject.transform);

                tiles_values_array[i, j] = 0;
                empty_tiles_indexes.Add(new Vector2(i,j));
            }
        }
    }

    void CreateRandomTilesValue (int _tiles_quantity)
    {
        int tiles_quantity = _tiles_quantity;
        if (tiles_quantity > empty_tiles_indexes.Count)
        {
            tiles_quantity = empty_tiles_indexes.Count;
        }
        for (int i = 0; i < tiles_quantity; i++)
        {
            int random_tile_index = Random.Range(0, empty_tiles_indexes.Count);
            int row_num = (int)empty_tiles_indexes[random_tile_index].x;
            int col_num = (int)empty_tiles_indexes[random_tile_index].y;
            tiles_values_array[row_num, col_num] = 2; // temp
            empty_tiles_indexes.RemoveAt(random_tile_index);
            SetVisibleTileByIndex(row_num, col_num);
        }
    }

    void SetVisibleTileByIndex (int row_num, int col_num)
    {
        Debug.Log("kkkkk  " + row_num.ToString() + col_num.ToString());
        tiles_array[ row_num, col_num ].GetComponent<Tile>().ApplyStyle( tiles_values_array[ row_num, col_num ] );
    }

	// Use this for initialization
	void Start () {
        InitBoardTiles();
        CreateRandomTilesValue(2);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
