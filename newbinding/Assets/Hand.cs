using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
	public SteamVR_Action_Boolean m_GrabAction = null;
	public GameObject obj;
	private SteamVR_Behaviour_Pose m_Pose = null;
	private FixedJoint m_Joint = null;

	private Interactable m_CurrentInteractable = null;
	public List<Interactable> m_ContactInteractables = new List<Interactable>();

	private void Awake()
	{
		m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
		m_Joint = GetComponent<FixedJoint>();
	}

	private void Update()
	{
		if(m_GrabAction.GetStateDown(m_Pose.inputSource))
		{
			Debug.Log(m_Pose.inputSource + "Trigger Down");
			Pickup();
		}

		if(m_GrabAction.GetStateUp(m_Pose.inputSource))
		{
			Debug.Log(m_Pose.inputSource + "Trigger Up");
			Drop();
		}
	}

	// private void OnTriggerEnter(Collider other)
	// {
	// 	Debug.Log("Andar aaya");
	// 	if(!other.gameObject.CompareTag("Interactable"))
	// 	{
	// 		return;
	// 	}
	// 	Debug.Log("daal diya");
	// 	// m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());

	// }
	private void OnTriggerStay(Collider other)
	{
		// Debug.Log("Andar aaya");
		// if(!other.gameObject.CompareTag("Interactable"))
		// {
			// return;
		// }
		if (other.CompareTag("Interactable"))
        {
            obj = other.gameObject;
			// Debug.Log("Pakad liya");
        }
		// Debug.Log("daal diya");
		// m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());

	}

	// private void OnTriggerExit(Collider other)
	// {
	// 	if(!other.gameObject.CompareTag("Interactable"))
	// 	{
	// 		return;
	// 	}
	// 	Debug.Log("Bahar aaya");
	// 	m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
	// }
	void OnTriggerExit(Collider other){
		obj=null;
	}
	// public void Pickup()
	// {
	// 	m_CurrentInteractable = GetNearestInteractables();
	// 	Debug.Log(m_CurrentInteractable.tag);
	// 	Debug.Log("Pickup called");

	// 	if(!m_CurrentInteractable)
	// 	{
	// 		Debug.Log("Not current Interactable");
	// 		return;
	// 	}

	// 	if(m_CurrentInteractable.m_ActiveHand)
	// 	{
	// 		Debug.Log("Pickup mai chor diya");
	// 		m_CurrentInteractable.m_ActiveHand.Drop();

	// 	}
	// 	Debug.Log("Pickup mai aur andar aa gaya");
	// 	Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
	// 	Debug.Log(targetBody.mass);
	// 	m_Joint.connectedBody = targetBody;
	// 	m_CurrentInteractable.m_ActiveHand = this;
	// }
	void Pickup(){
		Debug.Log(GameObject.Find("GameObject").GetComponent<operations>().x2);
		Debug.Log(GameObject.Find("GameObject").GetComponent<operations>().x3);
		if(obj!=null && obj.CompareTag("Interactable")){
		if(GameObject.Find("GameObject").GetComponent<operations>().x2==0){
			GameObject.Find("GameObject").GetComponent<operations>().x2=1;
			// GameObject.Find("GameObject").GetComponent<operations>().x4=1;
			Debug.Log(obj.name);
			GameObject.Find("GameObject").GetComponent<operations>().name=string.Copy(obj.name);
			Debug.Log(GameObject.Find("GameObject").GetComponent<operations>().name);
			// if(obj.name.CompareTo("Sphere"))
			obj.GetComponent<isShape>().isFirst=true;
			// obj.GetComponent<isShape>().isFirst=true;
		}
		else if(GameObject.Find("GameObject").GetComponent<operations>().x2==1){
			if(obj.name.CompareTo(GameObject.Find("GameObject").GetComponent<operations>().name)!=0){
			if(GameObject.Find("GameObject").GetComponent<operations>().x3==0){
				GameObject.Find("GameObject").GetComponent<operations>().x3=1;
				obj.GetComponent<isShape>().isSecond=true;
		}
		}
		}
		if(obj!=null){
			m_Joint.connectedBody=obj.GetComponent<Rigidbody>();
		}
	}
	}
	// public void Drop()
	// {
	// 	Debug.Log("Drop");
	// 	if(!m_CurrentInteractable)
	// 	{
	// 		return;
	// 	}

	// 	Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
	// 	targetBody.velocity = m_Pose.GetVelocity();
	// 	targetBody.angularVelocity = m_Pose.GetAngularVelocity();

	// 	m_Joint.connectedBody = null;

	// 	m_CurrentInteractable.m_ActiveHand=null;
	// 	m_CurrentInteractable=null;
	// }
	void Drop(){
		Debug.Log("Drop");
		if(m_Joint.connectedBody!=null){
			m_Joint.connectedBody=null;
		}
	}
	// private Interactable GetNearestInteractables()
	// {
	// 	Interactable nearest = null;
	// 	float minDistance = float.MaxValue;
	// 	float distance = 0.0f;

	// 	foreach(Interactable i in m_ContactInteractables)
	// 	{
	// 		Debug.Log("Get Nearest loop");
	// 		distance = (i.transform.position - transform.position).sqrMagnitude;

	// 		if(distance < minDistance)
	// 		{
	// 			minDistance = distance;
	// 			nearest = i;
	// 		}
	// 	}
	// 	Debug.Log(nearest.tag);
	// 	return nearest;
	// }
}
