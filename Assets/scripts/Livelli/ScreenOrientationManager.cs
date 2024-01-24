using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenOrientation : MonoBehaviour
{
    public ScreenOrientation targetOrientation = ScreenOrientation.Portrait;

    private void Start()
    {
        SetScreenOrientation(targetOrientation);
    }

    private void SetScreenOrientation(ScreenOrientation orientation)
    {
        Screen.autorotateToPortrait = (orientation == ScreenOrientation.Portrait);
        Screen.autorotateToPortraitUpsideDown = (orientation == ScreenOrientation.PortraitUpsideDown);
        Screen.autorotateToLandscapeLeft = (orientation == ScreenOrientation.LandscapeLeft);
        Screen.autorotateToLandscapeRight = (orientation == ScreenOrientation.LandscapeRight);

        Screen.orientation = orientation;
    }
}