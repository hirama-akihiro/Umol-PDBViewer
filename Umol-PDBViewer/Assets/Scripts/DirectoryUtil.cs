using UnityEngine;
using System.Collections;
using System.IO;

public class DirectoryUtil {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 指定したパスにディレクトリが存在しない場合
	/// すべてのディレクトリとサブディレクトリを作成します
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static DirectoryInfo SafeCreateDirectory(string path)
	{
		if (Directory.Exists(path)) { return null; }
		return Directory.CreateDirectory(path);
	}
}
