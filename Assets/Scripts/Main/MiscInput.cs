﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscInput : MonoBehaviour {
	public GameObject glove;
	public GameObject racket;
	private bool Ydown = false;

	private HandTracking htGlove;
	private HandTracking htRacket;

	void Start() {
		htGlove = glove.GetComponent<HandTracking> ();
		htRacket = racket.GetComponent<HandTracking> ();
	}

	void Update () {
		// Return to main menu on start button press or escape key
		if (OVRInput.GetDown (OVRInput.RawButton.Start) || Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene ("MenuScene");

		// Switch hand roles on Y button press
		if (!Ydown && OVRInput.GetDown (OVRInput.RawButton.Y)) {
			if (htGlove != null && htRacket != null) {
				OVRInput.Controller gloveController = htGlove.controller;
				OVRInput.Controller racketController = htRacket.controller;

				htGlove.controller = racketController;
				htRacket.controller = gloveController;
			}
		}
		Ydown = OVRInput.GetDown (OVRInput.RawButton.Y);	
	}
}
