using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int score = 0;

    public void AddValueToScore (int value)
    {
        score += value;
        GameObject.Find("ScorePanel").transform.Find("ValueText").GetComponent<Text>().text = score.ToString();
    }

    public void Move (MoveDirection md)
    {
        GameObject.Find("TileBoard").GetComponent<TileBoard>().MoveTiles(md);
    }
}
