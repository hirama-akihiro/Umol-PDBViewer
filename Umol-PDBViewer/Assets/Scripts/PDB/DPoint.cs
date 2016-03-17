using UnityEngine;
using System.Collections;

public class DPoint : DPtBase {

	#region Field
	#endregion

	#region Constroctor
	public DPoint(double ptX = 0.0, double ptY = 0.0, double ptZ = 0.0) : base(ptX, ptY, ptZ) { }

	public DPoint(DPoint right) : base(right) { }
	#endregion

	#region Method
	public override string ToString() { return string.Format("{0:f3}", _ptX) + "," + string.Format("{0:f3}", _ptY) + "," + string.Format("{0:f3}", _ptZ); }
	#endregion

	#region Operator
	public static DPoint operator +(DPoint left, DPoint right)
	{
		return new DPoint(left.PtX + right.PtX, left.PtY + right.PtY, left.PtZ + right.PtZ);
	}

	public static DPoint operator /(DPoint left, int right)
	{
		return new DPoint(left.PtX / right, left.PtY / right, left.PtZ / right);
	}
	#endregion

	#region Property
	#endregion
}
