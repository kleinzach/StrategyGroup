using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameMaster gm;
	
	public float moveSpeed = 1;
	public bool nudgable = true;
	
	public int xPosition = 0;
	public int zPosition = 0;
	
	public GameObject ghostTower;
	public GameObject towerToPlace;
	private bool towerPlaced = false;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
		//Determine movement for the cursor
		float xMove = moveSpeed * Input.GetAxis("Horizontal");
		float zMove = moveSpeed * Input.GetAxis("Vertical");
		
		Vector3 nudgeVector = new Vector3(0,0,0);
		float horizontalNudge = Input.GetAxis("Nudge Horizontal");
		float verticalNudge = Input.GetAxis("Nudge Vertical");
		if(nudgable && horizontalNudge > .5){
			nudgeVector += new Vector3(1,0,0);
			nudgable = false;
		}
		else if(nudgable && horizontalNudge < -.5){
			nudgeVector += new Vector3(-1,0,0);
			nudgable = false;
		}
		else if(nudgable && verticalNudge > .5){
			nudgeVector += new Vector3(0,0,1);
			nudgable = false;	
		}
		else if(nudgable && verticalNudge < -.5){
			nudgeVector += new Vector3(0,0,-1);
			nudgable = false;	
		}
		if(!nudgable && Mathf.Abs(horizontalNudge) + Mathf.Abs(verticalNudge) < .5){
			nudgable = true;	
		}
		
		Vector3 oldPosition = new Vector3(this.xPosition, 0, this.zPosition);
		this.transform.Translate (new Vector3(xMove,0,zMove) + nudgeVector);
		
		this.xPosition = (int) Mathf.Round(transform.position.x);
		this.zPosition = (int) Mathf.Round(transform.position.z);
		
		if(!gm.inBounds(xPosition,zPosition)){
			this.transform.position = new Vector3(oldPosition.x, 0, oldPosition.z);
			this.xPosition = (int) Mathf.Round(transform.position.x);
			this.zPosition = (int) Mathf.Round(transform.position.z);
		}
		
		//Move the ghost tower to the tile the cursor is in.
		ghostTower.transform.position = new Vector3(xPosition,0,zPosition);
		
		//Require a new click for each new tower.
		if(!towerPlaced && Input.GetAxis("Place Tower") >= .5){
			towerPlaced = gm.placeTower(xPosition,zPosition,towerToPlace);
		}
		if(towerPlaced && Input.GetAxis("Place Tower") <= .5){
			towerPlaced = false;	
		}
	}
}
