using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	public GameObject target;
	public Material UIhover;
	Material matLeft, matRight;
	bool targetState;
	Renderer renderLeft, renderRight;
	MeshFilter mf;
	Mesh mesh;
	RaycastHit hit;

	// Use this for initialization
	void Start ()
	{
		targetState = target.activeSelf;

		renderLeft = GameObject.Find("UISphereLeft").GetComponent<Renderer>();
		renderRight = GameObject.Find("UISphereRight").GetComponent<Renderer>();
		mf = GameObject.Find("UISphereRight").GetComponent<MeshFilter>();
		mesh = mf.mesh;
		matLeft = renderLeft.material;
		matRight = renderRight.material;
	}
	
	// Update is called once per frame
	void Update ()
	{
		renderLeft.material = matLeft;
		renderRight.material = matRight;
		mf.mesh = mesh;
		Ray ray = GameObject.Find("UICamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			string name = hit.transform.name;
			if (name == "UISphereLeft") {
				renderLeft.material = UIhover;

				if (Input.GetMouseButtonDown(0)) {

					targetState = !targetState;
					target.SetActive(targetState);
				}
			}
			if (name == "UISphereRight") {
				renderRight.material = UIhover;
				GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				mf.mesh = obj.GetComponent<MeshFilter>().mesh;
				Destroy(obj);

				if (Input.GetMouseButtonDown(0)) {
					target.SetActive(targetState);
					if (target.transform.localScale == Vector3.one) {
						target.transform.localScale = Vector3.one * 1.5f;
					} else {
						target.transform.localScale = Vector3.one;
					}
				}
			}
		}
	}
}
