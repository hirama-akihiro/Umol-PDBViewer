using UnityEngine;
using System.Collections;

public class PdbRecord {

	/// <summary>
	/// 元々の行情報
	/// </summary>
	private string _baseInfo;

	/// <summary>
	/// レコード名
	/// </summary>
	private string _recordName;

	/// <summary>
	/// 原子名
	/// </summary>
	private string _atomName;

	/// <summary>
	/// 残基名
	/// </summary>
	private string _aminoName;

	/// <summary>
	/// チェインID
	/// </summary>
	private string _chainID;

	/// <summary>
	/// アミノ酸残基番号
	/// </summary>
	private int _aminoNo;

	/// <summary>
	/// 座標
	/// </summary>
	private DPoint _point;

	public PdbRecord() { }

	/// <summary>
	/// もともとの行情報
	/// </summary>
	public string BaseInfo { get { return _baseInfo; } set { _baseInfo = value; } }

	/// <summary>
	/// レコード名
	/// </summary>
	public string RecordName { get { return _recordName; } set { _recordName = value; } }

	/// <summary>
	/// 原子名
	/// </summary>
	public string AtomName { get { return _atomName; } set { _atomName = value; } }

	/// <summary>
	/// アミノ酸残基名
	/// </summary>
	public string AminoName { get { return _aminoName; } set { _aminoName = value; } }

	/// <summary>
	/// チェインID
	/// </summary>
	public string ChainID { get { return _chainID; } set { _chainID = value; } }

	/// <summary>
	/// アミノ酸残基番号
	/// </summary>
	public int AminoNo { get { return _aminoNo; } set { _aminoNo = value; } }

	/// <summary>
	/// 座標
	/// </summary>
	public DPoint Point { get { return _point; } set { _point = value; } }
}
