using UnityEngine;

namespace utils {
	public interface ITouchController {
		void touchOperation(Vector2 pos, bool isTouch);
	}

	public class InputManager : Singleton<InputManager> {
		private Vector2 touchPos;
		private bool isTouch;
		private delegate void InputHandler (Vector2 pos, bool isTouch);
		private event InputHandler inputEvent;

		public void RegisterTouchInput(ITouchController obj) {
			inputEvent += obj.touchOperation;
		}

		public void Update() {
			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}