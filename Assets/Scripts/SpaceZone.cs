using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceZone : Singleton<SpaceZone>
{
	public double Top{get{return Height/2;}}
	public double Bottom{get{return -Height/2;}}

	public double Left{get{return -Width/2;}}
	public double Right{get{return Width/2;}}

	public double Width;
	public double Height;
}
