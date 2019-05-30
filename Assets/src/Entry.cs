using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using utils;
using project1945;

using System;

public class Entry : MonoBehaviour, ITouchController {
	private Vector2 pos;

	// these for player's state machine
	// private enum PlayerState {
	// 	SLEEP,
	// 	ACTIVE,
	// 	STATE_NUM // for counting number
	// }

	// test for closure
	// int tempOutFunc = 0;
	// StateMachine foo = new StateMachine(1);
	// StateMachine bar = new StateMachine(1);

	// test for object manager
	float restTime = 1;


	// Use this for initialization
	void Awake() {
		Global.InitRandomGenerator();
		DebugHelper.init(gameObject);
		InputManager.init();
		ObjectManager.init();

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
		// int tempInFunc = 0;
		// foo.SetUpdateFunc(0, () => {
		// 	tempInFunc++;
		// 	tempOutFunc++;
		// 	Debug.Log("foo " + tempInFunc.ToString() + tempOutFunc.ToString());
		// });
		// bar.SetUpdateFunc(0, () => {
		// 	tempInFunc++;
		// 	tempOutFunc++;
		// 	Debug.Log("bar " + tempInFunc.ToString() + tempOutFunc.ToString());
		// });
		// Debug.Log("out " + tempInFunc.ToString() + tempOutFunc.ToString());

		// foo 11 foo 22 bar 33 bar 44 out 44
	}

	void Start() {
		// foo.Update();
		// foo.Update();
		// bar.Update();
		// bar.Update();
	}

	// Update is called once per frame
	void Update() {
		// test code
		restTime = restTime - Time.deltaTime;
		if (restTime <= 0) {
			restTime = 1;
			int mark = ObjectManager.Instance.Create();
			ObjectManager.Instance.SetUpdateFunc(mark, () => {
				GameObject gameObj = ObjectManager.Instance.GetGameObject(mark);
				Vector3 speed = new Vector3(0, 1, 0);
				gameObj.transform.localPosition = gameObj.transform.localPosition + speed * Time.deltaTime;
			});
		}

		InputManager.Instance.Update();
		ObjectManager.Instance.Update();
	}

	public void OnTouchInput(Vector2 pos, bool isTouch) {
		DebugHelper.Instance.ShowPosOnScreen(pos);
	}
}