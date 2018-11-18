using UnityEngine;

namespace utils {
	public interface ITouchController {
		void touchOperation(Vector2 pos, bool isTouch);
	}

	public class InputManager : Singleton<InputManager> {
		private static Vector2 touchPos;
		private static bool isTouch;
		private delegate void InputHandler (Vector2 pos, bool isTouch);
		private static event InputHandler inputEvent;

		public void RegisterTouchInput(ITouchController obj) {
			inputEvent += obj.touchOperation;
		}

		public void Update() {
			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}