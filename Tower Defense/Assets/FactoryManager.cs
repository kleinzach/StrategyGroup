using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Manages all of the different factories i'm going to create.
public class FactoryManager : MonoBehaviour {
	
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
		factories.Add (name,new GenericFactory(product,recycleDelay));
	}
	
	/// <summary>
	/// Create the specified object.
	/// </summary>
	/// <param name='objectName'>
	/// The object's name.
	/// </param>
	public GameObject create(string objectName){
		return factories[objectName].create();	
	}
}
