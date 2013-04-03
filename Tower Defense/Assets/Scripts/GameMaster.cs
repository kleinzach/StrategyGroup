using UnityEngine;
using System;

// hwe2
public class GameMaster : MonoBehaviour {
	
	public FactoryManager factory = new FactoryManager();
	
	public int gridWidth = 20;
	public int gridHeight = 10;
	
	public int money = 10;
	public int towerCost = 2;
	public int towerUpgrade1Cost = 5;
	public int towerUpgrade2Cost = 10;
	
	private GameObject[,] grid;
	
	public GameObject enemy;
	
	//Parameters controlling the enemy waves.
	private int currentWave = 1;
	public int stage = 1;
	
	public enemy[] possibleEnemies;
	
	// Use this for initialization
	void Start () {
		grid = new GameObject[gridWidth,gridHeight];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	//Places a Tower at the desired location.
	public bool placeTower(int x, int z){
		bool canPlace = true;
		canPlace &= (money > towerCost);
		canPlace &= (-gridWidth/2 <= x) && (x <= gridWidth/2);
		canPlace &= (-gridHeight/2 <= z) && (z  <= gridHeight/2);
		if(canPlace){
			canPlace &= (grid[x + gridWidth/2,z + gridHeight/2] == null);
		}
		if(canPlace){
			GameObject newTower = factory.create("enemy");
			newTower.transform.position = new Vector3(x,0,z);
			grid[x + gridWidth/2,z + gridHeight/2] = newTower;
		}
		return canPlace;
	}
	
	public bool upgradeTower(GameObject tower, int element){
		return false;
	}
	
	/// <summary>
	/// finds the tower at x and z.
	/// </summary>
	/// <returns>
	/// The Tower.
	/// </returns>
	/// <param name='x'>
	/// X position.
	/// </param>
	/// <param name='z'>
	/// Z position.
	/// </param>
	public GameObject towerAt(int x, int z){
		try{
			return grid[x + gridWidth/2,z + gridHeight/2];	
		}
		catch(Exception e){
			return null;	
		}
	}
	
	/// <summary>
	/// shows it the point is in bounds.
	/// </summary>
	/// <returns>
	/// Whetehr it is in.
	/// </returns>
	/// <param name='x'>
	/// The x coordinate.
	/// </param>
	/// <param name='z'>
	/// The z coordinate.
	/// </param>
	public bool inBounds(int x, int z){
		int realx = x + gridWidth/2;
		int realz = z + gridHeight/2;
		return((0 < realx && realx < gridWidth)&&(0 < realz && realz < gridHeight));	
	}
}
