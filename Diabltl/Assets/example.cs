using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
	public TextAsset asset;
	void Start() {
		print(asset.text);
	}
}
