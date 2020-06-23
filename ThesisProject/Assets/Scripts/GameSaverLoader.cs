using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaverLoader : MonoBehaviour {


	private PlayerProgressionHandler playerProgression;
	private string savefilepath;
	public GameObject playerProgressionObj;


	// Use this for initialization
	void Start () {
		
		playerProgression = playerProgressionObj.GetComponent<PlayerProgressionHandler> ();
		savefilepath = Application.dataPath + "/PlayerData.yourdata";
		playerProgression.currentLevel = 1;
		LoadData ();
	}

	public void SaveData(){

		BinaryFormatter bf = new BinaryFormatter();

		FileStream fstream = new FileStream (savefilepath, FileMode.Create);

		var pData = new PlayerProgression (){


			LevelProgression = playerProgression.currentLevel

		};


		bf.Serialize (fstream, pData);
		fstream.Close ();


	}

	public void LoadData(){
	
		if (File.Exists (savefilepath)) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fstream = new FileStream (savefilepath, FileMode.Open);

			PlayerProgression pData = bf.Deserialize (fstream) as PlayerProgression;

			playerProgression.currentLevel = pData.LevelProgression;

			fstream.Close ();


		} else {
		
			Debug.Log ("no savefile found");
		}



	}



}
