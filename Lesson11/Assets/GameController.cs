using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Image guiTitle;
	public Image guiTimeup;

	public enum GameState {
		Title,
		Playing,
		Timeup,
		TimeupToTitle
	}

	private GameState state;
	private GameObject panelGenerator;
	private GameObject score;
	private Timer timer;

	// Use this for initialization
	void Start () {
		Debug.Log("GameController start");
		this.state = GameState.Title;
		this.guiTitle.enabled = true;
		this.guiTimeup.enabled = false;
		this.panelGenerator = GameObject.Find ("PanelGenerator");
		this.score = GameObject.Find ("Score");
		this.timer = GameObject.Find ("Timer").GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (this.state) {
		case GameState.Title:
			if (Input.GetMouseButtonUp(0)) {
				this.state = GameState.Playing;
				this.panelGenerator.SendMessage ("StartSpawn");
				this.score.SendMessage ("InitScore");
				this.timer.StartTimer ();
				this.guiTitle.enabled = false;
			}
			break;

		case GameState.Playing:
			if (this.timer.GetTimeRemaining() == 0) {
				this.state = GameState.Timeup;
				this.panelGenerator.SendMessage ("StopSpawn");
				this.timer.StopTimer ();
				this.DestoryAllDebris ();
				this.guiTimeup.enabled = true;
			}
			break;

		case GameState.Timeup:
			if (Input.GetMouseButtonUp(0)) {
				this.state = GameState.TimeupToTitle;
				this.StartCoroutine ("ShowTitleDelayed", 3f);
			}
			break;
		default:
			break;
		}
	
	}

	void DestoryAllDebris() {
		GameObject[] debris = GameObject.FindGameObjectsWithTag ("debri");
		foreach (GameObject debri in debris) {
			Destroy (debri);
		}

	}

	IEnumerator ShowTitleDelayed(float delayTime) {
		yield return new WaitForSeconds (delayTime);
		this.state = GameState.Title;
		this.timer.ResetTimer ();
		this.guiTitle.enabled = true;
		this.guiTimeup.enabled = false;
	}
}
