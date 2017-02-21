using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject[] enemy;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int MaxLife;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText lifeText;

	private int score;
	private int n;
	private bool gameOver;
	private bool restart;
	//private int hp;
	private bool death;

	void Start (){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		//hp = MaxLife;
		lifeText.text = "Life: " + MaxLife;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
				//Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		enemy = new GameObject[3];
		enemy [0] = enemy1;
		enemy [1] = enemy2;
		enemy [2] = enemy3;

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				int n = Random.Range (0,3);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy[n],spawnPosition,spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		gameOverText.text = "Game Over!!";
		gameOver = true;
	}

	public void LifeMinus(int minus){
		MaxLife -= minus;
		lifeText.text = "Life: " + MaxLife;
	}
			
}