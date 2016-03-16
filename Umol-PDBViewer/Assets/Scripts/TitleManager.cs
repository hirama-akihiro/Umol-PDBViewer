using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// RCSB PDBサイトへアクセスする
	/// </summary>
	public void OnClickAccesPDBButton()
	{
		Application.OpenURL("http://www.rcsb.org/pdb/");
	}

	/// <summary>
	/// PDBファイルのビューアへ遷移する
	/// </summary>
	public void OnClickViewPDBButton()
	{
		SceneManager.LoadScene("ViewPDB");
	}
}
