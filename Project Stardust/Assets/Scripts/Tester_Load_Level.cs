using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tester_Load_Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
		
	}

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().Planet_Shader_WIP);
    }
}
