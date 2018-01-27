using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBottom : Singleton<CameraBottom> {

	public Vector3[] Zone
	{
		get
		{
			Vector3[] v = new Vector3[4];
			GetComponent<RectTransform>().GetWorldCorners(v);
			return v;
		}
	}

	public Vector2 TopLeft{
		get{return Zone[1];}
	}
	
	public Vector2 TopRight{
		get{return Zone[2];}
	}
	public Vector2 BottomLeft{
		get{return Zone[0];}
	}
	public Vector2 BottomRight{
		get{return Zone[3];}
	}

	public float Left{get{return TopLeft.x;}}
	public float Right{get{return BottomRight.x;}}
	public float Top{get{return TopLeft.y;}}
	public float Bottom{get{return BottomRight.y;}}

	public Rect LeZone{
		get{return new Rect(Left,Bottom, Right-Left, Top-Bottom);}
	}

	public Vector2 GetRandomInside(){
		return new Vector2(
			Random.Range(LeZone.xMin, LeZone.xMax),
			Random.Range(LeZone.yMin, LeZone.yMax)	
		);
	}	
}
