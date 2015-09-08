using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject;

		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		GetComponent<Rigidbody> ().velocity = transform.forward * gameController.getSpeed();
	}

	void Update()
	{
		if (gameController.getRestart() == true)
			Destroy (gameObject);
	}
}
