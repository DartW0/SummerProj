using UnityEngine;
using System.Collections.Generic;

public class TileBoard : MonoBehaviour {

    public int board_size = 2;

    GameObject[,] slots_array;
    GameObject[,] tiles_array;
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
            }
        }
    }

    void CreateRandomTiles (int _tiles_quantity)
    {
        List<Vector2> empty_slots_indexes = GetEmptySlotsIndexes(_tiles_quantity);
        for (int i = 0; i < empty_slots_indexes.Count; i++)
        {
            int row_num = (int)empty_slots_indexes[i].x;
            int col_num = (int)empty_slots_indexes[i].y;
            tiles_array[row_num, col_num] = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));
            tiles_array[row_num, col_num].name = "Tile";
            tiles_array[row_num, col_num].transform.SetParent(transform.parent.Find("TilesContainer"));
            tiles_array[row_num, col_num].GetComponent<Tile>().Value = start_tile_value;
            Vector2 slot_size_delta = slots_array[row_num, col_num].transform.GetComponent<RectTransform>().sizeDelta;
            tiles_array[row_num, col_num].GetComponent<Tile>().ApplySize(slot_size_delta);
            tiles_array[row_num, col_num].transform.position = slots_array[row_num, col_num].transform.position;
        }
    }

    List<Vector2> GetEmptySlotsIndexes (int _slots_quantity)
    {
        List<Vector2> all_empty_slots_indexes = new List<Vector2>();

        for (int i = 0; i < board_size; i++)
        {
            for (int j = 0; j < board_size; j++)
            {
                if (!tiles_array[i, j])
                {
                    all_empty_slots_indexes.Add(new Vector2(i, j));
                }
            }
        }

        int slots_quantity = _slots_quantity;
        if (slots_quantity > all_empty_slots_indexes.Count)
        {
            slots_quantity = all_empty_slots_indexes.Count;
        }

        List<Vector2> random_empty_slots_indexes = new List<Vector2>();
        for (int i = 0; i < slots_quantity; i++)
        {
            int random_slot_index = Random.Range(0, all_empty_slots_indexes.Count);
            random_empty_slots_indexes.Add(all_empty_slots_indexes[random_slot_index]);
            all_empty_slots_indexes.RemoveAt(random_slot_index);
        }

        return random_empty_slots_indexes;
    }

    public void MoveTiles (MoveDirection md)
    {
        Debug.Log(md.ToString() + " move for tiles");
        //init move parameters
        int row_shift = 1;
        int col_shift = 1;
        bool is_bypass_tile_order_straight = true;
        switch (md)
        {
            case MoveDirection.Right:
                row_shift = 0;
                col_shift = 1;
                is_bypass_tile_order_straight = false;
                break;
            case MoveDirection.Left:
                row_shift = 0;
                col_shift = -1;
                is_bypass_tile_order_straight = true;
                break;
            case MoveDirection.Up:
                row_shift = -1;
                col_shift = 0;
                is_bypass_tile_order_straight = true;
                break;
            case MoveDirection.Down:
                row_shift = 1;
                col_shift = 0;
                is_bypass_tile_order_straight = false;
                break;

        }

        bool is_move_possible = true;
        while (is_move_possible)
        {
            int possible_moves = 0;
            for (int i = 0; i < board_size; i++)
            {
                if (is_bypass_tile_order_straight)
                {
                    for (int j = 0; j < board_size; j++)
                    {
                        if (MoveSpecificTile(i, j, row_shift, col_shift))
                        {
                            possible_moves++;
                        }
                    }
                }
                else
                {
                    for (int j = board_size - 1; j >= 0; j--)
                    {
                        if (MoveSpecificTile(i, j, row_shift, col_shift))
                        {
                            possible_moves++;
                        }
                    }
                }
            }

            if (possible_moves == 0)
            {
                is_move_possible = false;
            }
        }
        Debug.Log("vyxod");



        CreateRandomTiles(2);
    }

    bool MoveSpecificTile (int row_index, int col_index, int row_shift, int col_shift)
    {
        if (tiles_array[row_index, col_index] && IsTileIndexExists(row_index + row_shift, col_index + col_shift))
        {
            Debug.Log("tile not empty " + row_index.ToString() + col_index.ToString());
            if (!tiles_array[row_index + row_shift, col_index + col_shift])
            {
                tiles_array[row_index + row_shift, col_index + col_shift] = tiles_array[row_index, col_index];
                tiles_array[row_index + row_shift, col_index + col_shift].transform.position = slots_array[row_index + row_shift, col_index + col_shift].transform.position;
                tiles_array[row_index, col_index] = null;

                if (IsTileIndexExists(row_index + row_shift*2, col_index + col_shift*2) && !tiles_array[row_index + row_shift * 2, col_index + col_shift * 2])
                {
                    return true;
                }
            }
            else if (tiles_array[row_index, col_index].GetComponent<Tile>().Value == tiles_array[row_index + row_shift, col_index + col_shift].GetComponent<Tile>().Value)
            {
                tiles_array[row_index + row_shift, col_index + col_shift].GetComponent<Tile>().Value = tiles_array[row_index + row_shift, col_index + col_shift].GetComponent<Tile>().Value * 2;
                Destroy(tiles_array[row_index, col_index].gameObject);
                tiles_array[row_index, col_index] = null;
            }
        }
        return false;
    }

    bool IsTileIndexExists(int row_num, int col_num)
    {
        if (row_num >= 0 && row_num < board_size && col_num >= 0 && col_num < board_size)
        {
            return true;
        }
        return false;
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
