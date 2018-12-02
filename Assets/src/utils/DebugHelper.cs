using UnityEngine;
using UnityEngine.UI;

namespace utils {
	class DebugHelper : Singleton<DebugHelper> {
		private static GameObject goDebugLog;
		private static Text debugLog;

		public DebugHelper() {
			Singleton<DebugHelper>.init();
			debugLog = goDebugLog.GetComponentInChildren<Text>();
		}

		public void ShowPosOnScreen(Vector3 pos) {
			debugLog.text = "(" + pos.x.ToString("0.00") + ", " + pos.y.ToString("0.00") + ")";
		}

		public void ShowLogOnScreen(string log) {
			debugLog.text = log;
		}
	}
}