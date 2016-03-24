using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public Ray ray;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, 10000))
			print("Hit something");

	}
}
