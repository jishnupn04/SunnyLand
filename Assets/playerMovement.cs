using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    float horizontalMove = 0f;
    public float playerSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
            jump = true;
            Debug.Log("Jump clicked");
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("Crouch clicked");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log("Crouch released");
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    public void HitGround()
    {
        animator.SetBool("isJumping", false);
    }
    	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("isCrouching", isCrouching);
	}

}
