using Popup = UISystem.Popup;

namespace Games.UI
{
	public class PausePopup : Popup
	{
		//unity callbacks
		public override void Awake()
		{
			base.Awake();
		}

		//public methods
		public void OnClickClose()
		{
			Hide();
		}

		//Popup Callbacks
		public override void Show()
		{
			base.Show();
		}
		public override void Hide()
		{
			base.Hide();
		}
		public override void Disable()
		{
			base.Disable();
		}
		public override void Redraw()
		{
			base.Redraw();
		}

	}
}
