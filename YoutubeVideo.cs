using YoutubeExplode;
using YoutubeExplode.Converter;

namespace FirstApp
{
    class YoutubeVideo
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
            var info = await youtube.Videos.GetAsync(videoUrl);
            Console.WriteLine($"{info.Title}\n{info.Description}\n{info.Author}\n{info.Duration}");
        }
    }
}


