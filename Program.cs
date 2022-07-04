using System;

namespace FirstApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string URL = "https://www.youtube.com/watch?v=3mhq_gcu9KM";
                VideoManager manager = new VideoManager();
                YoutubeVideo video = new YoutubeVideo(URL);
                manager.SetComand(new YuotubeComand(video));
                await manager.ShowVideoInfo();
                await manager.DownloadVideo();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}


