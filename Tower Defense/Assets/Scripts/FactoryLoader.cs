using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//hwe2, though i wish it wasnt me.
public class FactoryLoader : MonoBehaviour {
	
	public GameMaster gm;
	
	public GameObject Wall;
	public GameObject Fire;
	public GameObject Earth;
	public GameObject Water;
	public GameObject Wind;
	public GameObject FireFire;
	public GameObject FireEarth;
	public GameObject FireWater;
	public GameObject FireWind;
	public GameObject EarthFire;
	public GameObject EarthEarth;
	public GameObject EarthWater;
	public GameObject EarthWind;
	public GameObject WaterFire;
	public GameObject WaterEarth;
	public GameObject WaterWater;
	public GameObject WaterWind;
	public GameObject WindFire;
	public GameObject WindEarth;
	public GameObject WindWater;
	public GameObject WindWind;
	
	public GameObject FireP;
	
	public GameObject fireEnemy;
	public GameObject waterEnemy;
	public GameObject earthEnemy;
	public GameObject windEnemy;
	
	// Use this for initialization
	void Start () {
		gm.factory.newFactory(Wall.name,Wall);
		gm.factory.newFactory(Fire.name,Fire);
		gm.factory.newFactory(Earth.name,Earth);
		gm.factory.newFactory(Water.name,Water);
		gm.factory.newFactory(Wind.name,Wind);
		gm.factory.newFactory(FireFire.name,FireFire);
		gm.factory.newFactory(FireEarth.name,FireEarth);
		gm.factory.newFactory(FireWater.name,FireWater);
		gm.factory.newFactory(FireWind.name,FireWind);
		gm.factory.newFactory(EarthFire.name,EarthFire);
		gm.factory.newFactory(EarthEarth.name,EarthEarth);
		gm.factory.newFactory(EarthWater.name,EarthWater);
		gm.factory.newFactory(EarthWind.name,EarthWind);
		gm.factory.newFactory(WaterFire.name,WaterFire);
		gm.factory.newFactory(WaterEarth.name,WaterEarth);
		gm.factory.newFactory(WaterWater.name,WaterWater);
		gm.factory.newFactory(WaterWind.name,WaterWind);
		gm.factory.newFactory(WindFire.name,WindFire);
		gm.factory.newFactory(WindEarth.name,WindEarth);
		gm.factory.newFactory(WindWater.name,WindWater);
		gm.factory.newFactory(WindWind.name,WindWind);
		
		gm.factory.newFactory(fireEnemy.name, fireEnemy);
		gm.factory.newFactory(waterEnemy.name, waterEnemy);
		gm.factory.newFactory(earthEnemy.name, earthEnemy);
		gm.factory.newFactory(windEnemy.name, windEnemy);
	}
}
