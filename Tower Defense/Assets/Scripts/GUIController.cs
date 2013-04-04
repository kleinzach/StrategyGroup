using UnityEngine;
using System.Collections;

//hwe2
public class GUIController : MonoBehaviour {

	public GUIStyle style;
	
	GameMaster gm;
	
	// Use this for initialization
	void Start () {
		gm = (GameMaster)GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameMaster));
	}
	
	void FixedUpdate(){
	}
	
	// On GUI is called every frame, regardless of timescale
	void OnGUI () {	

		//When its on main menu, we wont bother showing score, pause, or hints.
		if(gm.onMainMenu){
			displayMainMenu();
		}
		else{
			//Display the Health and money
			GUI.Box(new Rect(0, 0, 50, 50), gm.remainingHealth.ToString(), style);
			GUI.Box(new Rect(Screen.width - 50, 0, 50, 50), gm.money.ToString(), style);
			
			//pause
			if(gm.isPaused){
				displayPauseMenu();
			}
		}
		
	}
	
	//Shows the main menu
	void displayMainMenu(){
		//Display Title
		GUI.Box(new Rect(0, 0, Screen.width, 60), "Tower Defense", style);
		
		//Display the menu
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 400));
		//Start button
		if(GUI.Button (new Rect (20,0,160,50), "Start game", style)){
			gm.Reset();
		}
		//Options button
		if(GUI.Button (new Rect (20,80,160,50), "Options", style)){
			toggleOptions();
		}
		//Exit button
		if(GUI.Button (new Rect (20,120,160,50), "Exit Game", style)){
			Application.Quit();
		}
		if(gm.optionsPaneOpen){
			displayOptions();
		} 
		GUI.EndGroup();
	}
	
	//Display the options submenu, within the group in the Main Menu
	void displayOptions(){
		//button to change difficulty
		if(GUI.Button (new Rect (270,0,160,50), gm.difficulty.ToString(), style)){
			gm.incrementDifficulty();
		}		
	}
	
	//Open or close the options submenu
	void toggleOptions(){
		if(gm.optionsPaneOpen){
			gm.optionsPaneOpen = false;
		}
		else{
			gm.optionsPaneOpen = true;
		}
	}
	
	//Draws the pause menu
	void displayPauseMenu(){
		GUI.BeginGroup (new Rect (Screen.width / 2 - 80, Screen.height / 2 - 80, 160, 160));
		if(GUI.Button (new Rect (20,0,120,40), "Resume", style)){
			gm.togglePause();
		}
		if(GUI.Button (new Rect (20,60,120,40), "Main Menu", style)){
			gm.goToMainMenu();		}
		if(GUI.Button (new Rect (20,120,120,40), "Exit Game", style)){
			Application.Quit();
		}
		GUI.EndGroup();
	}
	
}
