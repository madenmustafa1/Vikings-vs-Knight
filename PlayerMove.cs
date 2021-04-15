using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float m_speed = 1.0f;
    [SerializeField] float m_jumpForce = 2.0f;
    
    private Animator m_animator;
    private Rigidbody2D rigid;
    public Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;
    private float timer;

    public GameObject RightPos;
    public GameObject LeftPos;
    public GameObject RightRot;
    public GameObject LeftRot;
    public GameObject rightbullet, leftbullet;
    public Transform leftBulletPos;
    public Transform rightBulletPos;
    public SpriteRenderer spriteRenderer;
    public AudioClip fightVoice;
    public AudioClip attackVoice;
    BannerScript bannerScript;

    public float speed = 5f;
    public bool rightClicked, leftClicked, attackClicked, jumpClicked;
    public float nextFire = 0.2f;
    float inputX;
    public static bool kontrol = true;
    public float ultiTimer;


    void Start()
    {
        Time.timeScale = 1;
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioSource.PlayClipAtPoint(fightVoice, Camera.main.transform.position);

        StartCoroutine("attackVoiceTimer");

    }
    ButtonController buttonController;
    void Update()
    {
        //Dead
        if (HealthBar.kontrol == false)
        {
            if (kontrol)
            {
                this.GetComponent<PlayerMove>().enabled = false;
                this.GetComponent<Collider2D>().enabled = false;
                //AudioSource.PlayClipAtPoint(deadSound, Camera.main.transform.position);

                foreach (Transform child in this.transform)
                {
                    child.gameObject.SetActive(false);
                }

                kontrol = false;

                StartCoroutine("Restart");
                StartCoroutine("destroyBanner");
            }
        }

        timer += Time.deltaTime;
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
            
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
            
        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        //Attack
        //if (Input.GetMouseButtonDown(0))
        //{
        //    m_animator.SetTrigger("Attack");
        //    if (GetComponent<SpriteRenderer>().flipX == true)
        //    {
        //        StartCoroutine(ClearRightPos());
        //    }
        //    else
        //    {
        //        StartCoroutine(ClearLeftPos());
        //    }

        //}
        //Defans
        if (Input.GetKeyDown("f"))
        {
            m_combatIdle = !m_combatIdle;

        }
        //Jump
        else if (Input.GetKeyDown("space") && m_grounded || jumpClicked && m_grounded)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
            jumpClicked = false;
        }
        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);
        
        //Idle
        else
            m_animator.SetInteger("AnimState", 0);

        if (leftClicked)
        {
            MovePlayer(-1f);
        }
        if (rightClicked)
        {
            MovePlayer(1f);
        }
        if(attackClicked && timer > nextFire)
        {
            m_animator.SetTrigger("Attack");
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                //StartCoroutine(ClearRightPos());
                StartCoroutine(ClearLeftPos());
            }
            else
            {
                //StartCoroutine(ClearLeftPos());
                StartCoroutine(ClearRightPos());
            }

            attackClicked = false;
        }

        ultiTimer += Time.deltaTime;
    }
    public IEnumerator ClearRightPos()
    {
        Vector3 vector3 = RightRot.transform.position;
        yield return new WaitForSeconds(0.45f);
        Instantiate(RightPos, RightRot.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindGameObjectWithTag("AttackPosRight"));
    }
    public IEnumerator ClearLeftPos()
    {
        Vector3 vector3 = LeftRot.transform.position;
        yield return new WaitForSeconds(0.45f);
        Instantiate(LeftPos, LeftRot.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindGameObjectWithTag("AttackPosLeft"));
    }
    private void MovePlayer(float inputX)
    {
        
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Run
         if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            m_animator.SetInteger("AnimState", 2);
        }
           
        if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void MoveLeftMobile()
    {

        leftClicked = true;
        rightClicked = false;

    }
    public void MoveRightMobile()
    {
        rightClicked = true;
        leftClicked = false;
    }
    public void StopPlayerMobile()
    {        
        rightClicked = false;
        leftClicked = false;   
    }
    public void AttackPlayerMobile()
    {    
        attackClicked = true;
        timer = 0f;
    }
    public void JumpPlayerMobile()
    {
        jumpClicked = true;
    }
    public void MobileFireBullet()
    {
        FireBullet();
    }
    private void FireBullet()
    {      
        timer = 0f;
        if(ultiTimer > 10f)
        {
            if (!spriteRenderer.flipX)
            {
                //Instantiate(rightbullet, rightBulletPos.position, Quaternion.identity);
                Instantiate(leftbullet, leftBulletPos.position, Quaternion.identity);
                ultiTimer = 0f;
            }
            if (spriteRenderer.flipX)
            {
                //Instantiate(leftbullet, leftBulletPos.position, Quaternion.identity);
                Instantiate(rightbullet, rightBulletPos.position, Quaternion.identity);
                ultiTimer = 0f;
            }
        } 
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HealthBar.kontrol = true;
        HealthBar.can = 100;
        kontrol = true;       
    }
    IEnumerator attackVoiceTimer()
    {
        yield return new WaitForSeconds(3f);
        AudioSource.PlayClipAtPoint(attackVoice, Camera.main.transform.position);
    }

/*
    IEnumerator destroyBanner()
    {
        yield return new WaitForSeconds(2f);
        Destroy(bannerScript.gameObject);
    }
    */
}

/*
if (Input.GetKeyDown("e"))
{
    if (!m_isDead)
        m_animator.SetTrigger("Death");
    else
        m_animator.SetTrigger("Recover");

    m_isDead = !m_isDead;
}

//Hurt
else if (Input.GetKeyDown("q"))
    m_animator.SetTrigger("Hurt");
*/
