using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class View3DManager : MonoBehaviour {

	public Text mTextPDBID;

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
			foreach(PdbRecord record in pdbfile.PdbATOMRecord)
			{
				GameObject prefab = Resources.Load("Prefabs/AtomSphere") as GameObject;
				GameObject atomSphere = Instantiate(prefab, new Vector3((float)record.Point.PtX, (float)record.Point.PtY, (float)record.Point.PtZ), Quaternion.identity) as GameObject;
			}
		}
	}
}
