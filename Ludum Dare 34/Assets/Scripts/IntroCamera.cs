﻿using UnityEngine;
using System.Collections;
using DG.Tweening;


public class IntroCamera : MonoBehaviour {

    private bool canStart;
    private CameraFollow followScript;
    private Player playerScript;
    private Rigidbody2D playerBody;
    private GameObject secondCamera;
    private ParticleSystem playerParticles;
    private SpriteRenderer playerSprite;
    private TrailRenderer playerTrail;
    public Animator dripAnimation;
    private AudioSource music1;
    public SpriteRenderer inputSprite;
    public SpriteRenderer hideSprite;

    // Use this for initialization
    void Awake () {
        DOTween.Init();
        transform.DOMove(new Vector3(0, -3, -10), 10, false).OnComplete(CanPlay);
        followScript = GetComponent<CameraFollow>();
        playerScript = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<Player>();
        playerBody = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<Rigidbody2D>();
        secondCamera = GameObject.FindGameObjectWithTag("Second Camera").transform.gameObject;
        playerParticles = playerBody.GetComponentInChildren<ParticleSystem>();
        playerSprite = playerBody.GetComponentInChildren<SpriteRenderer>();
        playerTrail = playerBody.GetComponentInChildren<TrailRenderer>();
        music1 = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    void Start()
    {
        secondCamera.transform.position = new Vector3(secondCamera.transform.position.x, playerScript.transform.position.y - 2, -10);
    }

    // Update is called once per frame
    void Update () {
        if (canStart)
        {
            if (((Input.GetAxis("Horizontal Axis") < 0.15) && (Input.GetAxis("Horizontal Axis") > -0.15)) && ((Input.GetAxis("Vertical Axis") < 0.15) && (Input.GetAxis("Vertical Axis") > -0.15)))
            {
                //
            }
            else
            {
                hideSprite.enabled = true;
                followScript.enabled = true;
                playerBody.transform.position = new Vector3(40, -0.7f, 0);
                playerBody.gravityScale = 1;
                playerScript.enabled = true;
                inputSprite.enabled = false;
                playerSprite.enabled = true;
                music1.Play();
                enabled = false;
            }
        }
	}

    void CanPlay()
    {
        dripAnimation.enabled = true;
        StartCoroutine(CanMove());
    }

    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(2);
        inputSprite.DOColor(new Color(255, 255, 255, 1), 2);
        canStart = true;
    }

    void enableTrail()
    {
        //playerTrail.enabled = true;
    }
}
