using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float moveSpeed = 1;
	
	public float xPosition = 0;
	public float yPosition = 0;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
		float xMove = moveSpeed * Input.GetAxis("Horizontal");
		float yMove = moveSpeed * Input.GetAxis("Vertical");
		this.transform.Translate (new Vector3(xMove,yMove,0));
		this.xPosition = Mathf.Round(transform.position.x);
		this.yPosition = Mathf.Round(transform.position.y);
	}
}
