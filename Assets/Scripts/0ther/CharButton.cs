using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharButton : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color hoverColor;
    SpriteRenderer SR;
    [SerializeField] GameObject charObjectP1;
    [SerializeField] GameObject charObjectP2;
    int numObjects = 0;
    void Start()
    {
        SR = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (numObjects>0)
        {
            SR.color = hoverColor;
        }
        else
        {
            SR.color = defaultColor;
        }
    }
    public void OnTriggerEnter2D()
    {
        numObjects++;
    }
    public void OnTriggerExit2D()
    {
        numObjects--;
    }
    public GameObject GetCharObject(bool isP1)
    {
        if (isP1) return charObjectP1;
        else return charObjectP2;
    }
}
