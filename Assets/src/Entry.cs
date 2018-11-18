using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using utils;

public class Entry : MonoBehaviour {
	// private Text debugLog;
	private Vector2 pos;

	// Use this for initialization
	void Start() {
		// debugLog = gameObject.GetComponentInChildren<Text>();
		// Debug.Log(Camera.main.rect);
		DebugHelper.init();
		// InputManager
	}

	// Update is called once per frame
	void Update() {
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// ShowPosOnScreen(pos);
		DebugHelper.Instance.ShowPosOnScreen(pos);
	}

}
