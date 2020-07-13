using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Puck : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isCPU = false;
    float horizMove;
    float vertMove;
    bool selectable = false;
    CharButton curChar;
    CharButton selectedChar;


    public void MoveHorizontal(InputAction.CallbackContext context)
    {
        horizMove = context.ReadValue<float>();
    }
    public void MoveVertical(InputAction.CallbackContext context)
    {
        vertMove = context.ReadValue<float>();
    }
    public void SelectCharacter()
    {
        if (selectable)
        {
            SelectedChar = curChar;
        }
    }
    private void Update()
    {
        if(!SelectedChar)
            Move();
    }

    private void Move()
    {
        if (isCPU)
        {
            AI();
            return;
        }
        transform.position += new Vector3(horizMove * speed * Time.deltaTime, vertMove * speed * Time.deltaTime, 0);
    }

    private void AI()
    {
        if(curChar == null)
        {
            var characters = FindObjectsOfType<CharButton>();
            curChar = characters[(int)Random.Range(0, characters.Length - Mathf.Epsilon)];
        }
        transform.position = Vector2.MoveTowards(transform.position, curChar.transform.position, speed * Time.deltaTime);
        if(transform.position == curChar.transform.position)
        {
            SelectedChar = curChar;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        curChar = collision.GetComponent<CharButton>();
        selectable = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        curChar = null;
        selectable = false;
    }
    public GameObject GetChosenChar()
    {
        return curChar.GetCharObject();
    }
    public CharButton SelectedChar { get => selectedChar; set => selectedChar = value; }
}
