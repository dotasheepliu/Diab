using UnityEngine;
using System.Collections;

public class dogmove : MonoBehaviour {
	public float speed;
	private Vector3 transp;
	private Vector3 finalp;
	private float speedx;
	private float speedz;
	public bool doglock = false;
	void OnEnable () {
		EasyTouch.On_DoubleTap += EasyTouch_On_DoubleTap;
	}

	void EasyTouch_On_DoubleTap (Gesture gesture) {
		if (!doglock) {
			doglock = true;
			finalp = gesture.GetCurrentPickedObject ().transform.position;
			transp = finalp - transform.position;
			GetComponent<Animation> ().Play ("Walk Dog");
			StartCoroutine (slowmove ());
		}
	}

	IEnumerator slowmove () {
		transform.LookAt (new Vector3 (finalp.x, transform.position.y, finalp.z));
		speedx = Mathf.Cos (Mathf.Atan (transp.z / transp.x)) * speed;
		if (transp.x < 0)
			speedx = -speedx;
		speedz = Mathf.Sin (Mathf.Atan (transp.z / transp.x)) * speed;
		if (transp.z < 0)
			speedz = -Mathf.Abs (speedz);
		else
			speedz = Mathf.Abs (speedz);
		Debug.Log (speedz);
		for (int i = 0; i < Mathf.Abs (transp.x / speedx); i++) {
			yield return new WaitForSeconds (0.01f);
			transform.position = new Vector3 (transform.position.x + speedx, transform.position.y + 0.001f, transform.position.z + speedz);
		}
		GetComponent<Animation> ().Play ("Idle Dog");
		doglock = false;
	}
}
