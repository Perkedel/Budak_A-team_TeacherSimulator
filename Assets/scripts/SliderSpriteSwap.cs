using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSpriteSwap : MonoBehaviour
{
    public Animator AnimatingComponent;
    public Animation Animationing;
    [Range(0f, 100f)] public float value;
    [Range(0f, 5f)] [SerializeField] float PlaybackPosition;

    // Start is called before the first frame update
    void Start()
    {
        AnimatingComponent = GetComponent<Animator>();
        AnimatingComponent.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimatingComponent)
        {
            AnimatingComponent.playbackTime = Mathf.Clamp((value / 100) * 5,0f,5f);
            PlaybackPosition = AnimatingComponent.playbackTime;
            
        }
        if (Animationing)
        {
        }
    }
}
