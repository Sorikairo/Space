using UnityEngine;
using System.Collections;

public class DestroyLeaver : MonoBehaviour {

	private GameController gameController;
	
	void Start()
	{
		GameObject gameControllerObject;
		
		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
		if (gameController.getGameOver() == false)
			gameController.addScore();
	}
}
