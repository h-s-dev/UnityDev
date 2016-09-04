using UnityEngine;
using System.Collections;

public class PanelGenerator : MonoBehaviour {

	public GameObject panelPrefab;

	public float interval = 3.0f;

	private bool spawnStarted = false;

	// Use this for initialization
	void Start () {
		// コルーチンを呼び出す
		this.StartCoroutine ("GenerateDebris");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void StartSpawn() {
		if (!this.spawnStarted) {
			this.spawnStarted = true;
			this.StartCoroutine ("GenerateDebris");
		}
	}

	void StopSpawn() {
		if (this.spawnStarted) {
			this.spawnStarted = false;
			this.StopCoroutine ("GenerateDebris");
		}
	}

	IEnumerator GenerateDebris() {
		while (true) {
			// PanelPrefabのコピーを作成
			// 回転しない状態
			Instantiate(this.panelPrefab, this.transform.position, Quaternion.identity);

			// interval分だけ処理を停止する
			yield return new WaitForSeconds(this.interval);

		}
	}

}
