using UnityEngine;
using System.Collections;

public class ShowMenu : MonoBehaviour {

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject;
		
		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}
	// Update is called once per frame
	void Update () {
		if (gameController.getMenu () == false)
			Destroy (this);
	}
}
