using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualSpriteChangeMeterBar : MonoBehaviour
{
    public Image ImageFraming;
    public Sprite[] SpriteCollections;
    public Sprite CurrentSprite;
    public int prevFrameSelect;
    public int FrameSelect;
    public int lastImageFrame;
    [Range(0f,100f)] public float sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        ImageFraming = GetComponent<Image>();
        lastImageFrame = SpriteCollections.Length - 1;
        prevFrameSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageFraming)
        {
            CurrentSprite = ImageFraming.sprite;
            FrameSelect = Mathf.FloorToInt(sliderValue) * lastImageFrame /100;
            if (SpriteCollections[FrameSelect])
            {
                ImageFraming.sprite = SpriteCollections[FrameSelect];
                prevFrameSelect = FrameSelect;
            }
            else
            {
                ImageFraming.sprite = SpriteCollections[prevFrameSelect];
            }
        }
    }

    public void SetSliderValue(float valuing)
    {
        sliderValue = valuing;
    }
}
