using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace MoodleSharp.MVVM
{
    class EventViewModel
    {
        List<EventCategory> Items { get; set; }

        private EventViewModel() { }

        public async Task<EventViewModel> InitializeAsync()
        {
            try
            {
                IStorageFile storageFile = await Package.Current.InstalledLocation.GetFileAsync(@"MVVM\MOCK_DATA.json");
                string jsonString = await FileIO.ReadTextAsync(storageFile);
                List<Event> events = JsonConvert.DeserializeObject<List<Event>>(jsonString);
                Items = events.GroupBy(x => x.Category)
                    .Select(x => new EventCategory() { Title = x.Key, Events = x.ToList() }).ToList();
                return this;
            }
            catch (Exception exception)
            {
                await new MessageDialog(exception.Message).ShowAsync();
                throw;
            }
        }

        public static Task<EventViewModel> CreateTaskAsync()
        {
            EventViewModel eventViewModel = new EventViewModel();
            return eventViewModel.InitializeAsync();
        }
    }
}
