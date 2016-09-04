using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// 残り時間初期値
	public int timeLimit = 30;
	private Text text;

	// 残り時間
	private float timeRemaining;

	// タイマー動作フラグ
	private bool timerStarted;

	// Use this for initialization
	void Start () {
		this.text = this.GetComponent<Text> ();
		this.ResetTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.timerStarted) {
			this.timeRemaining -= Time.deltaTime;
			if (this.timeRemaining <= 0) {
				this.timeRemaining = 0;
				this.timerStarted = false;
			}
		}

		this.text.text = "Timer:" + this.timeRemaining;
	}

	public void ResetTimer() {
		this.timeRemaining = this.timeLimit;
		this.timerStarted = false;
	}

	public void StartTimer() {
		this.timerStarted = true;
	}

	public void StopTimer() {
		this.timerStarted = false;
	}

	public float GetTimeRemaining() {
		return this.timeRemaining;
	}
}
