using UnityEngine;
using System.Collections;

public class GameOverTrigger1 : MonoBehaviour {

    void OnTriggerEnter()
    {
		CrazyBallManager1.CB.SetGameOver();
        
    }
}