using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour{

	public int scoreValue;
	public int lifeMinus;
	private GameController gameController;
	//private int hp;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
			//hp = gameController.MaxLife;
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player") {
			gameController.LifeMinus (lifeMinus);
			//hp -= lifeMinus;
			if (gameController.MaxLife == 0) {				
				Destroy (other.gameObject);
				gameController.GameOver ();
			}
		}

		gameController.AddScore (scoreValue);
		Destroy (gameObject);


	}
}