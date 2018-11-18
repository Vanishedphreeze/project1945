using UnityEngine;
using UnityEngine.UI;

namespace utils {
	class DebugHelper : Singleton<DebugHelper> {
		private Text debugLog;

		public static void ShowPosOnScreen(Vector3 pos) {
			debugLog.text = "(" + pos.x.ToString("0.00") + ", " + pos.y.ToString("0.00") + ")";
		}

		public static void ShowLogOnScreen(string log) {
			debugLog.text = log;
		}
	}
}