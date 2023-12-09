﻿using ReadingClub.models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomControl.xaml
    /// </summary>
    public partial class RoomControl : UserControl
    {

        public RoomControl()
        {
            InitializeComponent();
        }

        public void SetRoomData(Room room)
        {
            roomName.Content = room.Name;
            roomDescription.Text = room.Description;

            try
            {
                var imagePath = new Uri($"pack://application:,,,/assets/images/{room.Image}", UriKind.RelativeOrAbsolute);
                BitmapImage image = new BitmapImage(imagePath);
                roomImage.Source = image;
            }
            catch (Exception ex) { 
                Console.WriteLine("Error loading image: " + ex.Message);
            }
        }
    }
}