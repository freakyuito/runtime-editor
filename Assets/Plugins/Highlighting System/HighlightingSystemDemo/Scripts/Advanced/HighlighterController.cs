using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class HighlighterController : MonoBehaviour {

	protected Highlighter h;

	protected void Awake() {
		h = GetComponent<Highlighter>();
		if (h == null) { h = gameObject.AddComponent<Highlighter>(); }
	}

	void OnEnable () {}

	protected void Start () {}

	protected void Update () {}


	public void MouseOver () {}

	void OnMouseEnter(){
		h.ConstantOn ();

	}

	void OnMouseExit (){
		h.ConstantOff ();
	}

	public void hint(){
		h.ConstantOn ();
	}

	public void Fire1 () {}

	public void Fire2 (){}
}