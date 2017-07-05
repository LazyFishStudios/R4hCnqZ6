using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet_Display_Counter : MonoBehaviour {

    public int displayCounter;
    public GameObject Exotic_Planets;
    public GameObject Explosive_Planets;
    public GameObject Tech_Planets;
    public GameObject HOME;
    public GameObject NEXT_Explosive_Planets;
    public GameObject PREVIOUS_Exotic_Planets;
    public GameObject NEXT_Tech_Planets;
    public GameObject PREVIOUS_Explosive_Planets;

    // Use this for initialization
    void Start () {

        displayCounter = 0;
	}

    public void IncreaseCounter ()
    {
        displayCounter++;
    }

    public void DecreaseCounter()
    {
        displayCounter--;
    }

    public void LoadHomeScene ()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
        if (displayCounter == 0)
        {
            Exotic_Planets.SetActive(true);
            Explosive_Planets.SetActive(false);
            Tech_Planets.SetActive(false);
            HOME.SetActive(true);
            NEXT_Explosive_Planets.SetActive(true);
            PREVIOUS_Exotic_Planets.SetActive(false);
            NEXT_Tech_Planets.SetActive(false);
            PREVIOUS_Explosive_Planets.SetActive(false);
        }

        if (displayCounter == 1)
        {
            Exotic_Planets.SetActive(false);
            Explosive_Planets.SetActive(true);
            Tech_Planets.SetActive(false);
            HOME.SetActive(false);
            NEXT_Explosive_Planets.SetActive(false);
            PREVIOUS_Exotic_Planets.SetActive(true);
            NEXT_Tech_Planets.SetActive(true);
            PREVIOUS_Explosive_Planets.SetActive(false);
        }

        if (displayCounter == 2)
        {
            Exotic_Planets.SetActive(false);
            Explosive_Planets.SetActive(false);
            Tech_Planets.SetActive(true);
            HOME.SetActive(false);
            NEXT_Explosive_Planets.SetActive(false);
            PREVIOUS_Exotic_Planets.SetActive(false);
            NEXT_Tech_Planets.SetActive(false);
            PREVIOUS_Explosive_Planets.SetActive(true);
        }
    }
}
