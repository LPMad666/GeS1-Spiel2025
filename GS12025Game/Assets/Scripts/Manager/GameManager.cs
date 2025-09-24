using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startingSceneTransition;
    [SerializeField]
    private GameObject endingSceneTransition;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Fade In Effect
        //StartCoroutine(SceneTransitionSequence());
        Debug.Log("GameManager Awake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSceneTransitionSequence()
    {
        StartCoroutine(SceneTransitionSequence());
    }

    //Start Scene Transition Sequence
    private IEnumerator SceneTransitionSequence()
    {
        EnableStartingSceneTransition();
        yield return new WaitForSeconds(50f); // Wait for 2 seconds
        DisableStartingSceneTransition();

    }


    // End Scene Transition Sequence
    public void EndSceneTransitionSequence()
    {
        StartCoroutine(EndGameSequence());
    }

    private IEnumerator EndGameSequence()
    {
        EndingSceneTransition();
        yield return new WaitForSeconds(50f); // Wait for 2 seconds
        // Load the next scene or perform any other actions here
    }


    public void EnableStartingSceneTransition()
    {
        startingSceneTransition.SetActive(true);
    }

    public void DisableStartingSceneTransition()
    {
        startingSceneTransition.SetActive(false);
    }

    public void EndingSceneTransition()
    {
        endingSceneTransition.SetActive(true);
    }

    public void EndGame()
    {
        endingSceneTransition.SetActive(true);
    }

    public void SceneChange()
    {

    }
}
