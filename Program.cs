using System;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace FirstApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string URL = "https://www.youtube.com/watch?v=3mhq_gcu9KM";
            VideoManager manager = new VideoManager();
            YoutubeVideo video = new YoutubeVideo(URL);
            manager.SetComand(new YuotubeComand(video));
            await manager.ShowVideoInfo();
            await manager.DownloadVideo();

            //var youtube = new YoutubeClient();
            //var video = await youtube.Videos.GetAsync(URL);
            //Console.WriteLine($"{video.Title}\n{video.Description}\n{video.Author}\n{video.Duration}");
            //await youtube.Videos.DownloadAsync(URL, "video.mp4");
            //Console.WriteLine("Downloading finished");
        }
    }
    public interface IVideoComand
    {
        public async Task Download() { }
        public async Task ShowInfo() { }
    }

    internal class YuotubeComand : IVideoComand
    {
        private YoutubeVideo video;
        public YuotubeComand(YoutubeVideo video)
        {
            this.video = video;
        }

        public async Task Download()
        {
            await video.DownloadAsync();
        }

        public async Task ShowInfo()
        {
            await video.ShowInfoAsync();
        }
    }

    internal class YoutubeVideo
    {
        private string videoUrl;
        private YoutubeClient youtube;

        public YoutubeVideo(string videoUrl)
        {
            this.videoUrl = videoUrl;
            youtube = new YoutubeClient();
        }

        public async Task DownloadAsync()
        {
            await youtube.Videos.DownloadAsync(videoUrl, "video.mp4");
            Console.WriteLine("Downloading finished");
        }
        public async Task ShowInfoAsync()
        {
            var video = await youtube.Videos.GetAsync(videoUrl);
            Console.WriteLine($"{video.Title}\n{video.Description}\n{video.Author}\n{video.Duration}");
        }
    }

    internal class VideoManager
    {
        private IVideoComand Comand;
        internal async Task DownloadVideo()
        {
            await Comand.Download();
        }

        internal async Task ShowVideoInfo()
        {
            await Comand.ShowInfo();
        }

        internal void SetComand (IVideoComand Comand)
        {
            this.Comand = Comand;
        }
    }
}


