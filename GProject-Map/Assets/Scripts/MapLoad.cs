﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class MapLoad : MonoBehaviour {

	public GameObject wall;
	public GameObject spawn;
	public GameObject bwall;
	public GameObject floor;

	private StreamReader theReader = new StreamReader("map.txt", Encoding.Default);

	//private string[] mapTest = {"11211", "10001", "10001", "10001", "11111"};
	private string[] mapString;
	private float startX = 0.0f;
	private float startZ = 0.0f;

	// Use this for initialization
	void Start () {
		using (theReader) {

			mapString = theReader.ReadToEnd ().Split ('\n');
			theReader.Close();

		}


		for (int i = 0; i < mapString.Length; i++) {
			Debug.Log ("*" + mapString[1] + "*");
			foreach (char oState in mapString[i]) {
				switch(oState)
				{
				case '1':
					Instantiate(wall, new Vector3(startX,0.5f,startZ), Quaternion.identity);
					break;
				case '2':
					Instantiate(spawn, new Vector3(startX,0.5f,startZ), Quaternion.identity);
					break;
				case '3':
					Instantiate(bwall, new Vector3(startX,0.5f,startZ), Quaternion.identity);
					break;
				case '0':
					GameObject fClone = (GameObject)Instantiate(floor, new Vector3(startX,0.5f,startZ), Quaternion.identity);
					fClone.transform.Rotate (Vector3.right * 90);
					break;
				default:
					break;
				}
				startX += 1.0f;
			}
			startX = 0.0f;
			startZ += 1.0f;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
