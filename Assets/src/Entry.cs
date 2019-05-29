using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using utils;

using System;

public class Entry : MonoBehaviour, ITouchController {
	private Vector2 pos;

	// these for player's state machine
	private enum PlayerState {
		SLEEP,
		ACTIVE,
		STATE_NUM // for counting number
	}

	// test for closure
	int tempOutFunc = 0;
	StateMachine foo = new StateMachine(1);
	StateMachine bar = new StateMachine(1);


	// Use this for initialization
	void Awake() {
		InitRandomGenerator();
		DebugHelper.init(gameObject);
		InputManager.init();

		InputManager.Instance.RegisterTouchEvent(this);

		// these for player's state machine
		// StateMachine player = new StateMachine((int) PlayerState.STATE_NUM, (int) PlayerState.ACTIVE);

		// player.SetUpdateFunc((int) PlayerState.SLEEP, () => {
		// 	Debug.Log("sleep.");
		// });
		// player.SetTransitionFunc((int) PlayerState.SLEEP, () => {
		// 	Debug.Log("go active!");
		// 	return (int) PlayerState.ACTIVE;
		// });

		// player.SetUpdateFunc((int) PlayerState.ACTIVE, () => {
		// 	Debug.Log("active!");
		// });
		// player.SetTransitionFunc((int) PlayerState.ACTIVE, () => {
		// 	Debug.Log("fall asleep.");
		// 	return (int) PlayerState.SLEEP;
		// });

		// test for closure
		int tempInFunc = 0;
		foo.SetUpdateFunc(0, () => {
			tempInFunc++;
			tempOutFunc++;
			Debug.Log("foo " + tempInFunc.ToString() + tempOutFunc.ToString());
		});
		bar.SetUpdateFunc(0, () => {
			tempInFunc++;
			tempOutFunc++;
			Debug.Log("bar " + tempInFunc.ToString() + tempOutFunc.ToString());
		});
		Debug.Log("out " + tempInFunc.ToString() + tempOutFunc.ToString());

		// foo 11 foo 22 bar 33 bar 44 out 44
	}

	void Start() {
		foo.Update();
		foo.Update();
		bar.Update();
		bar.Update();
	}

	// Update is called once per frame
	void Update() {
		InputManager.Instance.Update();
	}

	public void OnTouchInput(Vector2 pos, bool isTouch) {
		DebugHelper.Instance.ShowPosOnScreen(pos);
	}
}