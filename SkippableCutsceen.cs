using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkippableCutsceen : Cutsceen
{
    public Material skipMat;
    float skipCutSceeneTimer;
    public Text skipText;
    public float skipCutSceeneTimerMax;
    protected override void Start()
    {
        skipMat.SetFloat("_HideAmount", 0);
        skipCutSceeneTimer = skipCutSceeneTimerMax;
        if (Controls.keys["SkipCutSceene"].ToString().Equals("Return"))
            skipText.text = "Hold Enter to skip cutsceen";
        else
            skipText.text = "Hold " + Controls.keys["SkipCutSceene"].ToString() + " to skip cutsceen";
        base.Start();
    }
    protected override void Update()
    {
        if (Input.GetKey(Controls.keys["SkipCutSceene"]))
        {
            skipMat.SetFloat("_HideAmount", skipCutSceeneTimer / skipCutSceeneTimerMax);
            if (skipCutSceeneTimer > 0)
            {
                skipCutSceeneTimer -= Time.deltaTime;
                return;
            }
            timer = 0;
        }
        else
        {
            skipMat.SetFloat("_HideAmount", 0);
        }
        base.Update();
    }
}
