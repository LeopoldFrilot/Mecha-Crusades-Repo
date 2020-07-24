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
    [SerializeField] bool isP1;


    public void MoveHorizontal(InputAction.CallbackContext context)
    {
        horizMove = context.ReadValue<float>();
    }
    public void MoveVertical(InputAction.CallbackContext context)
    {
        vertMove = context.ReadValue<float>();
    }
    public void SelectCharacter(InputAction.CallbackContext context)
    {
        if (selectable && context.ReadValue<float>()<= Mathf.Epsilon)
        {
            SelectedChar = curChar;
            FindObjectOfType<CSS>().CheckSelected();
        }
    }
    private void Update()
    {
        if(!SelectedChar)
            Move();
    }

    private void Move()
    {
        if (IsCPU)
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
            curChar = characters[Mathf.FloorToInt(Random.Range(0, characters.Length - Mathf.Epsilon))];
        }
        transform.position = Vector2.MoveTowards(transform.position, curChar.transform.position, speed * Time.deltaTime);
        if(transform.position == curChar.transform.position)
        {
            SelectedChar = curChar;
            FindObjectOfType<CSS>().CheckSelected();
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
        return SelectedChar.GetCharObject(isP1);
    }
    public CharButton SelectedChar { get => selectedChar; set => selectedChar = value; }
    public bool IsP1 { get => isP1; set => isP1 = value; }
    public bool IsCPU { get => isCPU; set => isCPU = value; }
}
