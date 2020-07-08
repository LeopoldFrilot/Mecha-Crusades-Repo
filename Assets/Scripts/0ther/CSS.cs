using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS : MonoBehaviour
{
    Puck[] pucks;
    // Start is called before the first frame update
    void Start()
    {
        pucks = FindObjectsOfType<Puck>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelected();
    }

    private void CheckSelected()
    {
        foreach (Puck puck in pucks)
        {
            if (puck.SelectedChar == null)
            {
                return;
            }
        }
        MoveOn();
    }

    private void MoveOn()
    {
        GetComponent<SceneSwitcher>().LoadNextScene();
    }
}
