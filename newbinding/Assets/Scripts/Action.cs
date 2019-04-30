using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean unionAction; // 2
    public SteamVR_Action_Boolean subtractAction; // 3
    public SteamVR_Action_Boolean switchAction;
    public SteamVR_Action_Boolean intersectAction;
    public GameObject obj1;
    void Start(){
        obj1=GameObject.Find("GameObject");
        Debug.Log("dasda");
    }
    void Update()
    {
        
        if (GetUnionDown())
        {
            Debug.Log("Union" + handType);
            // obj1=GameObject.Find("GameObject");
		    obj1.GetComponent<operations>().x1=1;
            SceneManager.LoadScene("MainScene");
        }

        if (GetSubtract())
        {
            Debug.Log("Subtract" + handType);
            obj1.GetComponent<operations>().x1=2;
            SceneManager.LoadScene("MainScene");            
        }

        if (GetIntersection())
        {
            Debug.Log("Intersection" + handType);
            obj1.GetComponent<operations>().x1=3;
            SceneManager.LoadScene("MainScene");
        }        

        if(GetSwitch())
        {
            Debug.Log("Switch" + handType);
        }
    }

    public bool GetUnionDown() // 1
    {
        return unionAction.GetStateDown(handType);
    }

    public bool GetSubtract() // 2
    {
        return subtractAction.GetState(handType);
    }

    public bool GetIntersection()
    {
        return intersectAction.GetState(handType);
    }

    public bool GetSwitch()
    {
        return switchAction.GetState(handType);
    }
}
