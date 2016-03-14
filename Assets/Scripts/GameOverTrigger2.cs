using UnityEngine;
using System.Collections;

public class GameOverTrigger2 : MonoBehaviour {

	void OnTriggerEnter()
	{
		CrazyBallManager2.CB.SetGameOver();
		
	}
}
