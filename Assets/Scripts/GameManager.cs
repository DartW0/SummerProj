using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    GameObject tile_board;
    int score = 0;
    int high_score = 0;

    void Awake ()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", high_score);
        }
        else
        {
            high_score = PlayerPrefs.GetInt("HighScore");
            GameObject.Find("HighScorePanel").transform.Find("ValueText").GetComponent<Text>().text = high_score.ToString();
        }
        tile_board = GameObject.Find("TileBoard");
    }

    public void Move(MoveDirection md)
    {
        tile_board.GetComponent<TileBoard>().MoveTiles(md);
    }

    public void RestartGame()
    {
        tile_board.GetComponent<TileBoard>().ClearBoard();
        tile_board.GetComponent<TileBoard>().CreateStartTiles();
        ClearScore();
    }

    public void AddValueToScore (int value)
    {
        score += value;
        GameObject.Find("ScorePanel").transform.Find("ValueText").GetComponent<Text>().text = score.ToString();
        if (high_score < score)
        {
            high_score = score;
            PlayerPrefs.SetInt("HighScore", high_score);
            GameObject.Find("HighScorePanel").transform.Find("ValueText").GetComponent<Text>().text = high_score.ToString();
        }
    }

    void ClearScore ()
    {
        score = 0;
        GameObject.Find("ScorePanel").transform.Find("ValueText").GetComponent<Text>().text = score.ToString();
    }
}
