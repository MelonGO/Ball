using UnityEngine;
using System.Collections;

public class GameOverTrigger4 : MonoBehaviour {

	void OnTriggerEnter()
	{
		CrazyBallManager4.CB.SetGameOver();
		
	}
}
