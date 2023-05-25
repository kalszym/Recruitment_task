using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Object_text : MonoBehaviour
{
    [Serializable]
    public class OnDestroyEvent : UnityEvent { }

    [FormerlySerializedAs("IfDestroy")]
    [SerializeField]
    private OnDestroyEvent m_OnDestroy = new OnDestroyEvent();
   
    public TextScriptableObject obj;
    public TextMesh nameobj;
    public TextMesh material;
    public TextMesh strenght;
    public ParticleSystem destroy;
    public ParticleSystem explode;
    public GameObject[] Component;

    

    public float health;
    private void Start()
    {
        nameobj.text = obj.nameobje;
        material.text = obj.material;
        strenght.text = obj.strenght.ToString();
        health = obj.strenght;
    }
    void Update()
    {

       nameobj.transform.forward = Camera.main.transform.forward;
        material.transform.forward = Camera.main.transform.forward;
        strenght.transform.forward = Camera.main.transform.forward;

    }
    public void SubtractPoints(float points)
    {
       
        if (points >= health)
        {
            GameManager.pointToEnd--;
            explode.Play();
            m_OnDestroy.Invoke();
            this.gameObject.SetActive(false);
            

        }
        else destroy.Play();

        
            
    }
    public OnDestroyEvent onDestroy
    {
        get { return m_OnDestroy; }
        set { m_OnDestroy = value; }
    }
}
