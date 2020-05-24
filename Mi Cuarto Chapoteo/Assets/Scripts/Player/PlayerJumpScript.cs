using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour
{

    public static PlayerJumpScript instance;
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] float forceX, forceY;
    private float thresholdX = 7f;
    private float thresholdY  = 14f;
    private bool setPower, didJump = false;

    private float MaxForceX = 6.5f;
    private float MaxForceY = 13.5f;

    private Slider powerBar;
    private float powerBarThreshold = 10f;
    private float powerBarValue = 0f;

    private void Awake()
    {
        MakeInstance();
        Init();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Init()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBar.minValue = powerBarValue;
        powerBar.maxValue = powerBarThreshold;
        powerBar.value = powerBarValue;
    }

    void Update()
    {
        SetPower();   
    }

    void SetPower()
    {
        if (setPower)
        {
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;
            if(forceX > MaxForceX)
            {
                forceX = MaxForceX;
            }
            if(forceY > MaxForceY)
            {
                forceY = MaxForceY;
            }
            powerBarValue += powerBarThreshold * Time.deltaTime;
            powerBar.value = powerBarValue;
        }
    }

    public void givePower(bool power)
    {
        setPower = power;
        if (!setPower)
        {
            Jump();
        }
    }

    void Jump()
    {
        body.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
        animator.SetBool("jump", didJump);
        powerBarValue = 0f;
        powerBar.value = powerBarValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (didJump)
        {
            didJump = false;
            animator.SetBool("jump", didJump);
            if(other.gameObject.tag == "Platform")
            {
                //crear nueva plataforma
            }
        }   
    }
}

