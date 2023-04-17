using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public UIPlayerInputs UIPlayerInputs;
    public Rigidbody CharacterRigidbody;
    public CharacterMoveAttribute CharacterMoveAttribute;

    private Vector3 JumpForceVec = Vector3.zero;
    private Vector3 MoveDirectionVec = Vector3.zero;
    private Vector3 RotateDirectionVec = Vector3.zero;
    private Vector3 JumpDirectionVec = Vector3.zero;
    
    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (UIPlayerInputs.JumpButton)
        {
            JumpDirectionVec.x = MoveDirectionVec.x;
            JumpDirectionVec.z = MoveDirectionVec.z;
            JumpDirectionVec.y = 1.0f - (Mathf.Abs(JumpDirectionVec.x) + Mathf.Abs(JumpDirectionVec.z));
            JumpForceVec = JumpDirectionVec * CharacterMoveAttribute.JumpForce;
            CharacterRigidbody.AddForce(JumpForceVec, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        MoveDirectionVec = CharacterRigidbody.transform.forward * UIPlayerInputs.VerticalAxis + CharacterRigidbody.transform.right * UIPlayerInputs.HorizontalAxis;
        RotateDirectionVec = CharacterRigidbody.transform.up * UIPlayerInputs.RotateAxis;

        CharacterRigidbody.AddForce(MoveDirectionVec * CharacterMoveAttribute.MoveForce);
        CharacterRigidbody.AddTorque(RotateDirectionVec * CharacterMoveAttribute.MoveTorque);
    }
}
