using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SettingDataHandler : MonoBehaviour {

	string settingDataPath;
	string settingDataGetter;
	string[] settingData;

	public GameObject[] VolHandlerObj = new GameObject[3];
	private float MasterVol;
	private float BGMVol;
	private float SEVol;
	public float MasterVolGetter;
	public float BGMVolGetter;
	public float SEVolGetter;



	private void CreateFile(){
	
		string datapath = Application.dataPath + "/SettingPref.txt";
		settingDataPath = datapath;

		if(File.Exists(settingDataPath) == false){

			//File.Create (settingDataPath);
			MasterVol = 1;
			BGMVol = 1;
			SEVol = 1;

			File.WriteAllText(settingDataPath, "Game Configuration\n" +
				"\nMaster Volume = " + MasterVol +
				"\nBGM Volume = " + BGMVol +
				"\nSE Volume = " + SEVol);
		}
	}

	private void LoaderSaver(bool save){
	

		if (save) {
			
			File.WriteAllText (settingDataPath, "Game Configuration\n" +
				"\nMaster Volume = " + MasterVol +
				"\nBGM Volume = " + BGMVol +
				"\nSE Volume = " + SEVol);
			Debug.Log ("saved");
			
		} else {

			if(File.Exists(settingDataPath)){
				settingData = new string[30];
				settingData = File.ReadAllLines (settingDataPath);


				settingDataGetter = settingData [2];
				MasterVolGetter = float.Parse (settingDataGetter.Substring(16));
				VolHandlerObj [0].GetComponent<AudioVolumeHandler> ().VolumeLevelLoad (MasterVolGetter, 0);
				VolHandlerObj [0].GetComponent<Slider> ().value = MasterVolGetter;
				settingDataGetter = settingData [3];
				BGMVolGetter = float.Parse (settingDataGetter.Substring(13));
				VolHandlerObj [1].GetComponent<AudioVolumeHandler> ().VolumeLevelLoad (BGMVolGetter, 1);
				VolHandlerObj [1].GetComponent<Slider> ().value = BGMVolGetter;
				settingDataGetter = settingData [4];
				SEVolGetter = float.Parse (settingDataGetter.Substring(12));
				VolHandlerObj [2].GetComponent<AudioVolumeHandler> ().VolumeLevelLoad (SEVolGetter, 2);
				VolHandlerObj [2].GetComponent<Slider> ().value = SEVolGetter;



				MasterVol = VolHandlerObj [0].GetComponent<Slider> ().value;
				BGMVol = VolHandlerObj [1].GetComponent<Slider> ().value;
				SEVol = VolHandlerObj [2].GetComponent<Slider> ().value;
				Debug.Log ("loaded");

			}
				
		}
			
	}



	public void SaveSetting(){
	
		LoaderSaver (true);
	}




	// Use this for initialization
	void Start () {

		CreateFile ();
		LoaderSaver (false);

	}
	
	// Update is called once per frame
	void Update () {

		MasterVol = VolHandlerObj [0].GetComponent<Slider> ().value;
		BGMVol = VolHandlerObj [1].GetComponent<Slider> ().value;
		SEVol = VolHandlerObj [2].GetComponent<Slider> ().value;


	}
}
