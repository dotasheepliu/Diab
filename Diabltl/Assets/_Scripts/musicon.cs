using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class musicon : MonoBehaviour {
	bool isplay = false;
	public GameObject maincam;

	void Update () {
		if ((GetComponent<Slider> ().value > 0) && isplay == false) {
			maincam.GetComponent<AudioSource> ().Play ();
			isplay = true;
		}
			
		if ((GetComponent<Slider> ().value == 0) && isplay == true) {
			maincam.GetComponent<AudioSource> ().Stop ();
			isplay = false;
		}
	}
}
