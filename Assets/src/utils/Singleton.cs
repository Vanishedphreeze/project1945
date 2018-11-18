namespace utils {
	// multi-thread unsafe
	public class Singleton<ClassName> where ClassName: class, new() {  
		private static ClassName _instance;
		public static ClassName Instance {
			get {
				return _instance;
			}
		}

		public static void init() {
			if (_instance == null) {
				_instance = new ClassName();
			}
		}
	}  
}