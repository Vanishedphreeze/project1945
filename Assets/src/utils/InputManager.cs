using UnityEngine;

namespace utils {
	public interface ITouchController {
		void OnTouchInput(Vector2 pos, bool isTouch);
	}

	public class InputManager : Singleton<InputManager> {
		private static Vector2 touchPos;
		private static bool isTouch;
		private delegate void InputHandler (Vector2 pos, bool isTouch);
		private static event InputHandler inputEvent;

		public InputManager() {
			// do nothing
		}

		public static void init(GameObject goAnchor) {
			Singleton<InputManager>.init();
		}

		public void RegisterTouchEvent(ITouchController obj) {
			inputEvent += obj.OnTouchInput;
		}

		public void UnregisterTouchEvent(ITouchController obj) {
			inputEvent -= obj.OnTouchInput;
		}

		// public void ClearAllTouchEvent() {

		// }

		public void Update() {
			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			isTouch = Input.anyKey;
			inputEvent(touchPos, isTouch);
		}
	}
}