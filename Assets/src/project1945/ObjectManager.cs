using UnityEngine;
using utils;

namespace project1945 {
	public class ObjectManager : Singleton<ObjectManager> {
		struct strObj {
			public int mark;
			public Vector3 position;
			public GameObject gameObj;
			public Action updateFunc;

			public strObj(int mark) {
				mark = mark;
				// instantiate 
				updateFunc = () => { 
					// setting local position instead of global position
					gameObj.transform.localPosition = position;
				};
			}
		}

		private static Dictionary<int, strObj> objMap = new Dictionary<int, strObj>();
		private static GameObject prefab;

		public ObjectManager() {
			// do nothing
		}

		public static void init() {
			Singleton<ObjectManager>.init();
			// prefab = (GameObject)Resources.Load("Prefabs/HP_Bar");
		}

		public int Create() {
			int mark = GetRandomInt();
			strObj obj = new strObj(mark);
			// change this while using object pool.
			// obj.gameObj = Instantiate(prefab, pos, rotation);

			// attention : whether add option is copying structure
			objMap.Add(mark, obj);
		}

		public void SetUpdateFunc(int mark, Action func) {
			objMap[mark].updateFunc = func;
		}

		public void Update() {
			foreach (var obj in objMap) if (obj.Value.updateFunc != null) {
				obj.Value.updateFunc();
			}
		}
	}
}