using System;
using System.Collections.Generic;
using UnityEngine;
using utils;

namespace project1945 {
	public class ObjectManager : Singleton<ObjectManager> {
		class strObj {
			public int mark;
			public GameObject gameObj;
			public Action updateFunc;

			public strObj(int mark, GameObject gameObj) {
				this.mark = mark;
				this.gameObj = gameObj;
				updateFunc = null;
			}
		}

		private static Dictionary<int, strObj> objMap = new Dictionary<int, strObj>();
		private static GameObject prefab;

		public ObjectManager() {
			// do nothing
		}

		public new static void init() {
			Singleton<ObjectManager>.init();
			prefab = (GameObject)Resources.Load("Prefabs/BaseObject");
		}

		public int Create() {
			int mark = Global.GetRandomInt();
			strObj obj = new strObj(mark, UnityEngine.Object.Instantiate(prefab));
			objMap.Add(mark, obj);
			return mark;
		}

		public void Destroy(int mark) {
			UnityEngine.Object.Destroy(objMap[mark].gameObj);
			objMap.Remove(mark);
		}

		public GameObject GetGameObject(int mark) {
			return objMap[mark].gameObj;
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