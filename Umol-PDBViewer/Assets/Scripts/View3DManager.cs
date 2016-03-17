using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class View3DManager : MonoBehaviour {

	public Text mTextPDBID;
	public GameObject molecule;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 指定したPDBIDに対応した分子情報を可視化
	/// </summary>
	public void OnClickViewPDBButton()
	{
		// PDBフォルダを安全に生成する
		DirectoryUtil.SafeCreateDirectory(Application.persistentDataPath + "/PDB");

		// PDBIDに対応したPDBファイルをダウンロード
		WWW www = new WWW("http://files.rcsb.org/download/" + mTextPDBID.text + ".pdb");

		// ダウンロード状況の確認
		while (!www.isDone) { continue; }

		if (!string.IsNullOrEmpty(www.error))
		{
			// ダウンロードでエラーが発生した
			print(www.error);
		}
		else
		{
			// ダウンロードが正常に完了した
			string path = Application.persistentDataPath + "/PDB/" + Path.GetFileName(www.url);
			File.WriteAllBytes(path, www.bytes);

			// ダウンロードしたPDBファイルの読み込み
			PdbFile pdbfile = PDBParser.ParsePdbFile(path);

			// 原子球を読み込み座標に表示
			for (int i = 0, c = pdbfile.PdbATOMRecord.Count - 1; i < c; i++)
			{
				PdbRecord record1 = pdbfile.PdbATOMRecord[i];
				PdbRecord record2 = pdbfile.PdbATOMRecord[i + 1];

				if(record1.AminoNo + 1 != record2.AminoNo) { continue; }

				// 原子
				GameObject prefab = Resources.Load("Prefabs/AtomSphere") as GameObject;
				Vector3 atomPos = new Vector3((float)record1.Point.PtX, (float)record1.Point.PtY, (float)record1.Point.PtZ);
				GameObject atom = Instantiate(prefab, atomPos, Quaternion.identity) as GameObject;

				// 辺
				prefab = Resources.Load("Prefabs/AtomCylinder") as GameObject;
				GameObject edde = Instantiate(prefab, new Vector3((float)((record1.Point.PtX + record2.Point.PtX) / 2), (float)((record1.Point.PtY + record2.Point.PtY) / 2), (float)((record1.Point.PtZ + record2.Point.PtZ) / 2)), Quaternion.identity) as GameObject;
				edde.transform.localScale = new Vector3(0.4f, (float)DPoint.Distance(record1.Point, record2.Point) / 2, 0.4f);

				atom.transform.parent = molecule.transform;
				edde.transform.parent = molecule.transform;
			}
		}
	}

	public double CalcDotProduct(Vector2 left, Vector2 right)
	{
		return left.x * right.x + left.y * right.y;
	}

	public double CalcAngleOfVector2(Vector2 left, Vector2 right)
	{
		double lenA = left.magnitude;
		double lenB = right.magnitude;

		double cosSeta = CalcDotProduct(left, right) / (lenA * lenB);

		double radian = Mathf.Acos((float)cosSeta);

		return radian * 180.0 / Mathf.PI;
	}
}
