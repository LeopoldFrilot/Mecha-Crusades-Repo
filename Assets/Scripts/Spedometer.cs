using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spedometer : MonoBehaviour
{
    [SerializeField] const int framesNeeded = 5;    // In order to find the average apeed we will take the average of speeds over this frame period
    [SerializeField] float percentageFrameDifAllowed = 50f; // Tries to make sure the frames are consistent when calculating speed
    private float[] speedList = new float[framesNeeded];    // Tracks the speeds found in an array
    //private Vector3[] positionList = new Vector3[framesNeeded];
    private Vector3 prevPosition;   // Keeps a record of the object's previous position one frame ago
    private Vector3 curPosition;    // Keeps a record of the objects current position
    private float prevFrameTime;    // Keeps a record of the previous frame's duration in real-time
    private float curFrameTime;     // Keeps a record of the last frame's duration in real-time
    [SerializeField] private float aveHorizSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // Initializing
        curPosition = Vector3.zero;
        curFrameTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speedList);
        prevPosition = curPosition;
        prevFrameTime = curFrameTime;
        curPosition = gameObject.transform.position;
        curFrameTime = Time.deltaTime;
        if (prevFrameTime != 0)
        {
            if (Mathf.Abs(((curFrameTime - prevFrameTime) / ((prevFrameTime + curFrameTime)/2f))) >= (percentageFrameDifAllowed / 100))
            {
                Debug.Log("Frame jump");
            }
        }
        if (prevPosition != Vector3.zero)
        {
            PopulateHorizSpeedArray();
            aveHorizSpeed = CalculateAveSpeed();
        }
        else
        {
            Debug.Log(gameObject.name + " was still last frame.");
        }
    }

    private float CalculateAveSpeed()
    {
        float sum = 0;
        for (int i = 0; i < framesNeeded; i++)
        {
            sum += i;
        }
        return sum / framesNeeded;
    }

    private void PopulateHorizSpeedArray()
    {
        float horizSpeed = (prevPosition.x - curPosition.x) / curFrameTime;
        for (int i = framesNeeded - 2; i >= 0; i--)
        {
            speedList[i + 1] = speedList[i];
        }
        speedList[0] = horizSpeed;
    }

    public float GetAveHorizSpeed()
    {
        return aveHorizSpeed;
    }
}
