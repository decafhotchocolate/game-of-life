using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text generationText;
    public Button generationButton;
    public Image playPauseButtonImage;
    private GenerationManager generationManager;
    public Sprite playImage;
    public Sprite pauseImage;
    void Start()
    {
        generationManager = GameObject.Find("Game").GetComponent<GenerationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        generationText.text = "Generation: " + generationManager.currentGeneration;
        switch(generationManager.generationsPlaying) {
            case true:
                playPauseButtonImage.sprite = playImage;
                break;
            case false:
                playPauseButtonImage.sprite = pauseImage;
                break;
        }
    }
}
