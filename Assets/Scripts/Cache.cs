using System.Collections.Generic;

public static class Cache<T>
{
	public static readonly HashSet<T> Instances = new HashSet<T>();
}
