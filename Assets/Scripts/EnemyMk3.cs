using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMk3 : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private GameObject player;
    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        stateMachine = new StateMachine();
        player = GameObject.Find("PlayerArmature");

        CoverArea coverArea = FindObjectOfType<CoverArea>();

        // States
        var runToCover = new EnemyState_RunToCover(enemyReferences, coverArea);
        var delayAtferRun = new EnemyState_Delay(1f);
        var cover = new EnemyState_Cover(enemyReferences);

        // Transitions
        At(runToCover, delayAtferRun, () => runToCover.HasArrivedAtDestination());
        At(delayAtferRun, cover, () => delayAtferRun.IsDone());
        At(cover, runToCover, () => FarFromPlayer());

        // Start State
        stateMachine.SetState(runToCover);

        // Functions & Conditions
        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Tick();
    }

    bool FarFromPlayer()
    {
        if (Vector3.Distance(player.transform.position, enemyReferences.transform.position) >= 8.0f) return true;
        else return false;
    }

    private void OnDrawGizmos()
    {
        if(stateMachine != null)
        {
            Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }
}
