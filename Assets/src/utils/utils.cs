using System;

namespace utils {
	private Random globalRandomGenerator;

	public void InitRandomGenerator(int seed = System.DateTime.Now.Millisecond) {
		globalRandomGenerator = new Random(seed);
	}

	public int GetRandomInt() {
		return globalRandomGenerator.Next();
	};

	public int GetRandom(int n) {
		return globalRandomGenerator.Next(n);
	};

	public int GetRandomInRange(int m, int n) {
		return globalRandomGenerator.Next(m, n);
	};

}