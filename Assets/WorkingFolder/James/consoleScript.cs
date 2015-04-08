﻿using UnityEngine;
using System.Collections;
using System.Text;

public class consoleScript : MonoBehaviour {

	private bool elevator = false;
	private bool door = false;
	private bool light = false;
	private bool enterPressed = false;
	private bool spamshield = false;
	private string consoleStr = "Basic>";
	private string textInput = "";
	private string textOutput = "";
	private string mode = "Basic";
	private string modeOptions = "";
	private string defaultOptions = "";
	private float cooldown = 2;
	private int numlines, maxlines, eleSpeed;

	// Detects what is child of the console and what options it should have
	void Start () {
		foreach(Transform t in transform){
			if (t.tag == "elevator") {
				Debug.Log ("Elevator on console");
				elevator = true;
				modeOptions = modeOptions + "Elevator\n";
			}
			if (t.tag == "door"){
				Debug.Log ("Door on console");
				door = true;
				modeOptions = modeOptions + "Door\n";
			}
			if(t.tag == "light"){
				Debug.Log ("Light on console");
				light = true;
				modeOptions = modeOptions + "Light\n";
			}
		}
		defaultOptions = modeOptions;
	}
	// Update is called once per frame
	void Update () {
		//To prevent the GUI input detection from spamming 4 times
		if (enterPressed == true) {
			cooldown -= Time.deltaTime;
			if (cooldown < 1){
				enterPressed = false;
				cooldown = 2;
			}
		}
	}
	void OnGUI(){
			Rect textWindow = new Rect (200, 10, Screen.width - 210, Screen.height - 20);
			GUI.Window (0, textWindow, windowFunc, "Console.Log");
	}

