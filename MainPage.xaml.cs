using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.XForms.RichTextEditor;

namespace todolistXamarin
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "toDo.txt");

		public MainPage()
		{
			InitializeComponent();

			if (File.Exists(_fileName))
			{
				// on startup, load file from cloud. If cannot load from cloud, load locally
				richTextEditor.Text = File.ReadAllText(_fileName);
			}
		}

		async void OnPushButtonClicked(object sender, EventArgs e)
		{
			// Save to local, then upload to cloud

			// Save locally
			string HTMLText = richTextEditor.GetHtmlString();

			File.WriteAllText(_fileName, HTMLText);

			await DisplayAlert("Push Status", "Pushed locally", "OK");
		}

		async void OnPullButtonClicked(object sender, EventArgs e)
		{
			if (File.Exists(_fileName))
			{
				// load file from cloud. If cannot load from cloud, load locally

				// load locally
				richTextEditor.Text = File.ReadAllText(_fileName);

				await DisplayAlert("Pull Status", "Pulled locally", "OK");
			}
		}
	}
}
