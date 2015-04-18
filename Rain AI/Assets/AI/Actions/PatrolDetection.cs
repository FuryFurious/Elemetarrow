using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class PatrolDetection : RAINAction
{
    public Expression DetectedForm = new Expression();

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        var enemie = DetectedForm.Evaluate<GameObject>(ai.DeltaTime, ai.WorkingMemory);

        if (enemie == null)
        {
            ai.Body.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            enemie.SetActive(false);
            ai.Body.GetComponent<Renderer>().material.color = Color.white;
        }

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}