	private void inputFunc(){
		textInput = textInput.ToLower ();
		numlines = consoleStr.Split ('\n').Length;
		maxlines = (Screen.height - 52) / 17;
		if (numlines > maxlines) {
			consoleStr = consoleStr.Substring (consoleStr.IndexOf ('\n') + 1);
		}
		//Basic level input check
		if (mode == "Basic") {
			if (textInput == "?") {
				textOutput = modeOptions;
			} else if (textInput == "door" && door == true && mode == "Basic") {
				mode = mode + "/Door";
				modeOptions = "Power\nLock\nExit\n";
				textOutput = "";
				spamshield = true;
			} else if (textInput == "light" && light == true && mode == "Basic") {
				mode = mode + "/Light";
				modeOptions = "Power\nColor\nExit\n";
				textOutput = "";
				spamshield = true;
			} else if (textInput == "elevator" && elevator == true && mode == "Basic") {
				mode = mode + "/Elevator";
				modeOptions = "Power\nSpeed\nExit\n";
				textOutput = "";
				spamshield = true;
			} else {
				textOutput = "Unrecognised command\n";
			}
		}

		//Door level input check
		if (mode == "Basic/Door") {
			if (textInput == "?") {
				textOutput = modeOptions;
			} else if (textInput == "exit") {
				mode = "Basic";
				textOutput = "";
				modeOptions = defaultOptions;
				spamshield = true;
			} else if (textInput == "power" || textInput == "lock") {
				textOutput = "Incomplete command\n";
			} else if (textInput == "power ?" || textInput == "lock ?") {
				textOutput = "On\nOff\n";
			} else if (textInput == "power on") {
				textOutput = "Door is now powered\n";
			} else if (textInput == "power off") {
				textOutput = "Door is no longer powered\n";
			} else if (textInput == "lock on") {
				textOutput = "Door is now locked\n";
			} else if (textInput == "lock off") {
				textOutput = "Door is now unlocked\n";
			} else if (spamshield == true) {
				textOutput = "";
				spamshield = false;
			} else {
				textOutput = "Unrecognised command\n";
			}
		}

		//Light level input check
		if (mode == "Basic/Light") {
			if (textInput == "?") {
				textOutput = modeOptions;
			} else if (textInput == "exit") {
				mode = "Basic";
				textOutput = "";
				modeOptions = defaultOptions;
				spamshield = true;
			} else if (textInput == "power" || textInput == "color") {
				textOutput = "Incomplete command\n";
			} else if (textInput == "power ?") {
				textOutput = "On\nOff\nSexy\n";
			} else if (textInput == "color ?") {
				textOutput = "White\nGreen\nSexy\n";
			} else if (textInput == "power on") {
				textOutput = "Lights are powered on\n";
			} else if (textInput == "power off") {
				textOutput = "Lights are powered off\n";
			} else if (textInput == "power sexy") {
				textOutput = "Lights are set to SEXY!\n";
			} else if (textInput == "color white") {
				textOutput = "Light color set to white";
			} else if (textInput == "color green") {
				textOutput = "Light color set to green";
			} else if (textInput == "color sexy") {
				textOutput = "BOOM BABY SEXY LIGHTS!\n";
			} else if (spamshield == true) {
				textOutput = "";
				spamshield = false;
			} else {
				textOutput = "Unrecognised command\n";
			}
		}

		//Elevator level input check
		if (mode == "Basic/Elevator") {
			if (textInput == "?") {
				textOutput = modeOptions;
			} else if (textInput == "exit") {
				mode = "Basic";
				textOutput = "";
				modeOptions = defaultOptions;
				spamshield = true;
			} else if (textInput == "power" || textInput == "speed") {
				textOutput = "Incomplete command\n";
			} else if (textInput == "power ?") {
				textOutput = "On\nOff\n";
			} else if (textInput == "speed ?") {
				textOutput = "speed [1-10]\n";
			} else if (textInput == "power on") {
				textOutput = "Elevator is powered on\n";
			} else if (textInput == "power off") {
				textOutput = "Elevator is powered off\n";
			/*This code needs to be cleaned up if I can check if a string has a set part and then
			a wildcard part. Will use the following code to get the int value out of the string
			for (int i = 0; i < textInput.Length; i++){
				if (Char.IsDigit(textOutput[i]))
				eleSpeed = textOutput[i]
			}*/
			} else if (textInput == "speed 1"){
				eleSpeed = 1;
				textOutput = "Elevator speed set to 1\n";
			} else if (textInput == "speed 2"){
				eleSpeed = 2;
				textOutput = "Elevator speed set to 2\n";
			} else if (textInput == "speed 3"){
				eleSpeed = 3;
				textOutput = "Elevator speed set to 3\n";
			} else if (textInput == "speed 4"){
				eleSpeed = 4;
				textOutput = "Elevator speed set to 4\n";
			} else if (textInput == "speed 5"){
				eleSpeed = 5;
				textOutput = "Elevator speed set to 5\n";
			} else if (textInput == "speed 6"){
				eleSpeed = 6;
				textOutput = "Elevator speed set to 6\n";
			} else if (textInput == "speed 7"){
				eleSpeed = 7;
				textOutput = "Elevator speed set to 7\n";
			} else if (textInput == "speed 8"){
				eleSpeed = 8;
				textOutput = "Elevator speed set to 8\n";
			} else if (textInput == "speed 9"){
				eleSpeed = 9;
				textOutput = "Elevator speed set to 9\n";
			} else if (textInput == "speed 10"){
				eleSpeed = 10;
				textOutput = "Elevator speed set to 10\n";
			}else if (spamshield == true) {
				textOutput = "";
				spamshield = false;
			} else {
				textOutput = "Unrecognised command\n";
			}
		}
		//Other part to prevent the GUI input from spamming 4 times.
		if (enterPressed == false){
			consoleStr = consoleStr + " " + textInput + "\n" + textOutput + mode + ">";
			enterPressed = true;
		}
		textInput = "";
	}
	private void windowFunc(int id){
		//Aligning and organising the input and output fields
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(10,20, Screen.width - 230, Screen.height - 70), consoleStr);
		textInput = GUI.TextField (new Rect (10, Screen.height - 52, Screen.width - 230, 22), textInput);

		//Checking if enter is pressed
		Event e = Event.current;
		if (e.keyCode == KeyCode.Return) {
			inputFunc ();
		}
	}
}
