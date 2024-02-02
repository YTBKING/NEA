using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UIElements;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform Player;

    Player player = new Player();

    private float horizontal;
    public float speed;
    private float jumpPower;

    private float DashPower;
    public bool isDashing = false;
    private float dashCooldown;
    private bool isDashed = false;
    public float cooldownLeft = 10;
    private float dashTime;
    private int dashCount = 0;
    public float dashHeightChange = 0.3f;
    private float recent;


    public Image DashCooldown;

    private float standardX;
    private float standardY;
    private float standardZ;

    private bool MoveLock = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        standardX = gameObject.transform.localScale.x;
        standardY = gameObject.transform.localScale.y;
        standardZ = gameObject.transform.localScale.z;

        #region "Player Stats"
        dashCooldown = player.dashCooldown;
        speed = player.speed;
        dashTime = player.dashTime;
        DashPower = player.DashPower;
        jumpPower = player.jumpPower;
        #endregion
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            if ((Input.GetKey(KeyCode.LeftShift) && !isDashed) || isDashing)
            {
                Dash(true);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            if ((Input.GetKey(KeyCode.LeftShift) && !isDashed) || isDashing)
            {
                Dash(true);
            }
        }

        if (isDashed)
        {

            cooldownLeft += Time.deltaTime;
            UpdateBar();
            if (cooldownLeft >= dashCooldown)
            {
                isDashed = false;
                cooldownLeft = 10;
            }
        }
    }
    void FixedUpdate()
    {
        if (!MoveLock)
        {
            recent = horizontal;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


            if ((Input.GetKey(KeyCode.LeftShift) && !isDashed) || isDashing)
            {
                Dash();
            }
        }
    }

    private void Dash(bool jump = false)
    {
        dashCount++;
        Debug.Log("Dash");
        isDashing = true;
        gameObject.transform.localScale = new Vector3(standardX, standardY - dashHeightChange, standardZ);
        if (jump) {
            if (horizontal == -1) {
                rb.velocity = new Vector2(horizontal * speed - DashPower, jumpPower + DashPower);
            }
            else if (horizontal == 1) {
                rb.velocity = new Vector2(horizontal * speed + DashPower, jumpPower + DashPower);
            }
        }
        else {

            if (horizontal == -1) {
                rb.velocity = new Vector2(horizontal * speed - DashPower, rb.velocity.y);
            }
            else if (horizontal == 1) {
                rb.velocity = new Vector2(horizontal * speed + DashPower, rb.velocity.y);
            }
        }

        if (dashCount == dashTime)
        {
            gameObject.transform.localScale = new Vector3(standardX, standardY, standardZ);
            isDashing = false;
            isDashed = true;
            cooldownLeft = 0;
            dashCount = 0;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.name == "Ground")
        {
            MoveLock = false;
        }
    }

    void UpdateBar()
    {
        DashCooldown.fillAmount = cooldownLeft / dashCooldown;
    }

    public bool isLocked() {
        return MoveLock;
    }

    public void setLocked(bool Lock) {
        MoveLock = Lock;
    }
}