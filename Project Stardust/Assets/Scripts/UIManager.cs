using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    //This value need to set by the manager that holds the actual experience number
    private float experience = 5;

    [SerializeField]
    private Image experienceBar;

    private float inExpMin = 0;
    private float inExpMax = 10;
    private float outExpMin = 0;
    private float outExpMax = 1;

    //This sets the max experience for every level before the player levels up
    public float InExpMax
    {
        get
        {
            return inExpMax;
        }

        set
        {
            inExpMax = value;
        }
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleExperienceBar();
	}

    private void HandleExperienceBar()
    {
        experienceBar.fillAmount = MapExperienceBar(experience);
    }

    //This maps the actual experience values to a scale 0 to 1 so that the the experience bar works
    private float MapExperienceBar (float value)
    {
        value = (value - inExpMin) * (outExpMax - outExpMin) / (inExpMax - inExpMin) + outExpMin;

        return value;
    }
}
