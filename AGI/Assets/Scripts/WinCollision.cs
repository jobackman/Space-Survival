using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class WinCollision : MonoBehaviour {
	public GameObject scoreboard; 
	private TextMesh boardtext;
	WiiController wiicontroller;
	BreathTimer breathtimer; 

	int fuel;
	int oxygen;
	public int score = 0;
	private int numberOfHighScores = 2;
	public List<Scores> HighScoreList = new List<Scores> ();
	public string text = "";
	
	// Use this for initialization
	void Start () {
		boardtext = scoreboard.GetComponent<TextMesh> ();
		wiicontroller = GetComponent<WiiController> ();
		breathtimer = GetComponent<BreathTimer> ();


		//Load all saved highscores and save to HighScoresList
		int j = 1;
		while(PlayerPrefs.HasKey("HighScore"+j) && j<=numberOfHighScores){
			Scores temp = new Scores();
			temp.score = PlayerPrefs.GetInt("HighScore"+j);
			//temp.name = j.ToString();
			temp.name = "";
			HighScoreList.Add(temp);
			j++;
		}
		print ("start... length of highScoreList: " + HighScoreList.Count);
	}
	
	void Update () {
		//clear PlayerPrefs on C
		if(Input.GetKey(KeyCode.C)){
			print ("Delete all PlayerPrefs");
			PlayerPrefs.DeleteAll();
			HighScoreList.Clear();
		}
	}

	void OnCollisionEnter (Collision col){
		if(col.gameObject.name == "Speessheep"){
			//GameObject test = GameObject.FindGameObjectWithTag("Player");
			//remove collider for spaceship, otherwise multiple collisions ->multiple scores. 
			Destroy(col.collider);

			//Convert score to int and get the values
			fuel = (int)Math.Round(wiicontroller.fuel);
			oxygen = (int)Math.Round(breathtimer.timer);

			//Save highscore... Maybe calculate in another way later
			score = fuel+oxygen;
			saveHighScore(score);
		}
	}
	

	void updateText(string t){
		boardtext.text = t;
	}

	void saveHighScore(int score){
		//No highscores exist. Add current highscore
		if(HighScoreList.Count==0){
			print ("highscorelist.count == 0");
			Scores temp = new Scores();
			temp.score = score;
			temp.name = "Your score";
			HighScoreList.Add (temp);
		}
		//Highscores exist, add if score is high enough. 
		else{
			for(int i=1; i<=HighScoreList.Count && i<=numberOfHighScores; i++){
				//if the score is high enough, add it at that position.
				if(score>HighScoreList[i-1].score){
					print ("First if");
					Scores temp = new Scores();
					temp.score = score;
					temp.name = "Your score";
					if(HighScoreList.Count==numberOfHighScores){
						HighScoreList.RemoveAt(HighScoreList.Count-1);
					}
					HighScoreList.Insert (i-1, temp);
					break;
				}
				//if you reach the end of the list but the number is higher than the last one -> replace 
				if(i==HighScoreList.Count && i<numberOfHighScores){
					Scores temp = new Scores();
					temp.score = score;
					temp.name = "Your score";
					if(HighScoreList.Count==numberOfHighScores){
						HighScoreList.RemoveAt(HighScoreList.Count-1);
					}
					HighScoreList.Add(temp);
					break;
				}
				//If your score isn't high enough, print it above the Highscore-list
				if(i==HighScoreList.Count && i==numberOfHighScores && score<HighScoreList[i-1].score){
					print ("Third if");
					text += "Your score: "+ score + "\n \n";
					break;
				}
			}
		}

		//Save the new HighScoresList to PlayerPrefs and print the list
		text += "Highscores: \n";
		for(int i=1; i<=HighScoreList.Count; i++){
			PlayerPrefs.SetInt("HighScore"+i, HighScoreList[i-1].score);
			text += HighScoreList[i-1].score + " " +HighScoreList[i-1].name + "\n";
		}

		updateText (text);
		HighScoreList.Clear();
	}
}

public class Scores{
	public int score;
	public string name;
}
