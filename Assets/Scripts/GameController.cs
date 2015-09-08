using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWaitTimer;
	public float spawnWaitTimer;
	public float wavesWaitTimer;
	public Text gameOverText;
	public Text restartText;
	public Text scoreText;
	public float speed;
	
	public Text leftText;
	public Text leftTopText;
	public Text leftBottomText;

	
	public Text rightText;
	public Text rightTopText;
	public Text rightBottomText;
	
	public Text highScoreText;

	private bool menu;
	private bool gameOver;
	private bool restart;
	private float score;
	private float highscore;

	static private string scorePath = Application.persistentDataPath + "/score.sori";


	void UpdateHighScore()
	{
		System.IO.File.WriteAllText (scorePath, score.ToString());
		highscore = score;
		highScoreText.text = highscore.ToString ();
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R))
			{
				reset();
				menu = false;
			}
	
			if (Input.touchCount > 0)
			{
				reset();
				menu = false;
			}
		}
		if (gameOver == true)
		{
			restart = true;
			restartText.text = "Restart";
		}
		if (menu == true) {
			if (Input.GetKeyDown (KeyCode.R)) {
				menu = false;
				hideMenu();
			}

			if (Input.touchCount > 0) {
				menu = false;
				hideMenu();
			}
		}
	}

	void Start()
	{
		if (System.IO.File.Exists (scorePath))
			float.TryParse (System.IO.File.ReadAllText(scorePath), out highscore);
		else {
			System.IO.File.Create(scorePath).Close();
			System.IO.File.WriteAllText (scorePath, "0");
			highscore = 0;
		}	
		highScoreText.text = highscore.ToString ();
		score = 0;
		scoreText.text = "0";
		gameOver = false;
		restart = false;
		menu = true;
		speed = -5;
		gameOverText.text = "";
		restartText.text = "";
		StartCoroutine (SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWaitTimer);
		Vector3 spawnPosition;
		Quaternion spawnRotation;
		int i;

		while (true) {
			if (menu == false && gameOver == false) {
				i = 0;
				while (i < (hazardCount + (score / 20))) {
					if (menu == true || gameOver == true)
						break;
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = new Quaternion ();
					spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
					i++;
					yield return new WaitForSeconds (((spawnWaitTimer - (score / 200)) > 0 ? spawnWaitTimer - (score / 200) : 0));
				}
				if (menu == false && gameOver == false)
					yield return new WaitForSeconds (wavesWaitTimer - (score / 100));
			}
			yield return(0);
		}
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public bool getGameOver()
	{
		return gameOver;
	}

	public bool getMenu()
	{
		return menu;
	}

	public bool getRestart()
	{
		return restart;
	}

	public void addScore()
	{
		score++;
		scoreText.text = score.ToString();
		speed = speed  - (score / 20);
	}

	public float getSpeed()
	{
		return speed;
	}

	void reset()
	{
		if (score > highscore)
			UpdateHighScore();
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		speed = -5;
		scoreText.text = score.ToString();
		gameOver = false;
		restart = false;
	}

	void hideMenu()
	{
		leftBottomText.text = "";
		leftTopText.text = "";
		leftText.text = "";

		
		rightBottomText.text = "";
		rightTopText.text = "";
		rightText.text = "";
	}
}
