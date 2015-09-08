using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundery
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
};

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundery limit;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire ;


	void FixedUpdate () {	

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody>().velocity = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, limit.xMin, limit.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, limit.zMin, limit.zMax)
		);
		if (Input.touchCount > 0) {
			
			Touch myTouch = Input.GetTouch(0);

			Vector2 touchPosition = myTouch.position;
			
			if (touchPosition.x >= (Screen.width / 2))
				GetComponent<Rigidbody>().velocity = new Vector3(1 * speed, 0.0f, 0);
			else
				GetComponent<Rigidbody>().velocity = new Vector3(-1 * speed, 0.0f, 0);
			GetComponent<Rigidbody> ().position = new Vector3 (
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, limit.xMin, limit.xMax),
				0.0f,
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, limit.zMin, limit.zMax)
				);

		}
	
	}
}
