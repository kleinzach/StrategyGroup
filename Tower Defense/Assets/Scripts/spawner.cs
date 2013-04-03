using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public GameObject enemy;
	public float spawnRate;
	public bool canSpawn;
	
	// Update is called once per frame
	void Update () {		
		SendMessage("SpawnEnemy");
	}
	
	IEnumerator SpawnEnemy () {
		if (canSpawn) {
			canSpawn = false;
			Instantiate(enemy, transform.position, transform.rotation);
			yield return new WaitForSeconds(spawnRate);
			canSpawn = true;
		}
	}
}
