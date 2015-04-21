﻿using UnityEngine;
using System.Collections;

public class con2MainEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Console 2 has the main event");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void eventConsole(string textInput){

		consoleScript console = (consoleScript)this.GetComponent("consoleScript");
		
		if (textInput == "?") {
			console.textOutput = console.modeOptions;
		} else if (textInput == "exit") {
			console.mode = "Basic";			
			console.textOutput = "";
			console.modeOptions = console.defaultOptions;
			console.spamshield = true;
		} else if (textInput == "power" || textInput == "lock") {
			console.textOutput = "Incomplete command\n";
		} else if (textInput == "power ?" || textInput == "lock ?") {
			console.textOutput = "On\nOff\n";
		} else if (textInput == "power on") {
			console.textOutput = "Door is now powered\n";
		} else if (textInput == "power off") {
			console.textOutput = "Door is no longer powered\n";
		} else if (textInput == "lock on") {
			interaction.doorLocked = true;
			console.textOutput = "Door is now locked\n";
		} else if (textInput == "lock off") {
			//send message to door script
			interaction.doorUnlocked = true;
			console.textOutput = "Door is now unlocked\n";
		} else if (console.spamshield == true) {
			console.textOutput = "";
			console.spamshield = false;
		} else {
			console.textOutput = "Unrecognised command\n";
		}

	}
}
