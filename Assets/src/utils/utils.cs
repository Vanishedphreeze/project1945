using System;

namespace utils {
	public static class Global {
		static private Random globalRandomGenerator;

		static public void InitRandomGenerator() {
			globalRandomGenerator = new Random(System.DateTime.Now.Millisecond);
		}

		static public void InitRandomGenerator(int seed) {
			globalRandomGenerator = new Random(seed);
		}

		static public int GetRandomInt() {
			return globalRandomGenerator.Next();
		}

		static public int GetRandom(int n) {
			return globalRandomGenerator.Next(n);
		}

		static public int GetRandomInRange(int m, int n) {
			return globalRandomGenerator.Next(m, n);
		}
	}
}