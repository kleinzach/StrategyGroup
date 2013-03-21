using UnityEngine;
using System.Collections;

public class tower_state_FIRE : MonoBehaviour {
	
	public GameObject projectile;
	public Vector3 target_enemyPOS;	
	public bool canFire;
	public float fireRate;
	
	void Start () {
		canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
		SendMessage ("BeginFiringSequence");
	}
	
	IEnumerator BeginFiringSequence () {
		if (canFire) {
			Instantiate (projectile, transform.position, transform.rotation);
			canFire = false;
			yield return new WaitForSeconds (fireRate);
			canFire = true;
		}
	}
}
