﻿using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Windows;
using System.Windows.Controls;


namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomList.xaml
    /// </summary>
    public partial class RoomList : UserControl
    {
        public event EventHandler BackButtonClicked;
        public event EventHandler<RoomEventArgs> RoomNavigateButtonClicked;
        private List<Room> rooms = new List<Room>();
        public RoomList()
        {
            InitializeComponent();
            LoadRooms();
            PopulateRooms();
        }

        private void LoadRooms()
        {
            rooms = DatabaseHelper.GetRooms(GlobalData.LoggedInUser.id);
        }

        private void PopulateRooms()
        {
            foreach (var room in rooms)
            {
                RoomControl roomControl = new RoomControl();
                roomControl.SetRoomData(room);
                roomControl.NavigateButtonClicked += (sender, e) =>
                {
                    RoomNavigateButtonClicked?.Invoke(this, new RoomEventArgs(room.ID));
                };
                roomsList.Children.Add(roomControl);
            }
        }


        private void OnClickViewList(object sender, RoutedEventArgs e)
        {
            // Assuming that your UserControl is hosted within a Window
            /*Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                // Navigate to MyList page
                parentWindow.Content = new MyList();
            }*/

            BackButtonClicked?.Invoke(sender, EventArgs.Empty);
        }

    }
}
