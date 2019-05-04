using UnityEngine;
using UnityEngine.UI;

// should provide a debug map

namespace utils {
	class DebugHelper : Singleton<DebugHelper> {
		private static GameObject goAnchor;
		private static Text debugLog;

		public DebugHelper() {
			// do nothing
		}

		public static void init(GameObject goAnchor) {
			Singleton<DebugHelper>.init();
			DebugHelper.goAnchor = goAnchor;
			debugLog = goAnchor.GetComponentInChildren<Text>();
		}

		public void ShowPosOnScreen(Vector3 pos) {
			debugLog.text = "(" + pos.x.ToString("0.00") + ", " + pos.y.ToString("0.00") + ")";
		}

		public void ShowLogOnScreen(string log) {
			debugLog.text = log;
		}

		public void PrintLog(object log) {
			Debug.Log(log);
		}
	}
}