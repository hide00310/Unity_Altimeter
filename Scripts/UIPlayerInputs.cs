using UnityEngine;

public class UIPlayerInputs : MonoBehaviour
{
    public float HorizontalAxis = 0.0f;
    public float VerticalAxis = 0.0f;
    public float RotateAxis = 0.0f;
    public bool JumpButton = false;

    private void LateUpdate()
    {
        JumpButton = Input.GetKey(KeyCode.Space);
        HorizontalAxis = GetHorizontalAxis();
        VerticalAxis = GetVerticalAxis();
        RotateAxis = GetRotateAxis();
    }

    private float GetRotateAxis()
    {
        float ret = 0;
        if (Input.GetKey(KeyCode.E))
        {
            ret = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            ret = -1;
        }
        return ret;
    }
    private float GetHorizontalAxis()
    {
        float ret = 0;
        if (Input.GetKey(KeyCode.D))
        {
            ret = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ret = -1;
        }
        return ret;
    }
    private float GetVerticalAxis()
    {
        float ret = 0;
        if (Input.GetKey(KeyCode.W))
        {
            ret = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ret = -1;
        }
        return ret;
    }
}
