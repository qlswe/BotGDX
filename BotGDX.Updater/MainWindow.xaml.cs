﻿using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows;

namespace Xalyus_Updater;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    readonly WebClient client = new(); // Webclient
    public MainWindow()
    {
        InitializeComponent();
        InitText(); // Load the text
        Global.ZIPLink = "https://raw.githubusercontent.com/Leo-Corporation/LeoCorp-Docs/master/Liens/Update%20System/Gavilya/Download.txt";
    }

    private void CloseBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void InitText()
    {
        switch (Thread.CurrentThread.CurrentUICulture.Name) // In each case for the language name
        {
            case "fr-FR": // If the language is French
                TitleTxt.Text = "Gavilya"; // Title
                DescriptionTxt.Text = "Gavilya est un lanceur de jeux vidéos."; // Description
                DownloadTxt.Text = "Téléchargement en cours"; // Download
                Global.InstallMessage = "Installation en cours"; // Installation message
                break;
            case "en-US": // If the language is English
                TitleTxt.Text = "Gavilya"; // Title
                DescriptionTxt.Text = "Gavilya is a simple a game launcher."; // Description
                DownloadTxt.Text = "Download in progress"; // Download
                Global.InstallMessage = "Installation in progress"; // Intallation message
                break;
            default: // Default
                TitleTxt.Text = "Gavilya"; // Title
                DescriptionTxt.Text = "Gavilya is a simple a game launcher."; // Description
                DownloadTxt.Text = "Download in progress"; // Download
                Global.InstallMessage = "Installation in progress"; // Intallation message
                break;
        }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        WebClient linkDownloader = new(); // Link downloader
        string link = linkDownloader.DownloadString(Global.ZIPLink); // Download the link

        client.DownloadProgressChanged += Client_DownloadProgressChanged; // Register event
        client.DownloadFileCompleted += Client_DownloadFileCompleted; // Register event

        if (!string.IsNullOrEmpty(link))
        {
            Thread thread = new(() =>
            {
                Uri uri = new(link);
                client.DownloadFileAsync(uri, Global.Directory); // Download
            });
            thread.Start();
        }
    }

    private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            Install();
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Gavilya.exe");
            Environment.Exit(0); // Close the app
        });
    }

    /// <summary>
    /// Install the update.
    /// </summary>
    private void Install()
    {
        DownloadTxt.Text = Global.InstallMessage; // Display the installation message

        try
        {
            ZipFile.ExtractToDirectory(Global.Directory, AppDomain.CurrentDomain.BaseDirectory, true); // Extract the files
            File.Delete(Global.Directory); // Delete the ZIP File
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occured:" + Environment.NewLine + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Show the error
        }
    }

    private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            double receive = double.Parse(e.BytesReceived.ToString()); // Total downloaded
            double total = double.Parse(e.TotalBytesToReceive.ToString()); // Total
            double percentage = receive / total * 100; // Calculate the percentage
            ProgressTxt.Text = $"{string.Format("{0:0.##}", percentage)}%"; // Show the progress
            Pgb.Value = int.Parse(Math.Truncate(percentage).ToString()); // Update the progress bar value
        });
    }
}