using UnityEngine;
using System.Collections.Generic;

public class PdbFile {

	#region Field
	/// <summary>
	/// PDBID
	/// </summary>
	protected string _pdbID;

	/// <summary>
	/// チェインID
	/// </summary>
	protected string _chainId;

	/// <summary>
	/// タンパク質名
	/// </summary>
	protected string _headerInfo;

	/// <summary>
	/// 分子名称
	/// </summary>
	protected string _molName;

	/// <summary>
	/// PDB:HEADERレコードとTITLEレコード
	/// </summary>
	protected List<PdbRecord> _pdbHEADER_TITLERecord;

	/// <summary>
	/// PDB:ATOMレコード
	/// </summary>
	protected List<PdbRecord> _pdbATOMRecord;

	/// <summary>
	/// PDB:HETATOMレコード
	/// </summary>
	protected List<PdbRecord> _pdbHETATMRecord;
	#endregion

	#region Constroctor
	public PdbFile()
	{
		_pdbHEADER_TITLERecord = new List<PdbRecord>();
		_pdbATOMRecord = new List<PdbRecord>();
		_pdbHETATMRecord = new List<PdbRecord>();
	}
	#endregion

	#region Method
	public List<PdbRecord> GetChainATOMRecord(string chainid)
	{
		List<PdbRecord> chainRecord = new List<PdbRecord>();
		foreach (PdbRecord record in _pdbATOMRecord)
		{
			if (record.ChainID.ToLower() == chainid.ToLower()) { chainRecord.Add(record); }
		}
		return chainRecord;
	}

	public List<PdbRecord> GetChainHETATMRecord(string chainid)
	{
		List<PdbRecord> chainRecord = new List<PdbRecord>();
		foreach (PdbRecord record in _pdbHETATMRecord)
		{
			if (record.ChainID.ToLower() == chainid.ToLower()) { chainRecord.Add(record); }
		}
		return chainRecord;
	}
	#endregion

	#region Property
	/// <summary>
	/// PDBID
	/// </summary>
	public string PdbID { get { return _pdbID; } set { _pdbID = value; } }

	/// <summary>
	/// チェインID
	/// </summary>
	public string ChainID { get { return _chainId; } set { _chainId = value; } }

	/// <summary>
	/// タンパク質名
	/// </summary>
	public string HeaderInfo { get { return _headerInfo; } set { _headerInfo = value; } }

	/// <summary>
	/// 分子名称
	/// </summary>
	public string MolName { get { return _molName; } set { _molName = value; } }

	/// <summary>
	/// PDB:HEADERレコードとTITLEレコード
	/// </summary>
	public List<PdbRecord> PdbHEADER_TITLERecord { get { return _pdbHEADER_TITLERecord; } set { _pdbHEADER_TITLERecord = value; } }

	/// <summary>
	/// PDB:ATOMレコード
	/// </summary>
	public List<PdbRecord> PdbATOMRecord { get { return _pdbATOMRecord; } set { _pdbATOMRecord = value; } }

	/// <summary>
	/// PDB:HETATMレコード
	/// </summary>
	public List<PdbRecord> PdbHETATMRecord { get { return _pdbHETATMRecord; } set { _pdbHETATMRecord = value; } }
	#endregion
}
