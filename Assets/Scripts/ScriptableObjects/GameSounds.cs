using UnityEngine;

[CreateAssetMenu(fileName = "GameSounds", menuName = "New Game Sounds")] // Allows for a right-click in the asset folder to create a new one
public class GameSounds : ScriptableObject
{
    [SerializeField] AudioClip nextSceneTransitionSound;
    [SerializeField] AudioClip resetSceneTransitionSound;
    [SerializeField] AudioClip winScreenTransitionSound;
    [SerializeField] AudioClip pauseSound;
    [SerializeField] AudioClip resumeSound;

    public AudioClip NextSceneTransitionSound { get => nextSceneTransitionSound; set => nextSceneTransitionSound = value; }
    public AudioClip ResetSceneTransitionSound { get => resetSceneTransitionSound; set => resetSceneTransitionSound = value; }
    public AudioClip WinScreenTransitionSound { get => winScreenTransitionSound; set => winScreenTransitionSound = value; }
    public AudioClip PauseSound { get => pauseSound; set => pauseSound = value; }
    public AudioClip ResumeSound { get => resumeSound; set => resumeSound = value; }
}
