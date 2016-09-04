using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int score;
	private Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		this.text = this.GetComponent<Text> ();
	}

	void InitScore() {
		this.score = 0;
		this.UpdateText ();
	}

	void AddScore(int score) {
		this.score += score;
		this.UpdateText ();
	}

	void UpdateText() {
		this.text.text = "score:" + this.score;
	}
}
