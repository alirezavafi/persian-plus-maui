﻿using CommunityToolkit.Maui.Views;
using PropertyChanged;
using System.Collections.Specialized;
using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.Popups
{
    [AddINotifyPropertyChangedInterface]
    public partial class DatePickerDialogPopup : Popup
    {
        #region Properties
        public DateTime InitialDate { get; }
        public DateTime SelectedDate { get; set; }
        public Calendar Calendar { get; } = new Calendar()
        {
            NavigatedDate = DateTime.Today,
            SelectedDates = new ObservableRangeCollection<DateTime>() { DateTime.Today },
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        #endregion

        #region Commands
        public ICommand ReturnSelectedDateCommand { get; set; }
        public ICommand ReturnInitialDateCommand { get; set; }
        public ICommand ResetNavigatedDateCommand { get; set; }
        #endregion

        #region Constructors
        public DatePickerDialogPopup(DateTime InitialDate)
        {
            ReturnSelectedDateCommand = new Command(ReturnSelectedDate);
            ReturnInitialDateCommand = new Command(ReturnInitialDate);
            ResetNavigatedDateCommand = new Command(ResetNavigatedDate);

            Calendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;

            this.InitialDate = InitialDate;
            ResultWhenUserTapsOutsideOfPopup = InitialDate;
            Calendar.SelectedDates.Replace(InitialDate);

            InitializeComponent();
            ResetNavigatedDate();
        }

        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SelectedDate = Calendar.SelectedDates.FirstOrDefault();
        }
        #endregion

        #region Methods
        public void ResetNavigatedDate()
        {
            Calendar.NavigatedDate = SelectedDate;
        }
        public void ReturnInitialDate()
        {
            Close(InitialDate);
        }
        public void ReturnSelectedDate()
        {
            Close(SelectedDate);
        }
        #endregion
    }
}