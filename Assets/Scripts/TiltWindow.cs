using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltWindow : MonoBehaviour
{
    // Movement range variable
    public Vector2 range = new Vector2(5f, 3f);

    // Variables
    Transform mTrans;
    Quaternion mStart;
    Vector2 mRot = Vector2.zero;

    void Start()
    {
        mTrans = transform;
        mStart = mTrans.localRotation;
    }

    void Update()
    {
        // Getting the mouse position on the screen

        Vector3 pos = Input.mousePosition;

        // Calculation of half the width and Height of the screen
        float halfWidth = Screen.width * 0.5f;
        float halfHeight = Screen.height * 0.5f;

        // Normalization of mouse position relative to the center of the screen
        float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
        float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);

        // Interpolation between current rotation and new rotation based on mouse position
        mRot = Vector2.Lerp(mRot, new Vector2(x, y), Time.deltaTime * 5f);

        // Applying rotation to the object
        mTrans.localRotation = mStart * Quaternion.Euler(-mRot.y * range.y, mRot.x * range.x, 0f);
    }
}
