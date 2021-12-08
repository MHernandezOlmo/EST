using System.IO;
using UnityEngine;
using UnityEditor;

public static class GitHooksInstaller
{
	const bool default_auto_install = false;

	const string toggle_menu = "GambusinoLabs/Git/Auto Install Hooks";
	const string install_menu = "GambusinoLabs/Git/Install Hooks";
	const string uninstall_menu = "GambusinoLabs/Git/Uninstall Hooks";

	const string post_checkout_path = "GitHooks/hooks/post-checkout";
	const string post_merge_path = "GitHooks/hooks/post-merge";
	const string pre_commit_path = "GitHooks/hooks/pre-commit";
	const string destination_relative_path = "../.git/hooks/";

	[InitializeOnLoadMethod]
	static void Init()
	{
		Uninstall();
		// EditorApplication.delayCall += () => MenuCheckbox();
		// if (EditorPrefs.GetBool(toggle_menu, true))
		// {
		// 	Install();
		// }
	}

	/// <summary>
	/// Toggles the menu.
	/// </summary>
	[MenuItem(toggle_menu)]
	static void ToggleAutoInstall()
	{
		// Check/Uncheck menu.
		bool isChecked = !Menu.GetChecked(toggle_menu);
		Menu.SetChecked(toggle_menu, isChecked);

		// Save to EditorPrefs.
		EditorPrefs.SetBool(toggle_menu, isChecked);

		Debug.Log("[EST] Git hooks auto install " + (isChecked ? "enabled" : "disabled"));
	}

	[MenuItem(toggle_menu, true)]
	static bool MenuCheckbox()
	{
		Menu.SetChecked(toggle_menu, EditorPrefs.GetBool(toggle_menu, default_auto_install));
		return true;
	}

	[MenuItem(install_menu)]
	static void Install()
	{
		var assetsDir = Application.dataPath + Path.DirectorySeparatorChar;
		var installed = false;

		if (!File.Exists(assetsDir + destination_relative_path + "post-checkout"))
		{
			File.Copy(assetsDir + post_checkout_path, assetsDir + destination_relative_path + "post-checkout");
			installed = true;
		}

		if (!File.Exists(assetsDir + destination_relative_path + "post-merge"))
		{
			File.Copy(assetsDir + post_merge_path, assetsDir + destination_relative_path + "post-merge");
			installed = true;
		}

		if (!File.Exists(assetsDir + destination_relative_path + "pre-commit"))
		{
			File.Copy(assetsDir + pre_commit_path, assetsDir + destination_relative_path + "pre-commit");
			installed = true;
		}

		if (installed)
		{
			Debug.Log("[EST] Git hooks has been installed");
		}
	}

	[MenuItem(uninstall_menu)]
	static void Uninstall()
	{
		var assetsDir = Application.dataPath + Path.DirectorySeparatorChar;
		var uninstalled = false;

		if (File.Exists(assetsDir + destination_relative_path + "post-checkout"))
		{
			File.Delete(assetsDir + destination_relative_path + "post-checkout");
			uninstalled = true;
		}

		if (File.Exists(assetsDir + destination_relative_path + "post-merge"))
		{
			File.Delete(assetsDir + destination_relative_path + "post-merge");
			uninstalled = true;
		}

		if (File.Exists(assetsDir + destination_relative_path + "pre-commit"))
		{
			File.Delete(assetsDir + destination_relative_path + "pre-commit");
			uninstalled = true;
		}

		if (uninstalled)
		{
			Debug.Log("[EST] Git hooks has been uninstalled");
		}
	}
}
