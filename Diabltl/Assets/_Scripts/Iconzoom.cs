using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class Iconzoom : MonoBehaviour {
	public GameObject maincam;
	public GameObject dog;
	public void Test () {
		StartCoroutine (focusdog());
	}

	IEnumerator focusdog () {
		EasyTouch.SetEnabled (false);

		Vector3 endposition = new Vector3 (dog.transform.position.x - maincam.transform.position.y / 2f, maincam.transform.position.y, dog.transform.position.z + maincam.transform.position.y / 2f);
		Vector3 moveposition = endposition - maincam.transform.position;
		for (int i = 0; i < 33; i++) {
			yield return new WaitForSeconds (0.01f);
			maincam.transform.position = new Vector3 (maincam.transform.position.x + moveposition.x * 0.03f, maincam.transform.position.y, maincam.transform.position.z + moveposition.z * 0.03f);
		} 
		EasyTouch.SetEnabled (true);
		maincam.AddComponent<HighlightingRenderer> ();
		dog.AddComponent<CSHighlighterController> ();
		yield return new WaitForSeconds (1f);
		Destroy (dog.GetComponent<CSHighlighterController> ());
		Destroy (dog.GetComponent<Highlighter> ());
		Destroy (maincam.GetComponent<HighlightingRenderer> ());
	}
		
}
