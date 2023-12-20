using System.Collections.Generic;
using UnityEngine;

namespace UISystem
{
	public class ViewController : Singleton<ViewController>
	{
		public Screen currentView;
		Screen previousView;
		[SerializeField] ScreenName initScreen;
		public bool isPopupOpen = false;
		[Divider]
		[SerializeField] List<ScreenView> screens = new List<ScreenView>();
		[Divider]
		[SerializeField] List<PopupView> popups = new List<PopupView>();

		[System.Serializable]
		public struct ScreenView
		{
			public Screen screen;
			public ScreenName screenName;
		}

		[System.Serializable]
		public struct PopupView
		{
			public Popup popup;
			public PopupName popupName;
		}

		public void HideAllPopups()
		{
			foreach (PopupView p in popups)
			{
				HidePopup(p.popupName);
			}
		}

		public void ShowLoading()
		{
			ShowPopup(PopupName.LoadingPopup); // load any loading screen
		}

		public void HideLoading()
		{
			HidePopup(PopupName.LoadingPopup); // hide loading screen 
		}

		public override void Awake()
		{
			base.Awake();

			DeviceTypeChecker.GetDeviceType(); 
			if (DeviceTypeChecker.deviceType == DeviceType.Phone)
			{
				Debug.Log("Mobile Device");
			}
			else
			{
				Debug.Log("Tablet Device");
			}
			Helper.SafeDestroy(gameObject);
		}

		void Start()
		{
			Init();
		}

		public void ShowPopup(PopupName popupName)
		{
			popups[GetPopupIndex(popupName)].popup.Show();
		}

		public void HidePopup(PopupName popupName)
		{
			popups[GetPopupIndex(popupName)].popup.Hide();
		}

		public void ChangeView(ScreenName screen)
		{
			if (currentView != null)
			{
				previousView = currentView;
				previousView.Hide();
				currentView = screens[GetScreenIndex(screen)].screen;
				currentView.Show();
			}
			else
			{
				currentView = screens[GetScreenIndex(screen)].screen;
				currentView.Show();
			}
		}

		int GetScreenIndex(ScreenName screen)
		{
			return screens.FindIndex(
			delegate (ScreenView screenView)
			{
				return screenView.screenName.Equals(screen);
			});
		}

		// take type of popupName as parameter that you want to find and return its index 
		int GetPopupIndex(PopupName popup)
		{
			return popups.FindIndex(
			delegate (PopupView popupView)
			{
				return popupView.popupName.Equals(popup);
			});
		}

		public void RedrawView() => currentView.Redraw();

		public float animationTime;

		private void Init()
		{
			// Disables all screens and setting default animation time
			for (int indexOfScreen = 0; indexOfScreen < screens.Count; indexOfScreen++)
			{
				screens[indexOfScreen].screen.Disable();
				screens[indexOfScreen].screen.uiAnimator.animationTime = animationTime;
			}

			// Disables all popup screens and setting default animation time
			for (int indexOfPopup = 0; indexOfPopup < popups.Count; indexOfPopup++)
			{
				popups[indexOfPopup].popup.Disable();
				popups[indexOfPopup].popup.uiAnimator.animationTime = animationTime;
			}

			if (initScreen != ScreenName.None)
			{
				ChangeView(initScreen);
			}
		}

		public T GetScreen<T>(ScreenName sName) => (T)screens[GetScreenIndex(sName)].screen.GetComponent<T>();
		public T GetPopup<T>(PopupName sName) => (T)popups[GetPopupIndex(sName)].popup.GetComponent<T>();
	}
}