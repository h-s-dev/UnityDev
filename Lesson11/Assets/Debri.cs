using UnityEngine;
using System.Collections;

public class Debri : MonoBehaviour {
	public float angle = 30f;
	public int score = 10;

	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		var target = GameObject.Find ("Earth").transform;
		this.targetPos = target.position;

		// 宇宙ゴミの正面をEarthに向ける
		this.transform.LookAt (target);

		this.transform.Rotate (new Vector3 (0, 0, Random.Range (0, 360)), Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		var axis = this.transform.TransformDirection (Vector3.up);

		// ワールド座標の point を中心とした軸( axis )で angle 度回転させます
		this.transform.RotateAround (this.targetPos, axis, angle * Time.deltaTime);
	}

	void OnMouseDown() {
		GameObject.Find ("Score").SendMessage ("AddScore", score);
		Destroy (this.gameObject);
	}
}
