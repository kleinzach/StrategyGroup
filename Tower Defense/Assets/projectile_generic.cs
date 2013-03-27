using UnityEngine;
using System.Collections;

public class projectile_generic : MonoBehaviour {
	
	public float velocity;
	public GameObject targetEnemy;
	public float targety;
	public float targetx;
	public float targetz;
	public float lifeSpan;

	// Use this for initialization
	void Start () {
		SendMessage ("FindEnemy");
		SendMessage ("DestroySelf");
	}
	
	void Update () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		if (targetx > transform.position.x && targety > transform.position.y)
			transform.Translate (velocity * Time.fixedDeltaTime, velocity * Time.fixedDeltaTime, 0);
		
		if (targetx > transform.position.x && targety < transform.position.y)
			transform.Translate (velocity * Time.fixedDeltaTime, -velocity * Time.fixedDeltaTime, 0);
		
		if (targetx < transform.position.x && targety > transform.position.y)
			transform.Translate (-velocity * Time.fixedDeltaTime, velocity * Time.fixedDeltaTime, 0);
		
		if (targetx < transform.position.x && targety < transform.position.y)
			transform.Translate (-velocity * Time.fixedDeltaTime, -velocity * Time.fixedDeltaTime, 0);
	}
	
	void FindEnemy () {
		targetEnemy = GameObject.FindGameObjectWithTag ("Enemy");
		targetx = targetEnemy.transform.position.x;
		targety = targetEnemy.transform.position.y;
		targetz = targetEnemy.transform.position.z;
	}
	
	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Enemy") {
			targetEnemy.SendMessage ("GotHit");
			Destroy (gameObject);
		}
	}
	
	IEnumerator DestroySelf () {
		yield return new WaitForSeconds (lifeSpan);
		Destroy (gameObject);
	}
}
