using UnityEngine;
using System.Collections;

public enum MarbleGameState { playing, won, lost };

public class MarbleGameManager : MonoBehaviour
{	//初始化MarbleGameManager对象（单例模式）
    public static MarbleGameManager SP;
    //按钮的样式
    public GUIStyle buttonStyle;
    //标签的样式
    public GUIStyle labelStyle;
    //钻石的总数
    private int totalGems;
    //已找到钻石的个数
    private int foundGems;
    //游戏的状态
    private MarbleGameState gameState;


    void Awake()
    {
        SP = this;
        foundGems = 0;
        gameState = MarbleGameState.playing;
        totalGems = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //开始游戏
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        //为所有标签赋予样式
        GUI.skin.label = labelStyle;
        //为所有按钮赋予样式
        	GUI.skin.button=buttonStyle;
        //找到钻石数量
        GUILayout.Label(" Found gems: " + foundGems + "/" + totalGems);

        if (gameState == MarbleGameState.lost)
        {
            //游戏状态为Lost时，标签提示游戏失败
            GUILayout.Label("You Lost");
            //放置Play again按钮位置

            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 113, 84), "Play again"))
            {
                //游戏重新开始
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (gameState == MarbleGameState.won)
        {	//游戏状态为won时，标签提示游戏成功
            GUILayout.Label("You won");
            //放置Play again按钮位置
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 113, 84), "Play again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void FoundGem()
    {
        //找到钻石，数量加1
        foundGems++;
        if (foundGems >= totalGems)
        {
            //找到钻石数量大于或者等于总共数量，赢得游戏
            WonGame();
        }
    }

    public void WonGame()
    {	//游戏成功，暂停游戏
        Time.timeScale = 0.0f;
        gameState = MarbleGameState.won;
    }

    public void SetGameOver()
    {	//游戏失败，暂停游戏
        Time.timeScale = 0.0f;
        gameState = MarbleGameState.lost;
    }
}
