using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meetins.Frontend.Components
{
    public partial class CalendarComponent:ComponentBase
    {
        private LinkedList<DateTime> _calendar { get; set; } = new LinkedList<DateTime>();
        private DateTime _chooseDate;
        private TimeSpan _deltaTime = new TimeSpan(1, 0, 0, 0);

        protected override async Task OnInitializedAsync()
        {
            GetCalendar();
        }
        public void GetCalendar()
        {
            var capacity = 10;
            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day);
            _chooseDate = date;
            for (var i = 0; i < capacity; i++)
            {
                _calendar.AddLast(date);
                date = date.Add(_deltaTime);
            }
        }
        private void GoLeft()
        {
            var date = _calendar.First.Value;
            date = date.Subtract(_deltaTime);
            _calendar.AddFirst(date);
            _calendar.RemoveLast();
        }
        private void GoRight()
        {
            var date = _calendar.Last.Value;
            date = date.Add(_deltaTime);
            _calendar.AddLast(date);
            _calendar.RemoveFirst();
        }
        private void SetActiveDate(DateTime date)
        {
            _chooseDate = date;
            StateHasChanged();
        }
    }
}
