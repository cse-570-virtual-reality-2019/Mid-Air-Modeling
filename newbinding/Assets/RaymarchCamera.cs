using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class RaymarchCamera : SceneViewFilter 
{
	[SerializeField]
	private Shader _shader;

	public Material _raymarchMaterial
	{
		get
		{
			if(!_raymarchMat && _shader)
			{
				_raymarchMat = new Material(_shader);
				_raymarchMat.hideFlags = HideFlags.HideAndDontSave;
			}
			return _raymarchMat;
		}
	}

	private Material _raymarchMat;
	public Camera _camera
	{
		get
		{
			if(!_cam)
			{
				_cam = GetComponent<Camera>();
			}
			return _cam;
		}
	}
	private Camera _cam;

	public Transform _directionalLight;

	public float _maxDistance;
	public Color _mainColor;
	public Vector4 _sphere1;
	public Vector4 _box1;
	public Vector4 _cylinder1;
	public Vector4 _cone1;
	public Vector4 _capsule1;
	public float _fl;
	public bool check;
	public float[] arr;
	public GameObject obj1;
	public float _op;
	private bool flag;
	public float Isshape1;
	public float Isshape2;

	void start(){
		flag=false;
	}
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		// if(!flag && !_raymarchMaterial)
		if(!_raymarchMaterial)
		{
			Graphics.Blit(source, destination);
			return;
		}
		obj1=GameObject.Find("GameObject");
		_op=obj1.GetComponent<operations>().x1;
		Debug.Log(_op);
		// Debug.Log(_op);
		// Debug.Log(flag);
		if(flag==false){
			// Debug.Log("yo");
			if(GameObject.Find("Cube").GetComponent<isShape>().isFirst){
				Isshape1=1;
			}
			else if(GameObject.Find("Sphere").GetComponent<isShape>().isFirst){
				Isshape1=2;
			}
			else{
				Isshape1=3;
			}
			if(GameObject.Find("Cube").GetComponent<isShape>().isSecond){
				Isshape2=1;
			}
			else if(GameObject.Find("Sphere").GetComponent<isShape>().isSecond){
				Isshape2=2;
			}
			else{
				Isshape2=3;
			}
			Debug.Log(Isshape1);
			Debug.Log(Isshape2);
			Vector3 pos1=GameObject.Find("Cube").GetComponent<Transform>().position;
			Vector3 pos2=GameObject.Find("Sphere").GetComponent<Transform>().position;
			Vector3 pos3=GameObject.Find("Cylinder").GetComponent<Transform>().position;
			GameObject.Find("Cylinder").GetComponent<destroy>().enabled=false;
			GameObject.Find("Cube").GetComponent<destroy>().enabled=false;
			GameObject.Find("Sphere").GetComponent<destroy>().enabled=false;
			(GameObject.Find("Cylinder")).SetActive(false);
			(GameObject.Find("Cube")).SetActive(false);
			(GameObject.Find("Sphere")).SetActive(false);
			_box1.x=pos1.x;
			_box1.y=pos1.y;
			_box1.z=pos1.z;
			_sphere1.x=pos2.x;
			_sphere1.y=pos2.y;
			_sphere1.z=pos2.z;
			_cylinder1.x=pos3.x;
			_cylinder1.y=pos3.y;
			_cylinder1.z=pos3.z;
			// _box1.x=GameObject.Find("Cube").GetComponent<Transform>().position.x;
			// _box1.y=GameObject.Find("Cube").GetComponent<Transform>().position.y;
			// _box1.z=GameObject.Find("Cube").GetComponent<Transform>().position.z;
			// _sphere1.x=GameObject.Find("Sphere").GetComponent<Transform>().position.x;
			// _sphere1.y=GameObject.Find("Sphere").GetComponent<Transform>().position.y;
			// _sphere1.z=GameObject.Find("Sphere").GetComponent<Transform>().position.z;			
			// GameObject.Find("Sphere").SetActive(false);
			flag=true;				
		}
		
		// GameObject.Find("Cube").GetComponent<MeshRenderer>().enabled=false;
		// GameObject.Find("Sphere").GetComponent<MeshRenderer>().enabled=false;
		// }
		
		// GameObject.Find("Cube").SetActive(false);
		// GameObject.Find("Cube").GetComponent<Renderer>().enabled=false;
		// GameObject.Find("Sphere").GetComponent<Renderer>().enabled=false;		
		// flag=true;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.x;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.y;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.z;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.x;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.y;
		// _box1.x=GameObject.Find("GameObject").GetComponent<Transform>().position.z;


		// _op=1;
		// arr=obj1.GetComponent<switchScene>().shapes;
		// for(int i=0; i<arr.Length; i++){	
			// Debug.Log(arr[i]);
		// }
		// Debug.Log(check);
		// obj1=GameObject.Find("Sphere");
		// check=obj1.GetComponent<switchScene>().flag;
		// Debug.Log(check);
		// Debug.Log(obj1.GetComponent<bool>());
		// obj1.SetActive(false);
		// check=GameObject.Find("Sphere").GetComponent<flag>();
		// if(!flag){
		_raymarchMaterial.SetVector("_LightDir", _directionalLight ? _directionalLight.forward : Vector3.down); 
		_raymarchMaterial.SetMatrix("_CamFrustum", CamFrustum(_camera));
		_raymarchMaterial.SetMatrix("_CamToWorld", _camera.cameraToWorldMatrix);
		_raymarchMaterial.SetFloat("_maxDistance", _maxDistance);
		_raymarchMaterial.SetVector("_sphere1", _sphere1);
		_raymarchMaterial.SetVector("_box1", _box1);
		_raymarchMaterial.SetVector("_cylinder1", _cylinder1);
		_raymarchMaterial.SetVector("_cone1", _cone1);		
		_raymarchMaterial.SetColor("_mainColor", _mainColor);
		_raymarchMaterial.SetFloat("_fl",_fl);
		_raymarchMaterial.SetFloat("_op",_op);
		_raymarchMaterial.SetFloat("_b1",Isshape1);
		_raymarchMaterial.SetFloat("_b2",Isshape2);
		RenderTexture.active = destination;
		_raymarchMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		_raymarchMaterial.SetPass(0);
		GL.Begin(GL.QUADS);

		//BL
		GL.MultiTexCoord2(0, 0.0f, 0.0f);
		GL.Vertex3(0.0f, 0.0f, 3.0f);

		//BR
		GL.MultiTexCoord2(0, 1.0f, 0.0f);
		GL.Vertex3(1.0f, 0.0f, 2.0f);

		//TR
		GL.MultiTexCoord2(0, 1.0f, 1.0f);
		GL.Vertex3(1.0f, 1.0f, 1.0f);

		//TL
		GL.MultiTexCoord2(0, 0.0f, 1.0f);
		GL.Vertex3(0.0f, 1.0f, 0.0f);

		GL.End();
		GL.PopMatrix();
		// }
	}
	void Update()
    {
        // Debug.Log(_fl);
    }
	private Matrix4x4 CamFrustum(Camera cam)
	{
		Matrix4x4 frustum = Matrix4x4.identity;
		float fov = Mathf.Tan((cam.fieldOfView * 0.5f) * Mathf.Deg2Rad);

		Vector3 goUp = Vector3.up * fov;
		Vector3 goRight = Vector3.right * fov * cam.aspect;

		Vector3 TL = (-Vector3.forward - goRight + goUp);
		Vector3 TR = (-Vector3.forward + goRight + goUp);
		Vector3 BR = (-Vector3.forward + goRight - goUp);
		Vector3 BL = (-Vector3.forward - goRight - goUp);

		frustum.SetRow(0, TL);
		frustum.SetRow(1, TR);
		frustum.SetRow(2, BR);
		frustum.SetRow(3, BL);
		
		return frustum;
	}

}
