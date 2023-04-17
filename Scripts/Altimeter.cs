using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altimeter : MonoBehaviour
{
    public float StepPos;
    public float PosToCanvasUnit;
    public AltimeterNeedle[] Needles;
    public Rigidbody CharacterRigidbody;

    private void Update()
    {
        float pos = CharacterRigidbody.transform.position.y;
        for (int i = 0; i < Needles.Length; i++)
        {
            float transStep = GetTranslationStep(pos, StepPos, i - Needles.Length / 2);
            AltimeterNeedle needle = Needles[i];
            needle.transform.position = transform.position;
            needle.transform.Translate(0, transStep * PosToCanvasUnit, 0);
            string num = ((int)Mathf.Abs(pos / StepPos) + i).ToString("00");
            needle.Texts[0].text = num;
            needle.Texts[1].text = num;
        }
    }
    private float GetTranslationStep(float pos, float stepPos, int presentStep)
    {
        float presentPos = stepPos * (int)(pos / stepPos);
        float diffPos = presentPos - pos;
        float transPos = diffPos + stepPos * presentStep;
        return transPos / stepPos;
    }
}
