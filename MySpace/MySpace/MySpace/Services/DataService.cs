using MySpace.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.Services
{
    public class DataService
    {
        static HttpClient httpClient = new HttpClient();

        readonly string serverUrl = "https://api.nasa.gov";

        readonly string apiKey = "azigzxG1NOJoc060MjcIxLfknnKUWmkr6vOBAWA2";

        public async Task<PhotoOfTheDay> GetPhotoOfTheDayAsync()
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            var infoJson = await httpClient.GetStringAsync($"{serverUrl}/planetary/apod?api_key={apiKey}&date={dateToday}");

            var photoOfTheDay = JsonConvert.DeserializeObject<PhotoOfTheDay>(infoJson);

            return photoOfTheDay;
        }

        public async Task<MarsRoverPhotos> GetRoverPhotosAsync(int sol, int page)
        {
            var infoJson = await httpClient.GetStringAsync($"{serverUrl}/mars-photos/api/v1/rovers/curiosity/photos?api_key={apiKey}&sol={sol}&page={page}");

            var marsRoverPhotos = JsonConvert.DeserializeObject<MarsRoverPhotos>(infoJson);

            return marsRoverPhotos;
        }
    }
}
