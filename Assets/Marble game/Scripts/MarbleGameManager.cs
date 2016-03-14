using UnityEngine;
using System.Collections;

public enum MarbleGameState { playing, won, lost };

public class MarbleGameManager : MonoBehaviour
{	//��ʼ��MarbleGameManager���󣨵���ģʽ��
    public static MarbleGameManager SP;
    //��ť����ʽ
    public GUIStyle buttonStyle;
    //��ǩ����ʽ
    public GUIStyle labelStyle;
    //��ʯ������
    private int totalGems;
    //���ҵ���ʯ�ĸ���
    private int foundGems;
    //��Ϸ��״̬
    private MarbleGameState gameState;


    void Awake()
    {
        SP = this;
        foundGems = 0;
        gameState = MarbleGameState.playing;
        totalGems = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //��ʼ��Ϸ
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        //Ϊ���б�ǩ������ʽ
        GUI.skin.label = labelStyle;
        //Ϊ���а�ť������ʽ
        	GUI.skin.button=buttonStyle;
        //�ҵ���ʯ����
        GUILayout.Label(" Found gems: " + foundGems + "/" + totalGems);

        if (gameState == MarbleGameState.lost)
        {
            //��Ϸ״̬ΪLostʱ����ǩ��ʾ��Ϸʧ��
            GUILayout.Label("You Lost");
            //����Play again��ťλ��

            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 113, 84), "Play again"))
            {
                //��Ϸ���¿�ʼ
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (gameState == MarbleGameState.won)
        {	//��Ϸ״̬Ϊwonʱ����ǩ��ʾ��Ϸ�ɹ�
            GUILayout.Label("You won");
            //����Play again��ťλ��
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 113, 84), "Play again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void FoundGem()
    {
        //�ҵ���ʯ��������1
        foundGems++;
        if (foundGems >= totalGems)
        {
            //�ҵ���ʯ�������ڻ��ߵ����ܹ�������Ӯ����Ϸ
            WonGame();
        }
    }

    public void WonGame()
    {	//��Ϸ�ɹ�����ͣ��Ϸ
        Time.timeScale = 0.0f;
        gameState = MarbleGameState.won;
    }

    public void SetGameOver()
    {	//��Ϸʧ�ܣ���ͣ��Ϸ
        Time.timeScale = 0.0f;
        gameState = MarbleGameState.lost;
    }
}
