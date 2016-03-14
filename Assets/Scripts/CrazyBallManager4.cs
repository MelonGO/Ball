using UnityEngine;
using System.Collections;

public class CrazyBallManager4 : MonoBehaviour {

	public static CrazyBallManager4 CB;
	
	public Texture try_again;
	public Texture next;
	public Texture exit;
	public Texture reload;

	public GUIStyle labelStyle;
	
	private int totalGems;
	
	private int foundGems;
	
	private CrazyBallState gameState;
	
	void Awake()
	{
		CB = this;
		foundGems = 0;
		gameState = CrazyBallState.playing;
		totalGems = GameObject.FindGameObjectsWithTag("Pickup").Length;
		
		Time.timeScale = 1.0f;
	}
	
	void OnGUI()
	{
		GUI.skin.label = labelStyle;
		
		GUILayout.Label(" Found gems: " + foundGems + "/" + totalGems);

		if (GUI.Button(new Rect(Screen.width - 160, 10, exit.width, exit.height), exit))
		{
			Application.Quit();
		}

		if (GUI.Button(new Rect(Screen.width - 320, 10, reload.width, reload.height), reload))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (gameState == CrazyBallState.lost)
		{
			
			GUILayout.Label("You Lost!");
			
			if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200), try_again))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		else if (gameState == CrazyBallState.won)
		{
			GUILayout.Label("You won!");
			
			if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200), next))
			{
				Application.LoadLevel("Scene1");
			}
		}
	}
	
	public void FoundGem()
	{
		foundGems++;
		if (foundGems >= totalGems)
		{
			WonGame();
		}
	}
	
	public void WonGame()
	{
		Time.timeScale = 0.0f;
		gameState = CrazyBallState.won;
	}
	
	public void SetGameOver()
	{
		Time.timeScale = 0.0f;
		gameState = CrazyBallState.lost;
	}
}
