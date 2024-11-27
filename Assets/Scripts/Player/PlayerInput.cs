using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private const string Horizontal = nameof(Horizontal);

    public float DirectionX { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        DirectionX = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJump = true;
        }
        else
        {
            IsJump = false;
        }
    }
}
