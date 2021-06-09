﻿using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Notes
{
	public partial class MainPage : ContentPage, IPage
	{
		string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        Editor editor;

		public MainPage()
		{
            var stackLayout = new StackLayout();
            this.Content = stackLayout;
            this.Content.Margin = new Thickness(10, 10, 10, 10);

            var mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            stackLayout.Add(mainGrid);

            var notesHeading = new Label() { Text = "Notes", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            Grid.SetRow(notesHeading, 0);
            mainGrid.Children.Add(notesHeading);

            editor = new Editor() { Placeholder = "Enter your note", HeightRequest = 100 };
            Grid.SetRow(editor, 1);
            mainGrid.Children.Add(editor);

            var buttonsGrid = new Grid() { HeightRequest = 40.0 };
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
            Grid.SetRow(buttonsGrid, 2);
            mainGrid.Children.Add(buttonsGrid);

            var saveButton = new Button() { WidthRequest = 100, Text = "Save" };
            saveButton.Clicked += OnSaveButtonClicked;
            Grid.SetColumn(saveButton, 0);
            buttonsGrid.Children.Add(saveButton);

            var deleteButton = new Button() { WidthRequest = 100, Text = "Delete" };
            deleteButton.Clicked += OnDeleteButtonClicked;
            Grid.SetColumn(deleteButton, 1);
            buttonsGrid.Children.Add(deleteButton);

            if (File.Exists(_fileName))
			{
				editor.Text = File.ReadAllText(_fileName);
			}
		}

		void OnSaveButtonClicked(object sender, EventArgs e)
		{
			File.WriteAllText(_fileName, editor.Text);
		}

		void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			if (File.Exists(_fileName))
			{
				File.Delete(_fileName);
			}
			editor.Text = string.Empty;
		}
	}
}
