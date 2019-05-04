using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class whitebox : MonoBehaviour, ITouchController {
	private SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		sp = gameObject.GetComponentInChildren<SpriteRenderer>();
		InputManager.Instance.RegisterTouchEvent(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTouchInput(Vector2 pos, bool isTouch) {
		gameObject.transform.localPosition = pos;
		if (isTouch) sp.color = Color.red;
		else sp.color = Color.white;
	}
}
