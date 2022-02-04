using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutsceen : MonoBehaviour
{
    //this will be on cutsceene prefabs
    //cutsceene to show
    //sound
    public delegate void CutsceenTodo();
    public CutsceenTodo DoAction;
    public Canvas canvas;
    protected float timer;
    public float timerMax;
    protected virtual void Start()
    {
        Time.timeScale = 1f;
        if (DoAction==null)
        {
            DoAction = ()=> { Debug.Log("Finished Action"); };
        }
        //You may only need this when you use world camera
       // canvas.worldCamera = Camera.main;
        timer = timerMax;
    }
    protected virtual void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            return;
        }
        DoAction();
        // do action here
        Destroy(gameObject);
    }
}
