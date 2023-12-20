using UnityEngine;

public enum DeviceType
{
	Tablet,
	Phone
}

public static class DeviceTypeChecker
{
	public static bool isTablet;
	public static DeviceType deviceType;

	private static float DeviceDiagonalSizeInInches()
	{
		float screenWidth = Screen.width / Screen.dpi;
		float screenHeight = Screen.height / Screen.dpi;
		float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
		//Debug.Log("device diagonal inches: " + diagonalInches);
		return diagonalInches;
	}

	public static void GetDeviceType()
	{
#if UNITY_EDITOR
		float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
		bool isTab = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);
		if (isTab)
		{
			deviceType = DeviceType.Tablet;
			return;
		}
		else
		{
			deviceType = DeviceType.Phone;
			return;
		}
#elif UNITY_IOS
		bool isIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
		if (isIpad)
		{
			//return DeviceType.Tablet;
			deviceType = DeviceType.Tablet;
			Debug.Log("ios tablet Device");
			return;
		}
		bool isIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
		if (isIphone)
		{
			//return DeviceType.Phone;
			deviceType = DeviceType.Phone;
			Debug.Log("ios mobile Device");
			return;
		}
#elif UNITY_ANDROID
		float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
		bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);
		if (isTablet)
		{
			//return DeviceType.Tablet;
			deviceType = DeviceType.Tablet;
			Debug.Log("android tablet Device");
			return;
		}
		else
		{
			//return DeviceType.Phone;
			deviceType = DeviceType.Phone;
			Debug.Log("android mobile Device");
			return;
		}
#endif
	}

}
