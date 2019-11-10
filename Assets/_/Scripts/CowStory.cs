using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.MRDL.PeriodicTable;

public class CowStory : MonoBehaviour {

    public Cow cow;
    public GameObject pTable;
    public GameObject theFattyCow;
    public GameObject whatCouldBe;
    public GameObject guessMyfarts;
    public GameObject clue;
    public GameObject feedButton;
    public GameObject grumble;
    public GameObject ohyeah;
    public GameObject whataremadeof;
    public GameObject hint2;

    public AudioSource fart;

    public AudioSource wrong;


    private bool started = false;


    private static CowStory _instance;

    public static CowStory Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    // Use this for initialization
    void Start () {
        pTable.SetActive(false);
        theFattyCow.SetActive(false);
        whatCouldBe.SetActive(false);
        guessMyfarts.SetActive(false);
        clue.SetActive(false);
        feedButton.SetActive(false);
        grumble.SetActive(false);
        ohyeah.SetActive(false);
        whataremadeof.SetActive(false);
        hint2.SetActive(false);

        //StartCowStory();
        //DebugMode();

        
    }

    void DebugMode()
    {

       // pTable.SetActive(true);
        theFattyCow.SetActive(true);
        guessMyfarts.SetActive(true);
        whatCouldBe.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartCowStory()
    {
        Debug.Log("StartCowStory " + started);
        if (!started)
        {

            StartCoroutine(TheCowStory());

            started = true;
        }
    }

    IEnumerator TheCowStory()
    {
        // story 1
        cow.mooTrigger = true;
        guessMyfarts.SetActive(true);
        theFattyCow.SetActive(true);
        yield return new WaitForSeconds(4);
        guessMyfarts.SetActive(false);
        theFattyCow.SetActive(false);

        whataremadeof.SetActive(true);
        yield return new WaitForSeconds(4);
        whataremadeof.SetActive(false);



        clue.SetActive(true);
        yield return new WaitForSeconds(5);
        whatCouldBe.SetActive(true);
        hint2.SetActive(true);

        yield return new WaitForSeconds(3);
        pTable.SetActive(true);


        feedButton.SetActive(true);

    }

    public void WhatCouldItBe(bool enbable)
    {
        clue.SetActive(enbable);
        whatCouldBe.SetActive(enbable);
        hint2.SetActive(enbable);
    }


    public void PressedConfirmButton()
    {
        WhatCouldItBe(false);
        Debug.Log("PressedConfirmButton");
        // see if correct elements

        int count = Element.ActiveElement.Count;
        Debug.Log(count);

        if (count == 2)
        {
            foreach (Element e in Element.ActiveElement)
            {
                Debug.Log(e.data.name);
                if (e.data.name != "Carbon" && e.data.name != "Hydrogen")
                {

                    Debug.Log("LOSE wrong elements");


                    ohyeah.SetActive(false);
                    grumble.SetActive(true);
                    wrong.Play();
                    return;
                }
            }

            Debug.Log("WIN");
            ohyeah.SetActive(true);
            grumble.SetActive(false);
            fart.Play();
        }
        else
        {

            ohyeah.SetActive(false);
            grumble.SetActive(true);

            wrong.Play();
            Debug.Log("LOSE wrong number");
        }

    }
}
