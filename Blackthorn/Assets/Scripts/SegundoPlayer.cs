using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SegundoPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject propriaPos;
    public Animator anim;
    private List<Vector3> PegaPosition;

    public bool isFacingRight = false;
    public static int followDistance = 10;
    public static int controleDistance;
    private GameObject[] listaPlayers;

    float horizontalMove = 0;

    private bool umaVez;
    Rigidbody2D rb;
    GameManager gm;
    void Awake()
    {
        PegaPosition = new List<Vector3>();
        //listaPlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        //if (rb.velocity.y == 0)
        //{
        //    anim.SetBool("IsJumping", false);
        //    anim.SetBool("IsFalling", false);
        //}
        //if (rb.velocity.y < 0)
        //{
        //    anim.SetBool("IsJumping", false);
        //    anim.SetBool("IsFalling", true);
        //}
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.SetBool("IsJumping", true);
        //}
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && isFacingRight || horizontal < 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
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

            gm.playerPrincipal.transform.position = gm.lastCheckpoint;
            transform.position = gm.lastCheckpoint;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;


            if (PegaPosition.Count == 0) //Sê ta vazio
            {
                PegaPosition.Add(playerPos); //pega position do player
                return;
            }
            else if (PegaPosition[PegaPosition.Count - 1] != playerPos)
            {
                PegaPosition.Add(playerPos); //armazena todo tempo
            }

            else if (transform.position.y != playerPos.y) //se ta no ar ou nao
            {
                PegaPosition.Add(playerPos);
            }

            if (PegaPosition.Count > followDistance)
            {
                transform.position = PegaPosition[0]; //move
                PegaPosition.RemoveAt(0); //delete the position that player just move to
            }
            anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        Flip(horizontalMove);

    }
}
