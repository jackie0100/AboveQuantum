using UnityEngine;
using UnityEngine.Rendering;

public class TwinCameraController : MonoBehaviour
{
	[SerializeField]
	private Camera _activeCamera;
	[SerializeField]
	private Camera _hiddenCamera;

	public void SwapCameras()
	{
		_activeCamera.targetTexture = _hiddenCamera.targetTexture;
		_hiddenCamera.targetTexture = null;

		var swapCamera = _activeCamera;
		_activeCamera = _hiddenCamera;
		_hiddenCamera = swapCamera;
    }
	
	/// <summary>
	/// Set up our RT and 
	/// </summary>
	private void Awake()
	{
		var rt = new RenderTexture(Screen.width, Screen.height, 24);
		Shader.SetGlobalTexture("_TimeCrackTexture", rt);
		_hiddenCamera.targetTexture = rt;
    }
}
