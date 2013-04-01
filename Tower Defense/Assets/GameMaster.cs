using UnityEngine;
using System;

public class GameMaster : MonoBehaviour {
	
	public int gridWidth = 20;
	public int gridHeight = 10;
	
	public int money = 10;
	public int towerCost = 2;
	public int towerUpgrade1Cost = 5;
	public int towerUpgrade2Cost = 10;
	
	private GameObject[,] grid;
	
	// Use this for initialization
	void Start () {
		grid = new GameObject[gridWidth,gridHeight];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	public bool placeTower(int x, int z, GameObject towerToPlace){
		bool canPlace = true;
		canPlace &= (money > towerCost);
		canPlace &= (-gridWidth/2 <= x) && (x <= gridWidth/2);
		canPlace &= (-gridHeight/2 <= z) && (z  <= gridHeight/2);
		if(canPlace){
			canPlace &= (grid[x + gridWidth/2,z + gridHeight/2] == null);
		}
		if(canPlace){
			GameObject newTower = (GameObject) Instantiate(towerToPlace,new Vector3(x,0,z),transform.rotation);	
			grid[x + gridWidth/2,z + gridHeight/2] = towerToPlace;
		}
		return canPlace;
	}
	
	public bool upgradeTower(GameObject tower, int element){
		return false;
	}
	
	public GameObject towerAt(int x, int z){
		try{
			return grid[x + gridWidth/2,z + gridHeight/2];	
		}
		catch(Exception e){
			return null;	
		}
	}
}
