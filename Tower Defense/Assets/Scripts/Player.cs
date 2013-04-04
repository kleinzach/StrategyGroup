using UnityEngine;
using System.Collections;

//hwe2
public class Player : MonoBehaviour {
	
	public GameMaster gm;
	
	public float moveSpeed = 1;
	public bool nudgable = true;
	
	public int xPosition = 0;
	public int zPosition = 0;
	
	public GameObject ghostTower;
	private bool towerPlaced = false;
	private bool upgraded = true;
	private bool towerDestroyed = false;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Fixed Update is called once per physics frame
	void FixedUpdate () {
		handleMovement();
		
		//Move the ghost tower to the tile the cursor is in.
		ghostTower.transform.position = new Vector3(xPosition,0,zPosition);
		
		handlePlace();
		
		handleUpgrade();
	}
	
	private void handleMovement(){
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
	}
	
	//Require a new click for each new tower.
	private void handlePlace(){
		//Building
		if(!towerPlaced && Input.GetAxis("Place Tower") >= .5){
			towerPlaced = gm.placeTower(xPosition,zPosition);
		}
		else if(towerPlaced && Input.GetAxis("Place Tower") <= .5){
			towerPlaced = false;	
		}
		
		//Selling
		if(!towerDestroyed && Input.GetAxis("Sell Tower") >= .5){
			towerDestroyed = gm.sellTower(xPosition,zPosition);
		}
		else if(towerDestroyed && Input.GetAxis("Sell Tower") <= .5){
			towerDestroyed = false;	
		}
	}
	
	//Upgrade a tower if a button is pressed
	private void handleUpgrade(){
		if(gm.towerAt(xPosition,zPosition) != null){
			if(Input.GetAxis("Fire")>.5){
				upgraded = gm.upgradeTower(xPosition,zPosition,"Fire");
			}
			else if(Input.GetAxis("Earth")>.5){
				upgraded = gm.upgradeTower(xPosition,zPosition,"Earth");
			}
			else if(Input.GetAxis("Water")>.5){
				upgraded = gm.upgradeTower(xPosition,zPosition,"Water");
			}
			else if(Input.GetAxis("Wind")>.5){
				upgraded = gm.upgradeTower(xPosition,zPosition,"Wind");
			}
		}
		else{
			upgraded = false;	
		}
	}
}
