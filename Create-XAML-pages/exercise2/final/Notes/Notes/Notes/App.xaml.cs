﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace Notes
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override IWindow CreateWindow(IActivationState activationState)
		{
			this.On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>()
				.SetImageDirectory("Assets");

			return new Microsoft.Maui.Controls.Window(new UIPage());
		}
	}
}
