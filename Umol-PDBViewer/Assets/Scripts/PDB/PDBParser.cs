using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class PDBParser {

	/// <summary>
	/// PDBファイルのHEADER,TITLE,ATOM,HETATM抽出
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static PdbFile ParsePdbFile(string path)
	{
		PdbFile pdbFile = new PdbFile();
		string[] lines = File.ReadAllLines(path);

		if (lines.Length == 0) { return null; }

		// ヘッダー行から情報抽出
		pdbFile.PdbID = GetPdbID(lines[0]);
		pdbFile.HeaderInfo = GetHeaderInfo(lines[0]);

		foreach (string line in lines)
		{
			if (line.Length != 80) { continue; }
			PdbRecord record = new PdbRecord();
			record.BaseInfo = line;
			record.RecordName = GetRecordName(line);
			if (record.RecordName == "HEADER" || record.RecordName == "TITLE") { pdbFile.PdbHEADER_TITLERecord.Add(record); }
			if (record.RecordName == "COMPND" && line.Contains("MOLECULE")) { pdbFile.MolName = GetMolName(line); }
			if (record.RecordName != "ATOM" && record.RecordName != "HETATM") { continue; }
			record.AtomName = GetAtomName(line);
			record.AminoName = GetAminoName(line);
			record.AminoNo = GetAminoNo(line);
			record.ChainID = GetChainID(line);
			record.Point = GetPoint(line);
			if (record.RecordName == "ATOM" && record.AtomName == "CA")
			{
				if (pdbFile.PdbATOMRecord.Count == 0) { pdbFile.PdbATOMRecord.Add(record); }
				if (pdbFile.PdbATOMRecord.Last().AminoNo != record.AminoNo) { pdbFile.PdbATOMRecord.Add(record); }
			}
			else if (record.RecordName == "HETATM" && record.AminoName != "HOH" && record.AminoName != "MSE") { pdbFile.PdbHETATMRecord.Add(record); }
		}
		return pdbFile;
	}

	/// <summary>
	/// PDBファイルのHETATM行だけ抽出
	/// </summary>
	/// <param name="fPath"></param>
	/// <returns></returns>
	public static PdbFile ParsePDBFileOnlyHETATM(string fPath)
	{
		PdbFile pdbFile = new PdbFile();
		using (StreamReader sr = new StreamReader(fPath))
		{
			string line = sr.ReadLine();
			pdbFile.PdbID = GetPdbID(line);
			pdbFile.HeaderInfo = GetHeaderInfo(line);
			while ((line = sr.ReadLine()) != null)
			{
				if (line.Length != 80) { continue; }
				PdbRecord record = new PdbRecord();
				record.RecordName = GetRecordName(line);
				if (record.RecordName == "HEADER" || record.RecordName == "TITLE") { pdbFile.PdbHEADER_TITLERecord.Add(record); }
				if (record.RecordName == "COMPND" && line.Contains("MOLECULE")) { pdbFile.MolName = GetMolName(line); }
				if (record.RecordName != "ATOM" && record.RecordName != "HETATM") { continue; }
				record.AtomName = GetAtomName(line);
				record.AminoName = GetAminoName(line);
				record.AminoNo = GetAminoNo(line);
				record.ChainID = GetChainID(line);
				record.Point = GetPoint(line);
				//if (record.AtomName != "CA") { continue; }
				if (record.RecordName == "ATOM") { /* pdbFile.PdbATOMRecord.Add(record); */}
				else if (record.RecordName == "HETATM" && record.AminoName != "HOH" && record.AminoName != "MSE") { pdbFile.PdbHETATMRecord.Add(record); }
			}
		}
		return pdbFile;
	}

	/// <summary>
	/// PDBIDの取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetPdbID(string line) { return line.Substring(62, 4); }

	/// <summary>
	/// タンパク質名の取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetHeaderInfo(string line) { return line.Substring(10, 40).Trim(); }

	/// <summary>
	/// レコード名を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetRecordName(string line) { return line.Substring(0, 6).Trim(); }

	/// <summary>
	/// 分子名称を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetMolName(string line) { return line.Substring(29, 51); }

	/// <summary>
	/// 原子名を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetAtomName(string line) { return line.Substring(12, 4).Trim(); }

	/// <summary>
	/// アミノ酸残名を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetAminoName(string line) { return line.Substring(17, 3).Trim(); }

	/// <summary>
	/// チェインIDを取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static string GetChainID(string line) { return line.Substring(21, 1).Trim(); }

	/// <summary>
	/// アミノ酸残基番号を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static int GetAminoNo(string line) { return int.Parse(line.Substring(22, 4).Trim()); }

	/// <summary>
	/// 3次元座標を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static DPoint GetPoint(string line) { return new DPoint(GetPtX(line), GetPtY(line), GetPtZ(line)); }

	/// <summary>
	/// X座標を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static double GetPtX(string line) { return double.Parse(line.Substring(30, 8).Trim()); }

	/// <summary>
	/// Y座標を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static double GetPtY(string line) { return double.Parse(line.Substring(38, 8).Trim()); }

	/// <summary>
	/// Z座標を取得
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	protected static double GetPtZ(string line) { return double.Parse(line.Substring(46, 8).Trim()); }
}
