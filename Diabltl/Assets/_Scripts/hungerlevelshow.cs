using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hungerlevelshow : MonoBehaviour {

	Vector2 offsetMax;
	public GameObject text;
	void Start () {
		offsetMax = GetComponent<RectTransform> ().offsetMax;
		GetComponent<RectTransform> ().offsetMax = new Vector2 (0f, offsetMax.y);
		text.GetComponent<Text> ().text = "Hunger " + (200f / 2f).ToString () + "%"; 
	}

	public void sugarlevelminusone () {
		offsetMax = GetComponent<RectTransform> ().offsetMax;
		GetComponent<RectTransform> ().offsetMax = new Vector2 (offsetMax.x - 1f, offsetMax.y);
		text.GetComponent<Text> ().text = "Hunger " + ((200f + GetComponent<RectTransform> ().offsetMax.x) / 2f).ToString () + "%"; 
	}
}
