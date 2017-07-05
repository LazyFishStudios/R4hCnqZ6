using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Tester_Load_Level : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {  

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TESTERBUTTON()
    {
        SceneManager.LoadScene("PlanetShaderWIP");
    }
}
