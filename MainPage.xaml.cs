﻿namespace TodoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TodoListViewModel();
        }
    }
}