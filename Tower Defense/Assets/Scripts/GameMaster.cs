using UnityEngine;
using System;

// hwe2
public class GameMaster : MonoBehaviour {
	
	public FactoryManager factory;
	
	public int gridWidth = 20;
	public int gridHeight = 10;
	
	public int startingMoney = 10;
	public int money = 10;
	
	public int wallCost = 2;
	public int towerCost = 2;
	public int upgradeCost = 2;
	
	public static int startingHealth = 20;
	public int remainingHealth = 20;
	
	private GameObject[,] grid;
	
	public int difficulty = 1;
	public int maxDifficulty = 5;
	
	//Parameters controlling the enemy waves.
	private int currentWave = 1;
	public int stage = 1;
	
	public enemy[] possibleEnemies;
	
	//GUI Things
	public bool onMainMenu = true;
	public bool optionsPaneOpen = false;
	public bool isPaused = false;
	
	// Use this for initialization
	void Start () {
		GameObject go = new GameObject();
		factory = go.AddComponent<FactoryManager>();
		grid = new GameObject[gridWidth,gridHeight];
		
		GameObject[] blockers = (GameObject[])FindObjectsOfType(typeof(GridBlocker));
		for(int i = 0; i < blockers.Length; i++){
			grid[(int)blockers[i].transform.position.x,
				(int)blockers[i].transform.position.z] = blockers[i];	
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	//Places a Tower at the desired location.
	public bool placeTower(int x, int z){
		bool canPlace = true;
		canPlace &= (money > wallCost);
		canPlace &= (0 <= x) && (x < gridWidth);
		canPlace &= (0 <= z) && (z  < gridHeight);
		if(canPlace){
			canPlace &= (grid[x,z] == null);
		}
		if(canPlace){
			GameObject newTower = factory.create("Wall");
			newTower.transform.position = new Vector3(x,0,z);
			grid[x,z] = newTower;
		}
		return canPlace;
	}
	
	/// <summary>
	/// Upgrades the tower.
	/// </summary>
	/// <returns>
	/// If the tower was upgraded.
	/// </returns>
	/// <param name='x'>
	/// x positoin.
	/// </param>
	/// <param name='z'>
	/// z position.
	/// </param>
	/// <param name='element'>
	/// The element to upgrade using.
	/// </param>
	public bool upgradeTower(int x, int z, string element){
		return false;
	}
	
	public bool sellTower(int x, int z){
		GameObject towerToSell = grid[x,z];
		try{
			towerToSell.GetComponent<GridBlocker>();
			return false;		
		}
		catch(Exception e){}
		grid[x,z] = null;
		//towerToSell.sell(); *********************************************************************************************
		return true;
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
			return grid[x,z];	
		}
		catch(Exception e){
			return null;	
		}
	}
	
	/// <summary>
	/// shows it the point is in bounds.
	/// </summary>
	/// <returns>
	/// Whether it is in.
	/// </returns>
	/// <param name='x'>
	/// The x coordinate.
	/// </param>
	/// <param name='z'>
	/// The z coordinate.
	/// </param>
	public bool inBounds(int x, int z){
		return((0 <= x && x < gridWidth)&&(0 <= z && z < gridHeight));	
	}
	
	public void Reset(){
		money = startingMoney;
		remainingHealth = startingHealth;
		Application.LoadLevel(Application.loadedLevelName);
	}
	
	public void incrementDifficulty(){
		this.difficulty++;
		if (difficulty >= maxDifficulty){
			difficulty = 1;	
		}
	}
	
	public void togglePause(){
		if(this.isPaused){
			isPaused = false;	
		}
		else{
			isPaused = true;	
		}
	}
	
	public void goToMainMenu(){
		onMainMenu = true;
		Reset ();
		
	}
}
