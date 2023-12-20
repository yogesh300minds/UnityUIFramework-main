using UnityEngine;
using UnityEngine.Video;

namespace UISystem
{

	public class BaseUI : MonoBehaviour
	{
		[HideInInspector]
		public GameObject content;
		[HideInInspector]
		public Canvas canvas;
		[HideInInspector] public UIAnimator uiAnimator;
		[HideInInspector] public UIAnimation uiAnimation;
		[HideInInspector]
		public CanvasGroup canvasGroup;
		public bool isActive { get; private set; }

		public virtual void Awake()
		{
			content = transform.GetChild(0).gameObject;
			canvas = GetComponent<Canvas>();
			canvasGroup = content.GetComponent<CanvasGroup>();

			uiAnimator = GetComponent<UIAnimator>();
			uiAnimation = GetComponent<UIAnimation>();
		}
		public virtual void Disable()
		{
			canvas.enabled = false;
			isActive = false;

			//if (ViewController.instance.popupBG.activeInHierarchy)
			//{
			//	ViewController.instance.popupBG.SetActive(false);
			//}

		}//screws with the joysticks because apparently they scale (what?)// content.SetActive(false);

		public virtual void Enable()
		{

			canvas.enabled = true;//screws with the joysticks because apparently they scale (what?)// content.SetActive(true);
			isActive = true;
		}


		public virtual void Show()
		{

			if (isActive)
				return; 

			canvasGroup.interactable = true;
			if (uiAnimator)
			{
				uiAnimator.StopHide();
				uiAnimator.StartShow();
				isActive = true;
			}
			else
			{
				Enable();
				isActive = true;
			}
			Redraw();
		}

		public virtual void Hide()
		{
			if (!isActive)
				return;
			canvasGroup.interactable = false;
			if (uiAnimator)
			{
				uiAnimator.StopShow();
				uiAnimator.StartHide();
				isActive = false;
			}
			else
			{
				Disable();
				isActive = false;
			}
		}
		public virtual void Redraw()
		{
		}
	}
}