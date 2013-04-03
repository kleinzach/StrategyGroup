using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//hwe2
//Manages all of the different factories i'm going to create.
public class FactoryManager {
	
	Dictionary<string,GenericFactory> factories = new Dictionary<string,GenericFactory>();
	public float recycleDelay = 2f;
	
	
	// Use this for initialization
	void Start () {
	}
	
	/// <summary>
	/// Creates a new factory for the product.
	/// </summary>
	/// <param name='name'>
	/// name to find the factory.
	/// </param>
	/// <param name='product'>
	/// Product created by the factory.
	/// </param>
	public void newFactory(string name, GameObject product){
		GenericFactory f = (GenericFactory)ScriptableObject.CreateInstance("GenericFactory");
		f.product = product;
		f.delay = recycleDelay;
		factories.Add (name,f);
	}
	
	/// <summary>
	/// Create the specified object.
	/// </summary>
	/// <param name='objectName'>
	/// The object's name.
	/// </param>
	public GameObject create(string objectName){
		GameObject g = factories[objectName].create();
		Debug.Log (g.name + "************************");
		return g;	
	}
}
