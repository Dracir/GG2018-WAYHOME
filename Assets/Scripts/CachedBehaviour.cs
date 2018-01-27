using UnityEngine;

public class CachedBehaviour<TSelf> : MonoBehaviour where TSelf : CachedBehaviour<TSelf>
{
	protected virtual void OnEnable()
	{
		Cache<TSelf>.Instances.Add(this as TSelf);
	}

	protected virtual void OnDistable()
	{
		Cache<TSelf>.Instances.Remove(this as TSelf);
	}
}
