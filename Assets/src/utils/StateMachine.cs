using System;

namespace utils {
	class StateMachine {
		public const int SKIP_TRANSITION = -1;

		struct StateNode {
			public int stateIndex;
			public Action updateFunc;
			public Func<int> transitionFunc;

			public StateNode(int index) {
				stateIndex = index;
				updateFunc = null;
				transitionFunc = () => { 
					return SKIP_TRANSITION; 
				};
			}
		}

		private StateNode[] states;
		private int stateNum;
		private int currStateIdx = 0;
		
		public StateMachine(int stateNum, int currStateIdx = 0) {
			this.stateNum = stateNum;
			this.currStateIdx = currStateIdx;
			states = new StateNode[stateNum];
			for (int i = 0; i < stateNum; i++) {
				states[i] = new StateNode(i);
			}
		}

		public int StateNum {
			get {
				return stateNum;
			}
		}

		public int CurrStateIdx {
			get {
				return currStateIdx;
			}
		}

		public void SetUpdateFunc(int index, Action func) {
			states[index].updateFunc = func;
		}

		public void SetTransitionFunc(int index, Func<int> func) {
			states[index].transitionFunc = func;
		}

		public void Update() {
			int idx = states[currStateIdx].transitionFunc();
			if (idx > 0 && idx < stateNum) {
				currStateIdx = idx;
			}
			if (states[currStateIdx].updateFunc != null) {
				states[currStateIdx].updateFunc();
			} 
		}
	}
}