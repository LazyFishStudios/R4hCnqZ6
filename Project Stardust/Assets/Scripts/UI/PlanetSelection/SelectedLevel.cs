using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedLevel : MonoBehaviour
{
    public GameObject right;
    public GameObject left;

    public void ShowRight()
    {
        right.SetActive(true);
    }

    public void ShowLeft()
    {
        left.SetActive(true);
    }

    public void Hide()
    {
        right.SetActive(false);
        left.SetActive(false);
    }
}
