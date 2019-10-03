using MySpace.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.Services
{
    public class DataService
    {
        static HttpClient httpClient = new HttpClient();

        readonly string serverUrl = "https://api.nasa.gov";
        readonly string epicServerUrl = "https://epic.gsfc.nasa.gov";

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

        public async Task<List<EarthImageMetaData>> GetEarthImagesMetadataAsync()
        {
            string year = "2018";
            string month = "09";
            string day = "20";
            var infoJson = await httpClient.GetStringAsync($"{serverUrl}/EPIC/api/natural/date/{year}-{month}-{day}?api_key={apiKey}");

            var earthImages = JsonConvert.DeserializeObject<List<EarthImageMetaData>>(infoJson);

            if(earthImages != null && earthImages.Any())
            {
                foreach(var earthImage in earthImages)
                {
                    earthImage.img_src = $"{epicServerUrl}/archive/natural/{year}/{month}/{day}/png/{earthImage.image}.png";
                }
            }

            return earthImages;
        }
    }
}
