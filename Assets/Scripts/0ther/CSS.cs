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

    public void CheckSelected()
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
        foreach (Puck puck in pucks)
        {
            if (puck.IsP1)
            {
                SceneStatics.Player1 = puck.GetChosenChar();
                if (puck.IsCPU) SceneStatics.IsP1CPU = true;
                else SceneStatics.IsP1CPU = false;
            }
            else
            {
                SceneStatics.Player2 = puck.GetChosenChar();
                if (puck.IsCPU) SceneStatics.IsP2CPU = true;
                else SceneStatics.IsP2CPU = false;
            }
        }
        GetComponent<SceneSwitcher>().LoadNextScene();
    }
}
