using UnityEngine;
using System.Collections;

public class GameOverTrigger3 : MonoBehaviour {

	void OnTriggerEnter()
	{
		CrazyBallManager3.CB.SetGameOver();
		
	}
}
