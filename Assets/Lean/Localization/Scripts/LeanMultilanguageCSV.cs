using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using Lean.Common;
using UnityEditor;
#endif

namespace Lean.Localization
{
	/// <summary>This component will load localizations from a CSV file. </summary>
	[ExecuteInEditMode]
	[HelpURL(LeanLocalization.HelpUrlPrefix + "LeanLanguageCSV")]
	[AddComponentMenu(LeanLocalization.ComponentPathPrefix + "Multilanguage CSV")]
	public class LeanMultilanguageCSV : LeanSource
	{
		[System.Serializable]
		public class MultilanguageEntry
		{
			public string Name;
			public string[] Translations;
		}

		public enum CacheType
		{
			LoadImmediately,
			LazyLoad,
			LazyLoadAndUnload,
			LazyLoadAndUnloadPrimaryOnly
		}

		/// <summary>The CSV text asset that contains all the translations.</summary>
		public TextAsset Source;

		/// <summary>The languages of the translations in the source file, one for each column.</summary>
		public string[] Languages;

		/// <summary>The character separating the CSV columns.</summary>
		public char ColumnSeparator = ';';

		/// <summary>This allows you to control when the CSV file is loaded or unloaded. The lower down you set this, the lower your app's memory usage will be. However, setting it too low means you can miss translations if you haven't translated absolutely every phrase in every language, so I recommend you use <b>LoadImmediately</b> unless you have LOTS of translations.
		/// LoadImmediately = Regardless of the language, the CSV will load when this compenent activates, and then it will be kept in memory until this component is destroyed.
		/// LazyLoad = The CSV file will only load when the <b>CurrentLanguage</b> or <b>DefaultLanguage</b> matches the CSV language, and then it will be kept in memory until this component is destroyed.
		/// LazyLoadAndUnload = Like <b>LazyLoad</b>, but translations will be unloaded if the <b>CurrentLanguage</b> or <b>DefaultLanguage</b> differs from the CSV language.
		/// LazyLoadAndUnloadPrimaryOnly = Like <b>LazyLoadAndUnload</b>, but only the <b>CurrentLanguage</b> will be used, the <b>DefaultLanguage</b> will be ignored.</summary>
		public CacheType Cache;

		/// <summary>This stores all currently loaded translations from this CSV file.</summary>
		public List<MultilanguageEntry> MultilanguageEntries { get { if (multilanguageEntries == null) multilanguageEntries = new List<MultilanguageEntry>(); return multilanguageEntries; } }
		[SerializeField] private List<MultilanguageEntry> multilanguageEntries;

		/// <summary>The characters used to separate each translation.</summary>
		private static readonly char[] newlineCharacters = new char[] { '\r', '\n' };

		private static Stack<MultilanguageEntry> multilanguageEntryPool = new Stack<MultilanguageEntry>();

		public override void Compile(string primaryLanguage, string defaultLanguage)
		{
			// Lazy load only?
			switch (Cache)
			{
				case CacheType.LazyLoad:
					{
						foreach (var l in Languages)
							if (l != primaryLanguage && l != defaultLanguage)
							{
								return;
							}
					}
					break;

				case CacheType.LazyLoadAndUnload:
					{
						foreach (var l in Languages)
							if (l != primaryLanguage && l != defaultLanguage)
							{
								Clear();

								return;
							}
					}
					break;

				case CacheType.LazyLoadAndUnloadPrimaryOnly:
					{
						foreach (var l in Languages)
							if (l != primaryLanguage)
							{
								Clear();

								return;
							}
					}
					break;
			}

			if (multilanguageEntries == null || multilanguageEntries.Count == 0)
			{
				if (Application.isPlaying == true)
				{
					LoadFromSource();
				}
			}

			if (multilanguageEntries != null)
			{
				for (var i = multilanguageEntries.Count - 1; i >= 0; i--)
				{
					var multilanguageEntry = multilanguageEntries[i];
					for (var j = multilanguageEntry.Translations.Length - 1; j >= 0; j--)
					{
						var translationText = multilanguageEntry.Translations[j];
						var translationObj = LeanLocalization.RegisterTranslation(multilanguageEntry.Name);

						translationObj.Register(Languages[j], this);

						if (Languages[j] == primaryLanguage)
						{
							translationObj.Data = translationText;
							translationObj.Primary = true;
						}
						else if (Languages[j] == defaultLanguage && translationObj.Primary == false)
						{
							translationObj.Data = translationText;
						}
					}
				}
			}
		}

