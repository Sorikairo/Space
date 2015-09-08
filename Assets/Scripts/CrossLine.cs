using UnityEngine;
using System.Collections;
[System.Serializable]
public class MaterialsArray
{
	public Material blue;
	public Material red;
	public Material green;
	public Material pink;
};
public class CrossLine : MonoBehaviour {

	private GameController gameController;
	public MaterialsArray materialArray;

	void Start()
	{
		GameObject gameControllerObject;

		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}
	void OnTriggerExit(Collider Other)
	{
		if (Other.tag == "Cube") {
			gameController.GameOver();
		}
	}
}
