﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnterState : IState
{
    private FSM m_FSM;
    private Transform m_transform;
    GameObject m_gameObject;
    public GameObject spawnExplosion;
    public EnterState(FSM fsm, GameObject _gameObject)
    {
        m_FSM = fsm;
        m_gameObject = _gameObject;
        m_transform = m_gameObject.transform;
    }
    public EnterState()
    {

    }

    public void OnEnter()   //  The method that should be performed to enter this state
    {
        Debug.Log("I am EnterState. OnEnter()");
    }
    public void OnUpdate() //The method that should be executed to maintain this state
    {
        
        m_transform.position = Vector3.MoveTowards(m_transform.position, new Vector3(m_transform.position.x,0, m_transform.position.z), 0.01f);
        m_transform.localScale = Vector3.MoveTowards(m_transform.localScale, new Vector3(0.2f,0.2f,0.2f),0.01f);

        if (m_transform.position.y == 0 && m_transform.localScale.x == 0.2f)
        {
            m_FSM.TransitionState(StateType.SpawnAnimation);

        }

    }
    public void OnExit() //The method that should be executed to exit this state
    {
        // call OnExit() method by FSM
    }

    private class MonoSub : MonoBehaviour
    {

    }
}