		/// <summary>This will unload all translations from this component.</summary>
		[ContextMenu("Clear")]
		public void Clear()
		{
			if (multilanguageEntries != null)
			{
				multilanguageEntries.Clear();

				// Update translations?
				foreach (var l in Languages)
					if (LeanLocalization.CurrentLanguage == l)
					{
						LeanLocalization.UpdateTranslations();
					}
			}
		}

		/// <summary>This will load all translations from the CSV file into this component.</summary>
		[ContextMenu("Load From Source")]
		public void LoadFromSource()
		{
			if (Source != null && Languages.Length > 0)
			{
				for (var i = MultilanguageEntries.Count - 1; i >= 0; i--) // NOTE: Property
				{
					multilanguageEntryPool.Push(multilanguageEntries[i]);
				}

				multilanguageEntries.Clear();

				// Split file into lines, and loop through them all
				var lines = Source.text.Split(newlineCharacters, System.StringSplitOptions.RemoveEmptyEntries);

				for (var i = 0; i < lines.Length; i++)
				{
					var line = lines[i];
					var columns = line.Split(ColumnSeparator);

					var multilanguageEntry = multilanguageEntryPool.Count > 0 ? multilanguageEntryPool.Pop() : new MultilanguageEntry();
					multilanguageEntry.Name = columns[0];
					multilanguageEntry.Translations = new string[columns.Length - 1];
					for (var j = 0; j < multilanguageEntry.Translations.Length; j++)
					{
						multilanguageEntry.Translations[j] = columns[j + 1];
					}
					multilanguageEntries.Add(multilanguageEntry);
				}

				// Update translations?
				foreach (var l in Languages)
					if (LeanLocalization.CurrentLanguage == l)
					{
						LeanLocalization.UpdateTranslations();
					}
			}
		}
	}
}


#if UNITY_EDITOR
namespace Lean.Localization
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(LeanMultilanguageCSV), true)]
	public class LeanMultilanguageCSV_Inspector : LeanInspector<LeanMultilanguageCSV>
	{
		protected override void DrawInspector()
		{
			Draw("Source", "The CSV asset that contains all the translations.");
			Draw("Languages", "The languages of the translations in the source file, one for each column.");
			Draw("ColumnSeparator", "The character separating the CSV columns.");
			Draw("Cache", "This allows you to control when the CSV file is loaded or unloaded. The lower down you set this, the lower your app's memory usage will be. However, setting it too low means you can miss translations if you haven't translated absolutely every phrase in every language, so I recommend you use <b>LoadImmediately</b> unless you have LOTS of translations.\n\nLoadImmediately = Regardless of the language, the CSV will load when this compenent activates, and then it will be kept in memory until this component is destroyed.\n\nLazyLoad = The CSV file will only load when the <b>CurrentLanguage</b> or <b>DefaultLanguage</b> matches the CSV language, and then it will be kept in memory until this component is destroyed.\n\nLazyLoadAndUnload = Like <b>LazyLoad</b>, but translations will be unloaded if the <b>CurrentLanguage</b> or <b>DefaultLanguage</b> differs from the CSV language.\n\nLazyLoadAndUnloadPrimaryOnly = Like <b>LazyLoadAndUnload</b>, but only the <b>CurrentLanguage</b> will be used, the <b>DefaultLanguage</b> will be ignored.");

			EditorGUILayout.Separator();

			EditorGUILayout.BeginHorizontal();
			if (Any(t => t.MultilanguageEntries.Count > 0))
			{
				if (GUILayout.Button("Clear") == true)
				{
					Each(t => t.Clear());
				}
			}
			if (GUILayout.Button("Load Now") == true)
			{
				Each(t => t.LoadFromSource());
			}
			EditorGUILayout.EndHorizontal();

			if (tgts.Length == 1)
			{
				var entries = tgt.MultilanguageEntries;

				if (entries.Count > 0)
				{
					EditorGUILayout.Separator();

					EditorGUI.BeginDisabledGroup(true);
					foreach (var entry in entries)
					{
						int i = 0;
						foreach (var translation in entry.Translations)
						{
							EditorGUILayout.TextField($"{entry.Name} ({LeanLocalization.CurrentLanguages[tgt.Languages[i]].Cultures[0]})", translation);
							i++;
						}
					}
					EditorGUI.EndDisabledGroup();
				}
			}
		}
	}
}
#endif