using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spedometer : MonoBehaviour
{
    [SerializeField] int framesNeeded = 3;    // In order to find the average apeed we will take the average of speeds over this frame period
    [SerializeField] float percentageFrameDifAllowed = 10f; // Tries to make sure the frames are consistent when calculating speed
    private List<float> speedList = new List<float>();  // Tracks the speeds found in an array
    //private Vector3[] positionList = new Vector3[framesNeeded];
    private Vector3 prevPosition;   // Keeps a record of the object's previous position one frame ago
    private Vector3 curPosition;    // Keeps a record of the objects current position
    private float prevFrameTime;    // Keeps a record of the previous frame's duration in real-time
    private float curFrameTime;     // Keeps a record of the last frame's duration in real-time
    private const float targetFrameLength = 1f / 60f;
    [SerializeField] private float aveHorizSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // This sets framerate to 60. This should go into the main game script later
        Application.targetFrameRate = 60;
        // Initializing
        curPosition = Vector3.zero;
        curFrameTime = 0f;
        speedList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        prevPosition = curPosition;
        prevFrameTime = curFrameTime;
        curPosition = gameObject.transform.position;
        curFrameTime = Time.deltaTime;
        if (prevFrameTime != 0)
        {
            float percChange = Mathf.Abs((curFrameTime - prevFrameTime) / prevFrameTime) * 100;
            if (percChange >= (percentageFrameDifAllowed)) // Checks if percent difference of the previous frame is less than
            {
                Debug.Log("Frame length changed by " + (int)percChange + "%");
                float percError = Mathf.Abs((curFrameTime - targetFrameLength) / targetFrameLength) * 100;
                if(percError >= percentageFrameDifAllowed)
                {
                    Debug.Log("Frame dropped from calculation");
                    curFrameTime = prevFrameTime;
                }
            }
        }
        PopulateHorizSpeedList();
        aveHorizSpeed = CalculateAveSpeed();
    }

    private void PopulateHorizSpeedList()
    {
        float horizSpeed = (curPosition.x - prevPosition.x) / curFrameTime;
        if(speedList.Count == framesNeeded)
        {
            speedList.RemoveRange(0, 1);
        }
        speedList.Add(horizSpeed);
    }

    private float CalculateAveSpeed()
    {
        float sum = 0;
        for (int i = 0; i < speedList.Count; i++)
        {
            sum += speedList[i];
        }
        //ShowList(speedList);
        return sum / speedList.Count;
    }

    /* ShowList is for debugging purposes only */
    private void ShowList(List<float> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
    public float GetAveHorizSpeed()
    {
        return aveHorizSpeed;
    }
}
