﻿using System;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class CalendarDay : BaseObservableModel, ICalendarDay
    {
        #region Fields
        private DateTime? _DateTime = System.DateTime.Today;
        #endregion

        #region Properties
        public DateTime? DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                if (_DateTime != value)
                {
                    _DateTime = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}