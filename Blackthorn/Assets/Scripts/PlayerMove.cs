using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


    public class PlayerMove : MonoBehaviour
    {
        public static float speed = 6f;
        public float jump;
        public float coguJump;
        public float checkRadius;
        private float horizontalMove = 0f;

        public bool isGrounded;
        private bool particlePassos;
        private bool isFacingRight = false;
        public bool onIce;
        private bool parou;

        public static Animator anim;
        public Transform feetPos;
        public GameObject passosPrefab;
        public LayerMask layerGround;
        public LayerMask layerIce;

        public static Vector3 posPulo;

        Rigidbody2D rb;
        GameManager gm;

        void Start()
        {
            FilaMorte.mortes = 0;
            FilaMorte.quantClones = 0;
            rb = GetComponent<Rigidbody2D>();
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
            anim = GetComponent<Animator>();
            transform.position = gm.lastCheckpoint;
        }

        void Update()
        {
            Scene scene = SceneManager.GetActiveScene();
            

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    SceneManager.LoadScene(scene.name);
            //}

            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, layerGround);
            onIce = Physics2D.OverlapCircle(feetPos.position, checkRadius, layerIce);
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if(rb.velocity.y == 0)
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", false);
            }
            if (rb.velocity.y > 0)
            {
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsFalling", false);
            }
            if (rb.velocity.y < 0)
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", true);
            }


            if (isGrounded || onIce)
            {

               

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    
                    FindObjectOfType<ScriptAudioManager>().Play("slime_jump_start"); 

                    anim.SetBool("IsJumping", true);

                    rb.velocity = Vector2.up * jump;
                    posPulo.x = transform.position.x;
                }

                if(particlePassos)
                {
                    FindObjectOfType<ScriptAudioManager>().Play("slime_jump_end");
                    Instantiate(passosPrefab, feetPos.position, Quaternion.identity);
                    particlePassos = false;
                }

                
            }
            else
            {
                particlePassos = true;
            }
        }


        private void Flip(float horizontal)
        {
            if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
            {
                isFacingRight = !isFacingRight;

                Vector3 theScale = transform.localScale;

                theScale.x *= -1;

                transform.localScale = theScale;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Cogumelo"))
            {
                float jumpValue;
                jumpValue = coguJump + FilaMorte.mortes;
                rb.velocity = Vector2.up * jumpValue;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Espinho") || collision.gameObject.CompareTag("Planta") || collision.gameObject.CompareTag("Gota"))
            {

            if (FilaMorte.podeSpawnar && FilaMorte.tempoMorte <= 0)
            {
                FilaMorte.tempoMorte = FilaMorte.saveTempo;
                FilaMorte.podeSpawnar = false;
                StartCoroutine(FilaMorte.morte());
            }

                FindObjectOfType<ScriptAudioManager>().Play("slime_damage");
                transform.position = gm.lastCheckpoint;
                //Colocar no segundo player tbm assim gm.playerPrincipal.transform.position = gm.lastCheckpoint; transform.position = gm.lastCheckpoint;

            }
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

            if (onIce)
            {
                parou = false;
                rb.AddForce(movement * speed * Time.deltaTime * 80);
            }

            if (!parou && isGrounded)
            {
                rb.velocity = Vector2.zero;
                parou = true;
            }
            transform.position += movement * Time.deltaTime * speed;

            anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

            Flip(horizontalMove);
        }
    }

