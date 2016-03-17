using UnityEngine;
using System.Collections;
using System;

public class DPtBase {

	#region Field
	/// <summary>
	/// X座標
	/// </summary>
	protected double _ptX;

	/// <summary>
	/// Y座標
	/// </summary>
	protected double _ptY;

	/// <summary>
	/// Z座標
	/// </summary>
	protected double _ptZ;
	#endregion

	#region Constroctor
	public DPtBase(double ptX = 0, double ptY = 0, double ptZ = 0)
	{
		_ptX = ptX;
		_ptY = ptY;
		_ptZ = ptZ;
	}

	public DPtBase(DPtBase right)
	{
		_ptX = right._ptX;
		_ptY = right._ptY;
		_ptZ = right._ptZ;
	}
	#endregion

	#region Method
	/// <summary>
	/// 原点(0,0,0)からの長さを返す
	/// </summary>
	/// <returns></returns>
	public double Length() { return Math.Sqrt((_ptX * _ptX + _ptY * _ptY + _ptZ * _ptZ)); }

	/// <summary>
	/// 2点間の距離を算出する
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static double Distance(DPtBase left, DPtBase right)
	{
		return Math.Sqrt(Math.Pow(left._ptX - right._ptX, 2) + Math.Pow(left._ptY - right._ptY, 2) + Math.Pow(left._ptZ - right._ptZ, 2));
	}
	#endregion

	#region Operator
	#endregion

	#region Property
	/// <summary>
	/// X座標
	/// </summary>
	public double PtX { get { return _ptX; } set { _ptX = value; } }

	/// <summary>
	/// Y座標
	/// </summary>
	public double PtY { get { return _ptY; } set { _ptY = value; } }

	/// <summary>
	/// Z座標
	/// </summary>
	public double PtZ { get { return _ptZ; } set { _ptZ = value; } }
	#endregion
}
